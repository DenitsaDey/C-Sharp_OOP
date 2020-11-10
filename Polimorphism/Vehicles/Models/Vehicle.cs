using System;
using System.Collections.Generic;
using System.Text;
using Vehicles.Common;
using Vehicles.Models.Contracts;

namespace Vehicles.Models
{
    public abstract class Vehicle : IDriveable, IRefuelable
    {

        public Vehicle(double fuelQuantity, double fuelConsumption)
        {
            this.FuelQuantity = fuelQuantity;
            this.FuelConsumption = fuelConsumption;
        }
        
        public double FuelQuantity { get; private set; }

        public virtual double FuelConsumption { get; protected set; }
        


        public void Drive(double distance)
        {
            var fuelNeeded = this.FuelConsumption * distance;
            if(fuelNeeded > this.FuelQuantity)
            {
                throw new InvalidOperationException(String.Format(ExceptionMessages.NotEnoughFuelExcMsg, this.GetType().Name));
            }
            this.FuelQuantity -= fuelNeeded;
            Console.WriteLine($"{this.GetType().Name} travelled {distance} km");

        }

        public virtual void Refuel(double fuelAmount)
        {
            if (fuelAmount > 0)
            {
                this.FuelQuantity += fuelAmount;
            }
        }
    }
}
