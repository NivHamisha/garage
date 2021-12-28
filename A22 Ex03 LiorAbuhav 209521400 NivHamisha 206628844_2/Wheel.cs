using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ex03.GarageLogic
{
    public class Wheel
    {
        private string m_ManufacturerName;
        private float m_CurrentAirPressure = 0;
        private float m_MaxAirPressureSetByTheManufacturer;

        public string ManufacturerName
        {
            get
            {
                return this.m_ManufacturerName;
            }
            set
            {
                this.m_ManufacturerName = value;
            }
        }
        public float CurrentAirPressure
        {
            get
            {
                return this.m_CurrentAirPressure;
            }
            set
            {
                this.m_CurrentAirPressure = value;
            }
        }
        public float MaxAirPressureSetByTheManufacturer
        {
            get
            {
                return this.m_MaxAirPressureSetByTheManufacturer;
            }
            set
            {
                this.MaxAirPressureSetByTheManufacturer = value;
            }
        }

        public Wheel(float i_WheelMaxAirPressureSetByTheManufacturer, string i_WheelManufacturerName = null)
        {
            this.m_ManufacturerName = i_WheelManufacturerName ?? "default";
            this.m_ManufacturerName = i_WheelManufacturerName;
            this.m_MaxAirPressureSetByTheManufacturer = i_WheelMaxAirPressureSetByTheManufacturer;
        }

        public void InflateWheel(float i_AirPressureToAdd)
        {
            //here add function implementation
        }
    }
}
