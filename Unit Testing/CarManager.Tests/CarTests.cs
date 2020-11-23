//using CarManager;
using NUnit.Framework;
using System;

namespace Tests
{
    public class CarTests
    {
        [SetUp]
        public void Setup()
        {
        }

        [Test]
        public void ConstructorShouldInitializeCorrectly()
        {
            string make = "VW";
            string model = "Golf";
            double fuelConsumption = 10;
            double fuelCapacity = 200;

            Car car = new Car(make, model, fuelConsumption, fuelCapacity);

            Assert.AreEqual(make, car.Make);
            Assert.AreEqual(model, car.Model);
            Assert.AreEqual(fuelConsumption, car.FuelConsumption);
            Assert.AreEqual(fuelCapacity, car.FuelCapacity);
        }

        
        [Test]
        [TestCase(null, "Golf", 10, 200)]
        [TestCase("VW", null, 10, 200)]
        [TestCase("VW", "Golf", -10, 200)]
        [TestCase("VW", "Golf", 0, 200)]
        [TestCase("VW", "Golf", 10, -200)]
        [TestCase("VW", "Golf", 10, 0)]
        public void AllPropertiesShouldThrowArgumentExceptionForInvalidInput
            (string make, string model, double fuelConsumption, double fuelCapacity)
        {
            Assert.Throws<ArgumentException>(() => new Car(make, model, fuelConsumption, fuelCapacity));
        }

        [Test]
        public void RefuelShouldAddFuelToFuelAmount()
        {
            string make = "VW";
            string model = "Golf";
            double fuelConsumption = 10;
            double fuelCapacity = 200;

            Car car = new Car(make, model, fuelConsumption, fuelCapacity);
            car.Refuel(10);

            double expectedAmount = 10;
            double actualAmount = car.FuelAmount;

            Assert.AreEqual(expectedAmount, actualAmount);
        }

        [Test]
        public void RefuelShouldAddFuelUntilTheFuelCapacity()
        {
            string make = "VW";
            string model = "Golf";
            double fuelConsumption = 10;
            double fuelCapacity = 200;

            Car car = new Car(make, model, fuelConsumption, fuelCapacity);
            car.Refuel(1000);

            double expectedAmount = 200;
            double actualAmount = car.FuelAmount;

            Assert.AreEqual(expectedAmount, actualAmount);
        }

        [Test]
        [TestCase(-10)]
        [TestCase(0)]
        public void RefuelShouldThrowArgumentExceptionWhenFuelAmountIsBellowZero(double inputAmount)
        {
            string make = "VW";
            string model = "Golf";
            double fuelConsumption = 10;
            double fuelCapacity = 200;

            Car car = new Car(make, model, fuelConsumption, fuelCapacity);

            Assert
                .Throws<ArgumentException>(() => car.Refuel(inputAmount));
        }

        [Test]
        public void ShouldDriveNormally()
        {
            string make = "VW";
            string model = "Golf";
            double fuelConsumption = 10;
            double fuelCapacity = 200;

            Car car = new Car(make, model, fuelConsumption, fuelCapacity);
            car.Refuel(20);
            car.Drive(20);

            double expectedAmount = 18;
            double actualAmount = car.FuelAmount;

            Assert.AreEqual(expectedAmount, actualAmount);
        }

        [Test]
        public void DriveShoudThrowInvalidOperationExceptionWhenFuelISNotEnough()
        {
            string make = "VW";
            string model = "Golf";
            double fuelConsumption = 10;
            double fuelCapacity = 200;

            Car car = new Car(make, model, fuelConsumption, fuelCapacity);

            Assert
                .Throws<InvalidOperationException>(() => car.Drive(20));
        }
    }
}
