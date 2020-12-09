using EasterRaces.Core.Contracts;
using EasterRaces.Repositories.Entities;
using System;
using System.Linq;
using System.Collections.Generic;
using System.Text;
using EasterRaces.Utilities.Messages;
using EasterRaces.Models.Drivers.Contracts;
using EasterRaces.Models.Drivers.Entities;
using EasterRaces.Models.Cars.Contracts;
using EasterRaces.Models.Cars.Entities;
using EasterRaces.Models.Races.Entities;

namespace EasterRaces.Core.Entities
{
    public class ChampionshipController : IChampionshipController
    {
        private const int MinDrivers = 3;

        private readonly DriverRepository drivers;
        private readonly CarRepository cars;
        private readonly RaceRepository races;
        public ChampionshipController()
        {
            this.drivers = new DriverRepository();
            this.cars = new CarRepository();
            this.races = new RaceRepository();
        }

        //done
        public string AddCarToDriver(string driverName, string carModel)
        {
            var driverForCar = this.drivers.GetByName(driverName);
            var carToAdd = this.cars.GetByName(carModel);

            if (driverForCar == null)
            {
                throw new InvalidOperationException(string.Format(ExceptionMessages.DriverNotFound, driverName));
            }
            if(carToAdd == null)
            {
                throw new InvalidOperationException(string.Format(ExceptionMessages.CarNotFound, carModel));
            }
           
            driverForCar.AddCar(carToAdd);
            return string.Format(OutputMessages.CarAdded, driverName, carModel);
        }

        //done
        public string AddDriverToRace(string raceName, string driverName)
        {
            var wantedRace = this.races.GetByName(raceName);
            var driverForRace = this.drivers.GetByName(driverName);

            if (wantedRace == null)
            {
                throw new InvalidOperationException(string.Format(ExceptionMessages.RaceNotFound, raceName));
            }
            if (driverForRace == null)
            {
                throw new InvalidOperationException(string.Format(ExceptionMessages.DriverNotFound, driverName));
            }
           
            wantedRace.AddDriver(driverForRace);
            return string.Format(OutputMessages.DriverAdded, driverName, raceName);
        }

        //done
        public string CreateCar(string type, string model, int horsePower)
        {
            if (this.cars.GetByName(model) != null)
            {
                throw new ArgumentException(string.Format(ExceptionMessages.CarExists, model));
            }

            ICar car = null;
            switch (type)
            {
                case "Muscle":
                    car = new MuscleCar(model, horsePower);
                    break;
                case "Sports":
                    car = new SportsCar(model, horsePower);
                    break;
            }      

            this.cars.Add(car);
            return string.Format(OutputMessages.CarCreated, car.GetType().Name, model);


        }

        //done
        public string CreateDriver(string driverName)
        {
            if (this.drivers.GetByName(driverName) != null)
            {
                throw new ArgumentException(string.Format(ExceptionMessages.DriversExists, driverName));
            }
            Driver newDriver = new Driver(driverName);
            this.drivers.Add(newDriver);
            return string.Format(OutputMessages.DriverCreated, driverName);
        }

        //done
        public string CreateRace(string name, int laps)
        {
            if (this.races.GetByName(name) != null)
            {
                throw new InvalidOperationException(string.Format(ExceptionMessages.RaceExists, name));
            }
            Race newRace = new Race(name, laps);
            this.races.Add(newRace);
            return string.Format(OutputMessages.RaceCreated, name);
        }

        public string StartRace(string raceName)
        {
            var wantedRace = this.races.GetByName(raceName);

            if (wantedRace == null)
            {
                throw new InvalidOperationException(string.Format(ExceptionMessages.RaceNotFound, raceName));
            }

            if(wantedRace.Drivers.Count < MinDrivers)
            {
                throw new InvalidOperationException(string.Format(ExceptionMessages.RaceInvalid, raceName, MinDrivers));
            }
            int laps = wantedRace.Laps;
            var sortedDrivers = wantedRace.Drivers.OrderByDescending(d => d.Car.CalculateRacePoints(laps)).Take(3).ToList();
            this.races.Remove(wantedRace);

            StringBuilder sb = new StringBuilder();
            sb.AppendLine(string.Format(OutputMessages.DriverFirstPosition, sortedDrivers[0].Name, raceName));
            sb.AppendLine(string.Format(OutputMessages.DriverSecondPosition, sortedDrivers[1].Name, raceName));
            sb.AppendLine(string.Format(OutputMessages.DriverThirdPosition, sortedDrivers[2].Name, raceName));

            return sb.ToString().TrimEnd();
        }
    }
}
