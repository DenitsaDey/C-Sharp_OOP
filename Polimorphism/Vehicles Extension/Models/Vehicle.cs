using System;
using System.Collections.Generic;
using System.Text;
using Vehicles.Common;
using Vehicles.Models.Contracts;

namespace Vehicles.Models
{
    public abstract class Vehicle : IDriveable, IRefuelable
    {
        private double fuelQuantity;

        protected Vehicle(double fuelQuantity, double fuelConsumption, double tankCapacity)
        {
            this.FuelQuantity = fuelQuantity;
            this.FuelConsumption = fuelConsumption;
            this.TankCapacity = tankCapacity;
        }

        public virtual double FuelQuantity {
            get
            {
                return this.fuelQuantity;
            } 
            protected set
            {
                if(value > this.TankCapacity)
                {
                    this.fuelQuantity = 0;
                }
                this.fuelQuantity = value;
            } 
        }

        public virtual double FuelConsumption { get; protected set; }
        
        public double TankCapacity { get; private set; }

        public virtual double FuelConsumptionEmpty { get; protected set; }

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

        public void DriveEmpty(double distance)
        {
            var fuelNeeded = this.FuelConsumptionEmpty * distance;
            if (fuelNeeded > this.FuelQuantity)
            {
                throw new InvalidOperationException(String.Format(ExceptionMessages.NotEnoughFuelExcMsg, this.GetType().Name));
            }
            this.FuelQuantity -= fuelNeeded;
            Console.WriteLine($"{this.GetType().Name} travelled {distance} km");
        }

        public virtual void Refuel(double fuelAmount)
        {
            if (fuelAmount <= 0)
            {
                throw new InvalidOperationException(String.Format(ExceptionMessages.NegativeFuelExcMsg));
            }
            else
            {
                if(fuelAmount > (this.TankCapacity - this.FuelQuantity))
                {
                    throw new InvalidOperationException(String.Format(ExceptionMessages.MoreFuelExcMsg, fuelAmount));
                }
                this.FuelQuantity += fuelAmount;
            }
        }
    }
}
