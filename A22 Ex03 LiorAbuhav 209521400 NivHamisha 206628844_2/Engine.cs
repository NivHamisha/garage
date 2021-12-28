using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ex03.GarageLogic
{
    public abstract class Engine
    {
        private float m_CurrentEnergyRate;
        private float m_MaxEnergyRate;

        protected float CurrentEnergyRate
        {
            get
            {
                return this.m_CurrentEnergyRate;
            }
            set
            {
                this.m_CurrentEnergyRate = value;
            }
        }

        protected float MaxEnergyRate
        {
            get
            {
                return this.m_MaxEnergyRate;
            }
            set
            {
                this.m_MaxEnergyRate = value;
            }
        }

        public Engine(float i_MaxEnergyRate)
        {
            this.m_CurrentEnergyRate = 0;
            this.m_MaxEnergyRate = i_MaxEnergyRate;
        }

        protected void loadEnergy(float i_EnergyToAdd)
        {
            if (i_EnergyToAdd > 0 && m_CurrentEnergyRate + i_EnergyToAdd <= m_MaxEnergyRate)
            {
                m_CurrentEnergyRate += i_EnergyToAdd;
                // todo calculate precentage (at Vhicle members)
            }
            else
            {
                throw new ValueOutOfRangeException();
            }
        }
    }
}
