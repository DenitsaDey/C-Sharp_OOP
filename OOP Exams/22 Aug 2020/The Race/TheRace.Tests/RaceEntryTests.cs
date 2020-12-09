using NUnit.Framework;
using System;
using TheRace;

namespace TheRace.Tests
{
    public class RaceEntryTests
    {
        private RaceEntry raceEntry;
        [SetUp]
        public void Setup()
        {
            this.raceEntry = new RaceEntry();
        }

        [Test]
        public void RaceEntryConstructorShouldInitializeAnEmptyDictionary()
        {
            int expectedCount = 0;

            Assert.AreEqual(expectedCount, this.raceEntry.Counter);
        }

        [Test]
        public void CounterShouldReflectTheNumberOfDriversInTheDictionary()
        {
            this.raceEntry.AddDriver(new UnitDriver("Gosho", new UnitCar("Toyota", 100, 250)));
            this.raceEntry.AddDriver(new UnitDriver("Pesho", new UnitCar("Nissan", 150, 300)));

            int expectedCount = 2;

            Assert.AreEqual(expectedCount, this.raceEntry.Counter);

        }

        [Test]
        public void AddDriverShouldThrowExceptionWhnDriverIsNull()
        {
            UnitDriver driver = null;

            Assert.Throws<InvalidOperationException>(() => this.raceEntry.AddDriver(driver));
        }

        [Test]
        public void AddDriverShouldThrowExceptionWhenDriverWithSameNameIsAdded()
        {
            this.raceEntry.AddDriver(new UnitDriver("Gosho", new UnitCar("Toyota", 100, 250)));

            Assert.Throws<InvalidOperationException>(() => this.raceEntry.AddDriver(new UnitDriver("Gosho", new UnitCar("Nissan", 150, 300))));
        }

        [Test]
        public void AddDriverShouldReturnStringWhenNewDriverIsAdded()
        {
            string expectedResult = "Driver Gosho added in race.";

            Assert.AreEqual(expectedResult, this.raceEntry.AddDriver(new UnitDriver("Gosho", new UnitCar("Toyota", 100, 250))));
        }

        [Test]
        public void CalculateAverageHorsePowerShouldThrowExceptionWhenNotEnoughRacers()
        {
            this.raceEntry.AddDriver(new UnitDriver("Gosho", new UnitCar("Toyota", 100, 250)));

            Assert.Throws<InvalidOperationException>(() => this.raceEntry.CalculateAverageHorsePower());
        }

        [Test]
        public void CalculateAverageHorsePowerShouldReturnCorrectDouble()
        {
            this.raceEntry.AddDriver(new UnitDriver("Gosho", new UnitCar("Toyota", 100, 250)));
            this.raceEntry.AddDriver(new UnitDriver("Pesho", new UnitCar("Nissan", 150, 300)));

            double expectedAverage = 125;

            Assert.AreEqual(expectedAverage, this.raceEntry.CalculateAverageHorsePower());
        }
    }
}