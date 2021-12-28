using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ex03.GarageLogic
{
    public abstract class Vehicle
    {
        private string m_ModelName;
        private string m_LicenseNumber;
        private float m_RemainingPrecentageOfEnergy;
        private eWheelsCount m_WheelsCount;
        private List<Wheel> m_Wheels;
        private Engine m_Engine;

        public string ModelName
        {
            get
            {
                return this.m_ModelName;
            }
            set
            {
                this.m_ModelName = value;
            }
        }

        public string LicenseNumber
        {
            get
            {
                return this.m_LicenseNumber;
            }
            set
            {
                this.m_LicenseNumber = value;
            }
        }

        public float RemainingPrecentageOfEnergy
        {
            get
            {
                return this.m_RemainingPrecentageOfEnergy;
            }
            set
            {
                this.m_RemainingPrecentageOfEnergy = value;
            }
        }

        public List<Wheel> Wheels
        {
            get
            {
                return this.m_Wheels;
            }
            set
            {
                if (value.Count != this.m_Wheels.Count)
                {
                    throw new ArgumentException();
                }

                this.m_Wheels = value;
            }
        }

        public Engine Engine
        {
            get
            {
                return this.m_Engine;
            }
            set
            {
                this.m_Engine = value;
            }
        }

        protected eWheelsCount WheelsCount
        {
            get
            {
                return this.m_WheelsCount;
            }
        }

        public Vehicle(float i_WheelMaxAirPressureSetByTheManufacturer, string i_WheelManufacturerName = null, eWheelsCount i_WheelsCount = default(eWheelsCount), string i_ModelName = null, string i_LicenseNumber = null)
        {
            this.m_ModelName = i_ModelName ?? string.Empty;
            this.m_LicenseNumber = i_LicenseNumber ?? string.Empty;
            this.m_RemainingPrecentageOfEnergy = 0;
            this.m_WheelsCount = i_WheelsCount;
            this.m_Wheels = this.getWheelsList(i_WheelMaxAirPressureSetByTheManufacturer, i_WheelManufacturerName);
        }

        private List<Wheel> getWheelsList(float i_WheelMaxAirPressureSetByTheManufacturer, string i_WheelManufacturerName = null)
        {
            List<Wheel> wheels = new List<Wheel>();

            for (int i = 0; i < (int)m_WheelsCount; i++)
            {
                wheels.Add(new Wheel(i_WheelMaxAirPressureSetByTheManufacturer, i_WheelManufacturerName));
            }

            return wheels;
        }
    }
}
