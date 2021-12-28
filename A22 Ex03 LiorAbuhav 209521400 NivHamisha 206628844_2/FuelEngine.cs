using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ex03.GarageLogic
{
    public class FuelEngine : Engine
    {
        private eFuelType m_FuelType;

        public FuelEngine(float i_MaxEnergyRate, eFuelType i_FuelType) : base(i_MaxEnergyRate)
        {
            this.m_FuelType = i_FuelType;
        }

        public void Refuel(eFuelType i_EngineFuelType, float i_FuelAmountToAddInLiters)
        {
            if (i_EngineFuelType == this.m_FuelType)
            {
                base.loadEnergy(i_FuelAmountToAddInLiters);
            }
            else
            {
                throw new ArgumentException();
            }
            throw new NotImplementedException();
        }
    }
}
