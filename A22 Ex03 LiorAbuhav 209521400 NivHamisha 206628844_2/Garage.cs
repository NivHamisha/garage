using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ex03.GarageLogic
{
    public class Garage
    {
        List<RepairedVehicle> m_CurrentGarageVehicles;

        public Garage()
        {
        }

        public RepairedVehicle GetRepairedVehicleByLiecenceNumber(string i_LicenceNumber)
        {
            RepairedVehicle repairedVehicle = null;

            foreach (RepairedVehicle repairedVehicleToCheckWith in this.m_CurrentGarageVehicles)
            {
                if (repairedVehicleToCheckWith.Vehicle.LicenseNumber == i_LicenceNumber)
                {
                    repairedVehicle = repairedVehicleToCheckWith;
                    break;
                }
            }

            return repairedVehicle;
        }

        public bool UpdateRepairedVehicleStatusIfExists(Vehicle i_VehicleToUpdateRepairStatus, eVehicleRepairStatus i_StatusToUpdateTo)
        {
            bool isUpdated = false;

            foreach (RepairedVehicle repairedVehicleToCheckWith in this.m_CurrentGarageVehicles)
            {
                if (repairedVehicleToCheckWith.Vehicle.LicenseNumber == i_VehicleToUpdateRepairStatus.LicenseNumber)
                {
                    isUpdated = true;
                    repairedVehicleToCheckWith.VehicleStatus = eVehicleRepairStatus.InRepair;
                    break;
                }
            }

            return isUpdated;
        }

        public bool EnsureVehicleRepairInGarage(RepairedVehicle i_VehicleToEnsureRepairing)
        {
            bool isVehicleExistsInGarage = this.UpdateRepairedVehicleStatusIfExists(i_VehicleToEnsureRepairing.Vehicle, eVehicleRepairStatus.InRepair);

            if (!isVehicleExistsInGarage)
            {
                this.m_CurrentGarageVehicles.Add(i_VehicleToEnsureRepairing);
            }

            return isVehicleExistsInGarage;
        }

        public void InflateVehicleWheelsToMaximum(RepairedVehicle i_VehicleToInflate)
        {
            foreach (RepairedVehicle repairedVehicleToCheckWith in this.m_CurrentGarageVehicles)
            {
                if (re)
            }
        }

        public string[] GetAllVehiclesLieceneNumbers()
        {
            RepairedVehicle[] garageRepairedVehicles = this.m_CurrentGarageVehicles.ToArray();
            string[] vehiclesLieceneNumbers = new string[garageRepairedVehicles.Length];

            for (int i = 0; i < garageRepairedVehicles.Length; i++)
            {
                vehiclesLieceneNumbers[i] = garageRepairedVehicles[i].Vehicle.LicenseNumber;
            }

            return vehiclesLieceneNumbers;
        }

        public string[] GetVehiclesLicenseNumbersByRepairStatus(eVehicleRepairStatus i_RepairStatusToFilterBy)
        {
            RepairedVehicle[] repairedVehiclesAfterFilter = getVehiclesfilteredByRepairStatus(i_RepairStatusToFilterBy).ToArray();
            string[] vehiclesLieceneNumbers = new string[repairedVehiclesAfterFilter.Length];

            for (int i = 0; i < repairedVehiclesAfterFilter.Length; i++)
            {
                vehiclesLieceneNumbers[i] = repairedVehiclesAfterFilter[i].Vehicle.LicenseNumber;
            }

            return vehiclesLieceneNumbers;
        }

        private List<RepairedVehicle> getVehiclesfilteredByRepairStatus(eVehicleRepairStatus i_RepairStatusToFilterBy)
        {
            List<RepairedVehicle> repairedVehiclesWithStatusFilter = new List<RepairedVehicle>();

            foreach (RepairedVehicle repairedVehicleToCheckWith in this.m_CurrentGarageVehicles)
            {
                if (repairedVehicleToCheckWith.VehicleStatus == i_RepairStatusToFilterBy)
                {
                    repairedVehiclesWithStatusFilter.Add(repairedVehicleToCheckWith);
                }
            }

            return repairedVehiclesWithStatusFilter;
        }
    }
}
