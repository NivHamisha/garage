using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ex03.GarageLogic
{
    public class GarageController
    {
        private Garage m_ControlledGarage;
        private static List<Vehicle> m_AllowedVehiclesTypes;

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

        private bool isAllowedVehicle(Vehicle i_VehicleToCheck) 
        {
            bool isAllowedVehicle = false;

            foreach (Vehicle allowedVehicle in m_AllowedVehiclesTypes)
            {
                if (i_VehicleToCheck.GetType() == allowedVehicle.GetType()) 
                {
                    i_VehicleToCheck.Engine.GetType();
                    if (i_VehicleToCheck.GetWheelMaxAirPressureSetByTheManufacturer() == allowedVehicle.GetWheelMaxAirPressureSetByTheManufacturer() && i_VehicleToCheck.Engine.Equals(allowedVehicle.Engine))
                    {
                        isAllowedVehicle = true;
                        break;
                    }
                }
            }

            return isAllowedVehicle;
        }

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
            RepairedVehicle vehicleToChangeRepairStatus = this.m_ControlledGarage.GetRepairedVehicleByLiecenceNumber(i_LicenseNumber);

            if (vehicleToChangeRepairStatus == null)
            {
                throw new NullReferenceException(String.Format("vehclie with liecence number {0} does not exists in garage", i_LicenseNumber)); 
            }
            
            this.m_ControlledGarage.UpdateRepairedVehicleStatusIfExists(vehicleToChangeRepairStatus.Vehicle, i_NewRepairStatus);
        }

        public void InflateVehicleWheelsToMaximum(string i_LicenseNumber)
        {
            RepairedVehicle repairedVehicleInGarage = this.m_ControlledGarage.GetRepairedVehicleByLiecenceNumber(i_LicenseNumber);

            if (repairedVehicleInGarage == null)
            {
                throw new NullReferenceException(String.Format("vehclie with liecence number {0} does not exists in garage", i_LicenseNumber));
            }


        }

        public void RefualFuelVehicle(string i_LicenseNumber, eFuelType i_FuelTypeToFill, float i_FuelAmountToFill)
        {

        }

        public void ChargeElectricVehicle(string i_LicenseNumber, float i_MinutesAmountToCharge)
        {

        }

        public void PrintFullVehicleDetailes()
        {

        }
    }
}
