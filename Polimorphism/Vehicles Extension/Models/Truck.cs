using System;
using System.Collections.Generic;
using System.Text;

namespace Vehicles.Models
{
    public class Truck : Vehicle
    {
        private const double Airconditioning = 1.6;
        private const double TankLeak = 0.95;
        
        public Truck(double fuelQuantity, double fuelConsumption, double tankCapacity) 
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

        //public override double FuelQuantity => base.FuelQuantity * TankLeak;

        public override void Refuel(double fuelAmount)
        {
            base.Refuel(fuelAmount);
            this.FuelQuantity -= fuelAmount * TankLeak;
        }
    }
}
