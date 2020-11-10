using System;
using System.Collections.Generic;
using System.Text;

namespace Vehicles.Models
{
    public class Bus : Vehicle
    {
        private const double Airconditioning = 1.4;

        public Bus(double fuelQuantity, double fuelConsumption, double tankCapacity)
            : base(fuelQuantity, fuelConsumption, tankCapacity)
        {
        }

        public override double FuelConsumption
        {
            get
            {
                return base.FuelConsumption;
            }

            protected set
            {
                base.FuelConsumption = value + Airconditioning;
            }
        }

        public override double FuelConsumptionEmpty
        {
            get
            {
                return base.FuelConsumption;
            }

            protected set
            {
                base.FuelConsumption = value;
            }
        }
    }
}
