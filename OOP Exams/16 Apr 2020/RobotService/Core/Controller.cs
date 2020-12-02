using RobotService.Core.Contracts;
using RobotService.Models.Garages;
using RobotService.Models.Garages.Contracts;
using RobotService.Models.Procedures;
using RobotService.Models.Procedures.Contracts;
using RobotService.Models.Robots;
using RobotService.Models.Robots.Contracts;
using RobotService.Utilities.Messages;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace RobotService.Core
{
    public class Controller : IController
    {
        private IGarage garage;
        private IProcedure charge;
        private IProcedure chip;
        private IProcedure polish;
        private IProcedure rest;
        private IProcedure techCheck;
        private IProcedure work;

        public Controller()
        {
            this.garage = new Garage();
            this.charge = new Charge();
            this.chip = new Chip();
            this.polish = new Polish();
            this.rest = new Rest();
            this.techCheck = new TechCheck();
            this.work = new Work();
        }
        public string Charge(string robotName, int procedureTime) //check if robot exists
        {
            if (!this.garage.Robots.ContainsKey(robotName))
            {
                throw new ArgumentException(string.Format(ExceptionMessages.InexistingRobot, robotName));
            }
            IRobot currentRobot = this.garage.Robots.FirstOrDefault(r => r.Key == robotName).Value;

            try
            {
                this.charge.DoService(currentRobot, procedureTime);
                return string.Format(OutputMessages.ChargeProcedure, robotName);
            }
            catch (Exception ex)
            {
                return ex.Message;
            }
        }

        public string Chip(string robotName, int procedureTime)//check if robot exists
        {
            if (!this.garage.Robots.ContainsKey(robotName))
            {
                throw new ArgumentException(string.Format(ExceptionMessages.InexistingRobot, robotName));
            }
            IRobot currentRobot = this.garage.Robots.FirstOrDefault(r => r.Key == robotName).Value;
            
            try
            {
                this.chip.DoService(currentRobot, procedureTime);
                return string.Format(OutputMessages.ChipProcedure, robotName);
            }
            catch (Exception ex)
            {
                return ex.Message;
            }
        }

        public string History(string procedureType)
        {
            string result = "";
            switch (procedureType)
            {
                case "Charge":
                    result = this.charge.History();
                    break;
                case "Chip":
                    result = this.chip.History();
                    break;
                case "Polish":
                    result = this.polish.History();
                    break;
                case "Rest":
                    result = this.rest.History();
                    break;
                case "TechCheck":
                    result = this.techCheck.History();
                    break;
                case "Work":
                    result = this.work.History();
                    break;
            }
            return result;
        }

        public string Manufacture(string robotType, string name, int energy, int happiness, int procedureTime)
        {
            if(robotType != "HouseholdRobot" && robotType != "PetRobot" && robotType != "WalkerRobot")
            {
                throw new ArgumentException(string.Format(ExceptionMessages.InvalidRobotType, robotType));
            }
            try
            {
                IRobot robot = null;
                switch (robotType)
                {
                    case "HouseholdRobot":
                        robot = new HouseholdRobot(name, energy, happiness, procedureTime);
                        break;
                    case "PetRobot":
                        robot = new PetRobot(name, energy, happiness, procedureTime);
                        break;
                    case "WalkerRobot":
                        robot = new WalkerRobot(name, energy, happiness, procedureTime);
                        break;
                }
                if(robot != null)
                {
                    this.garage.Manufacture(robot);
                }
                return String.Format(OutputMessages.RobotManufactured, name);
            }
            catch (Exception ex)
            {
               return ex.Message;
            }
        }

        public string Polish(string robotName, int procedureTime)//check if robot exists
        {
            if (!this.garage.Robots.ContainsKey(robotName))
            {
                throw new ArgumentException(string.Format(ExceptionMessages.InexistingRobot, robotName));
            }
            IRobot currentRobot = this.garage.Robots.FirstOrDefault(r => r.Key == robotName).Value;

            try
            {
                this.polish.DoService(currentRobot, procedureTime);
                return string.Format(OutputMessages.PolishProcedure, robotName);
            }
            catch (Exception ex)
            {
                return ex.Message;
            }
        }

        public string Rest(string robotName, int procedureTime)//check if robot exists
        {
            if (!this.garage.Robots.ContainsKey(robotName))
            {
                throw new ArgumentException(string.Format(ExceptionMessages.InexistingRobot, robotName));
            }
            IRobot currentRobot = this.garage.Robots.FirstOrDefault(r => r.Key == robotName).Value;

            try
            {
                this.rest.DoService(currentRobot, procedureTime);
                return string.Format(OutputMessages.RestProcedure, robotName);
            }
            catch (Exception ex)
            {
                return ex.Message;
            }
        }

        public string Sell(string robotName, string ownerName)//check if robot exists
        {
            if (!this.garage.Robots.ContainsKey(robotName))
            {
                throw new ArgumentException(string.Format(ExceptionMessages.InexistingRobot, robotName));
            }
            IRobot currentRobot = this.garage.Robots.FirstOrDefault(r => r.Key == robotName).Value;
            garage.Sell(robotName, ownerName);

            if (currentRobot.IsChipped)
            {
                return string.Format(OutputMessages.SellChippedRobot, ownerName);
            }
            else
            {
                return string.Format(OutputMessages.SellNotChippedRobot, ownerName);
            }
        }

        public string TechCheck(string robotName, int procedureTime)//check if robot exists
        {
            if (!this.garage.Robots.ContainsKey(robotName))
            {
                throw new ArgumentException(string.Format(ExceptionMessages.InexistingRobot, robotName));
            }
            IRobot currentRobot = this.garage.Robots.FirstOrDefault(r => r.Key == robotName).Value;

            try
            {
                this.techCheck.DoService(currentRobot, procedureTime);
                return string.Format(OutputMessages.TechCheckProcedure, robotName);
            }
            catch (Exception ex)
            {
                return ex.Message;
            }
        }

        public string Work(string robotName, int procedureTime)//check if robot exists
        {
            if (!this.garage.Robots.ContainsKey(robotName))
            {
                throw new ArgumentException(string.Format(ExceptionMessages.InexistingRobot, robotName));
            }
            IRobot currentRobot = this.garage.Robots.FirstOrDefault(r => r.Key == robotName).Value;

            try
            {
                this.work.DoService(currentRobot, procedureTime);
                return string.Format(OutputMessages.WorkProcedure, robotName, procedureTime);
            }
            catch (Exception ex)
            {
                return ex.Message;
            }
        }
    }
}
