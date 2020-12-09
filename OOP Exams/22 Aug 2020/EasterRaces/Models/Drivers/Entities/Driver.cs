using EasterRaces.Models.Cars.Contracts;
using EasterRaces.Models.Drivers.Contracts;
using EasterRaces.Utilities.Messages;
using System;
using System.Collections.Generic;
using System.Text;

namespace EasterRaces.Models.Drivers.Entities
{
    public class Driver : IDriver
    {
        private const int MinLength = 5;

        private string name;
        private bool canParticipate;

        public Driver(string name)
        {
            this.Name = name;
        }
        public string Name
        {
            get => this.name;
            private set
            {
                if (string.IsNullOrEmpty(value) || value.Length < MinLength)
                {
                    throw new ArgumentException(string.Format(ExceptionMessages.InvalidName, value, MinLength));
                }
                this.name = value;
            }
        }

        public ICar Car { get; private set; }
         

        public int NumberOfWins { get; private set; }

        public bool CanParticipate
        {
            get => canParticipate;
            private set
            {
                if (this.Car != null)
                {
                    value = true;
                }
                this.canParticipate = value;
            }
        }

        public void AddCar(ICar car)
        {
            if (car == null)
            {
                throw new ArgumentNullException(ExceptionMessages.CarInvalid);
            }
            this.Car = car;
            this.CanParticipate = true;
        }

        public void WinRace()
        {
            this.NumberOfWins++;
        }
    }
}
