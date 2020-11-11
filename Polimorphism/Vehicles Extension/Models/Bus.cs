using System;
using System.Collections.Generic;
using System.Text;
using Vehicles.Common;

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

        //public override double FuelConsumptionEmpty
        //{
        //    get
        //    {
        //        return base.FuelConsumption;
        //    }

        //    protected set
        //    {
        //        base.FuelConsumption = value;
        //    }
        //}

        public override void DriveEmpty(double distance)
        {
            var fuelNeeded = (this.FuelConsumption - Airconditioning) * distance;
            if (fuelNeeded > this.FuelQuantity)
            {
                throw new InvalidOperationException(String.Format(ExceptionMessages.NotEnoughFuelExcMsg, this.GetType().Name));
            }
            this.FuelQuantity -= fuelNeeded;
            Console.WriteLine($"{this.GetType().Name} travelled {distance} km");
        }
    }
}
