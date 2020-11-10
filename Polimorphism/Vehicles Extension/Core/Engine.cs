using System;
using System.Collections.Generic;
using System.Text;
using Vehicles.Core.Contracts;
using Vehicles.Factories;
using Vehicles.Models;

namespace Vehicles.Core
{
    public class Engine : IEngine
    {
        private VehicleFactory vehicleFactory;

        public Engine()
        {
            this.vehicleFactory = new VehicleFactory();
        }

        public void Run()
        {
            Vehicle car = ProduceVehicle();
            Vehicle truck = ProduceVehicle();
            Vehicle bus = ProduceVehicle();

            int n = int.Parse(Console.ReadLine());
            for (int i = 0; i < n; i++)
            {
                string[] command = Console.ReadLine().Split(" ", StringSplitOptions.RemoveEmptyEntries);
                try
                {
                    ProcessCommand(car, truck, bus, command);
                }
                catch (InvalidOperationException ioe)
                {
                    Console.WriteLine(ioe.Message);
                }
            }
            Console.WriteLine($"Car: {car.FuelQuantity:f2}");
            Console.WriteLine($"Truck: {truck.FuelQuantity:f2}");
            Console.WriteLine($"Bus: {bus.FuelQuantity:f2}");
        }

        private Vehicle ProduceVehicle()
        {
            string[] input = Console.ReadLine().Split();
            string type = input[0];
            double fuelQuantity = double.Parse(input[1]);
            double fuelConsumption = double.Parse(input[2]);
            double tankCapacity = double.Parse(input[3]);

            Vehicle vehicle = this.vehicleFactory.ProduceVehicle(type, fuelQuantity, fuelConsumption, tankCapacity);
            return vehicle;
        }

        private static void ProcessCommand(Vehicle car, Vehicle truck, Vehicle bus, string[] command)
        {
            string action = command[0];
            string type = command[1];
            double arg = double.Parse(command[2]);

            if (action == "Drive")
            {
                if (type == "Car")
                {
                    car.Drive(arg);
                }
                else if (type == "Truck")
                {
                    truck.Drive(arg);
                }
                else if(type == "Bus")
                {
                    bus.Drive(arg);
                }
            }
            else if (action == "Refuel")
            {
                if (type == "Car")
                {
                    car.Refuel(arg);
                }
                else if (type == "Truck")
                {
                    truck.Refuel(arg);
                }
                else if (type == "Bus")
                {
                    bus.Refuel(arg);
                }
            }
            else if(action == "DriveEmpty")
            {
                if(type == "Bus")
                {
                    bus.DriveEmpty(arg);
                }
            }
        }
    }
}
