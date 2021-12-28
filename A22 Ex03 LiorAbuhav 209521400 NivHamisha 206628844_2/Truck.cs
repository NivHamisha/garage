using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ex03.GarageLogic
{
    public class Truck : Vehicle
    {
        private bool m_IsDrivingRefregiratedContents;
        private float m_CargoVolume;
        private const int k_WheelsNumber = 16;

        public bool IsDrivingRefregiratedContents
        {
            get
            {
                return this.m_IsDrivingRefregiratedContents;
            }
            set
            {
                this.m_IsDrivingRefregiratedContents = value;
            }
        }
        public float CargoVolume
        {
            get
            {
                return this.m_CargoVolume;
            }
            set
            {
                this.m_CargoVolume = value;
            }
        }

        public Truck(float i_WheelMaxAirPressureSetByTheManufacturer, string i_ModelName, string i_LicenseNumber,
            string i_WheelManufacturerName, bool i_IsDrivingRefregiratedContents, float i_CargoVolume, Engine i_truckEngine)
            : base(i_WheelMaxAirPressureSetByTheManufacturer, i_WheelManufacturerName, eWheelsCount.Sixteen, i_ModelName, i_LicenseNumber)
        {
            this.m_IsDrivingRefregiratedContents = i_IsDrivingRefregiratedContents;
            this.m_CargoVolume = i_CargoVolume;
            base.Engine = i_truckEngine;
        }

        /*        public Truck(float i_WheelMaxAirPressureSetByTheManufacturer, float i_EngineFuelAmountToAddInLiters, eFuelType i_EngineFuelType) : base(i_WheelMaxAirPressureSetByTheManufacturer)
                {
                    this.m_IsDrivingRefregiratedContents = false;
                    this.m_CargoVolume = 0;
                    setEngine(i_EngineFuelAmountToAddInLiters, i_EngineFuelType);
                }*/

        /*        private void setEngine(float i_EngineFuelAmountToAddInLiters, eFuelType i_EngineFuelType)
                {
                    FuelEngine engine = new FuelEngine(i_EngineFuelAmountToAddInLiters, i_EngineFuelType);
                    base.Engine = engine;
                }*/

        public static Truck CreateTruck(float i_WheelMaxAirPressureSetByTheManufacturer, float i_EngineFuelAmountToAddInLiters,
            eFuelType i_EngineFuelType, string i_ModelName = null, string i_LicenseNumber = null,
            string i_WheelManufacturerName = null, bool i_IsDrivingRefregiratedContents = false, float i_CargoVolume = 0)
        {
            FuelEngine fuelEngine = new FuelEngine(i_EngineFuelAmountToAddInLiters, i_EngineFuelType);

            return new Truck(i_WheelMaxAirPressureSetByTheManufacturer, i_ModelName, i_LicenseNumber, i_WheelManufacturerName,
                i_IsDrivingRefregiratedContents, i_CargoVolume, fuelEngine);
        }
    }
}
