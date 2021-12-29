using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ex03.GarageLogic
{
    public class GarageController
    {
        #region Data Members
        private Garage m_ControlledGarage;
        private static List<Vehicle> m_AllowedVehiclesTypes;
        #endregion

        #region Constructor
        public GarageController()
        {
            List<Vehicle> allowedVehiclesTypes = new List<Vehicle>();
            Car test = Car.CreateFuelCar(29f, 48f, eFuelType.Octan95);

            allowedVehiclesTypes.Add(Motorcycle.CreateFuelMotorcycle(30f, 5.8f, eFuelType.Octan98));
            allowedVehiclesTypes.Add(Motorcycle.CreateElectricMotorcycle(30f, 2.3f));
            allowedVehiclesTypes.Add(Car.CreateFuelCar(29f, 48f, eFuelType.Octan95));
            allowedVehiclesTypes.Add(Car.CreateElectricCar(29f, 2.6f));
            allowedVehiclesTypes.Add(Truck.CreateTruck(25f, 130f, eFuelType.Soler));
            m_AllowedVehiclesTypes = allowedVehiclesTypes;
            this.m_ControlledGarage = new Garage();
        }
        #endregion

        #region Public Methods
        public bool InsertVehicleToGarage(Vehicle i_VehicleToRepair, string i_OwnerName, string i_OwnerPhone)
        {
            RepairedVehicle vehicleToEnsureInGarage = new RepairedVehicle(i_VehicleToRepair, i_OwnerName, i_OwnerPhone);
            bool isVehicleAlreadyExistedInGarage = this.m_ControlledGarage.EnsureVehicleRepairInGarage(vehicleToEnsureInGarage);

            return isVehicleAlreadyExistedInGarage;
        }

        public string[] GetAllVehiclesLicenseNumbers()
        {
            return this.m_ControlledGarage.GetAllVehiclesLieceneNumbers();
        }

        public string[] GetVehiclesLicenseNumbersByRepairStatus(eVehicleRepairStatus i_RepairStatusToFilterBy)
        {
            return this.m_ControlledGarage.GetVehiclesLicenseNumbersByRepairStatus(i_RepairStatusToFilterBy);
        }

        public void ChangeVehicleRepairStatus(string i_LicenseNumber, eVehicleRepairStatus i_NewRepairStatus)
        {
            RepairedVehicle vehicleToChangeRepairStatus = this.getGarageRepairedVehicleByLiecenceNumber(i_LicenseNumber);

            this.m_ControlledGarage.UpdateRepairedVehicleStatusIfExists(vehicleToChangeRepairStatus, i_NewRepairStatus);
        }

        public void InflateVehicleWheelsToMaximum(string i_LicenseNumber)
        {
            RepairedVehicle repairedVehicleToInflateInGarage = this.getGarageRepairedVehicleByLiecenceNumber(i_LicenseNumber);

            this.m_ControlledGarage.InflateVehicleWheelsToMaximum(repairedVehicleToInflateInGarage);
        }

        public void RefualFuelVehicle(string i_LicenseNumber, eFuelType i_FuelTypeToFill, float i_FuelAmountToFill)
        {
            RepairedVehicle repairedVehicleToRefuel = this.getGarageRepairedVehicleByLiecenceNumber(i_LicenseNumber);

            this.m_ControlledGarage.RefuelVehicle(repairedVehicleToRefuel, i_FuelTypeToFill, i_FuelAmountToFill);
        }

        public void ChargeElectricVehicle(string i_LicenseNumber, float i_MinutesAmountToCharge)
        {
            RepairedVehicle repairedVehicleToCharge = this.getGarageRepairedVehicleByLiecenceNumber(i_LicenseNumber);

            this.m_ControlledGarage.ChargeVehicle(repairedVehicleToCharge, i_MinutesAmountToCharge);
        }

        public RepairedVehicle GetRepairVehicle(string i_LicenseNumber)
        {
            RepairedVehicle repairedVehicle = this.getGarageRepairedVehicleByLiecenceNumber(i_LicenseNumber);

            return repairedVehicle;
        }
        #endregion

        #region Private Methods
        private static bool isAllowedVehicleType(Vehicle i_VehicleToCheck)
        {
            bool isAllowedVehicle = false;

            foreach (Vehicle allowedVehicle in m_AllowedVehiclesTypes)
            {
                if (Garage.IsVehicleEqualType(i_VehicleToCheck, allowedVehicle))
                {
                    isAllowedVehicle = true;
                    break;
                }
            }

            return isAllowedVehicle;
        }

        private RepairedVehicle getGarageRepairedVehicleByLiecenceNumber(string i_LicenseNumber)
        {
            RepairedVehicle repairedVehicle = this.m_ControlledGarage.GetRepairedVehicleByLiecenceNumber(i_LicenseNumber);

            if (repairedVehicle == null)
            {
                throw new NullReferenceException(String.Format("vehclie with liecence number {0} does not exists in garage", i_LicenseNumber));
            }

            return repairedVehicle;
        }
        #endregion
    }
}
