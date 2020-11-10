using System;
using System.Collections.Generic;
using System.Text;

namespace Vehicles.Models
{
    public class Truck : Vehicle
    {
        private const double Airconditioning = 1.6;
        private const double TankLeak = 0.95;
        
        public Truck(double fuelQuantity, double fuelConsumption) 
            : base(fuelQuantity, fuelConsumption)
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

        public override void Refuel(double fuelAmount)
        {
            base.Refuel(fuelAmount * TankLeak);
        }
    }
}
