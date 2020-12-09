using NUnit.Framework;
using System;
using System.Linq;

namespace Computers.Tests
{
    public class Tests
    {
        private ComputerManager manager;
        [SetUp]
        public void Setup()
        {
            this.manager = new ComputerManager();
        }

        [Test]
        public void ComputerManagerConstructorShouldInitialiseAnEmptyList()
        {
            int expectedCount = 0;

            Assert.AreEqual(expectedCount, this.manager.Count);
            CollectionAssert.IsEmpty(this.manager.Computers);
        }

        [Test]
        public void CountShouldReflectTheNumberofComputersInTheCollection()
        {
            Computer c1 = new Computer("Nasko", "first", 100);
            Computer c2 = new Computer("Valkata", "The best", 1000);

            this.manager.AddComputer(c1);
            this.manager.AddComputer(c2);

            Assert.AreEqual(2, this.manager.Count);
        }

        [Test]
        public void AddComputerShouldThrowExceptionWhenAddedComputerisNull()
        {
            Computer c1 = null;

            Assert.Throws<ArgumentNullException>(() => this.manager.AddComputer(c1));
        }

        [Test]
        public void AddComputerShouldThrowExceptionWhenAComputerWithSameManufacturerAndNameIsAdded()
        {
            Computer c1 = new Computer("Nasko", "first", 100);
            Computer c2 = new Computer("Nasko", "first", 1000);

            this.manager.AddComputer(c1);

            Assert.Throws<ArgumentException>(() => this.manager.AddComputer(c2));
        }

        [Test]
        public void AddComputerShouldAddNewComputerToTheCollection()
        {
            Computer c1 = new Computer("Nasko", "first", 100);

            this.manager.AddComputer(c1);

            CollectionAssert.IsNotEmpty(this.manager.Computers);
            Assert.AreEqual(1, this.manager.Count);
        }

        [Test]
        public void RemoveComputerShouldReturnRemovedComputer()
        {
            Computer c1 = new Computer("Nasko", "first", 100);
            Computer c2 = new Computer("Valkata", "The best", 1000);

            this.manager.AddComputer(c1);
            this.manager.AddComputer(c2);
            var removedComp = this.manager.RemoveComputer("Nasko", "first");

            Assert.AreEqual(c1, removedComp);
        }

        [Test]
        public void RemoveComputerShouldRemoveItFromCollection()
        {
            Computer c1 = new Computer("Nasko", "first", 100);

            this.manager.AddComputer(c1);
            var removedComp = this.manager.RemoveComputer("Nasko", "first");

            CollectionAssert.IsEmpty(this.manager.Computers);
        }

        [Test]
        [TestCase(null, "first")]
        [TestCase("Nasko", null)]
        [TestCase(null, null)]
        public void RemoveComputerShouldThrowExceptionWhenManufacturerOrModelAreNull(string manufacturer, string model)
        {
            Computer c1 = new Computer("Nasko", "first", 100);

            this.manager.AddComputer(c1);

            Assert.Throws<ArgumentNullException>(() => this.manager.RemoveComputer(manufacturer, model));
        }

        [Test]
        [TestCase(null, "first")]
        [TestCase("Nasko", null)]
        [TestCase(null, null)]
        public void GetComputerShouldThrowExceptionWhenManufacturerOrModelAreNull(string manufacturer, string model)
        {
            Computer c1 = new Computer("Nasko", "first", 100);

            this.manager.AddComputer(c1);

            Assert.Throws<ArgumentNullException>(() => this.manager.GetComputer(manufacturer, model));
        }

        [Test]
        public void GetComputerShouldThrowExceptionWhenComputerIsNotFound()
        {

            Computer c1 = new Computer("Nasko", "first", 100);
            Computer c2 = new Computer("Valkata", "The best", 1000);

            this.manager.AddComputer(c1);

            Assert.Throws<ArgumentException>(() => this.manager.GetComputer(c2.Manufacturer, c2.Model));
        }

        [Test]
        public void GetComputerShouldReturnWantedComputer()
        {

            Computer c1 = new Computer("Nasko", "first", 100);
            Computer c2 = new Computer("Valkata", "The best", 1000);

            this.manager.AddComputer(c1);
            this.manager.AddComputer(c2);

            var wantedComp = this.manager.GetComputer("Valkata", "The best");

            Assert.AreEqual(c2.Manufacturer, wantedComp.Manufacturer);
            Assert.AreEqual(c2.Model, wantedComp.Model);
        }

        [Test]
        public void GetComputerByManufacturerShouldThrowExceptionIfManufacturerIsNull()
        {
            Assert.Throws<ArgumentNullException>(() => this.manager.GetComputersByManufacturer(null));
        }

        [Test]
        public void GetComputerByManufacturerShouldReturnACollectionOfComputers()
        {
            Computer c1 = new Computer("Nasko", "first", 100);
            Computer c2 = new Computer("Nasko", "second", 100);
            Computer c3 = new Computer("Valkata", "The best", 1000);

            this.manager.AddComputer(c1);
            this.manager.AddComputer(c2);
            this.manager.AddComputer(c3);

            var collection = this.manager.GetComputersByManufacturer("Nasko").ToList();

            CollectionAssert.IsNotEmpty(collection);
            Assert.AreEqual(2, collection.Count);
        }

        [Test]
        public void GetComputersByManufacturerShouldReturnEmptyCollectionWhenNoMatchesFound()
        {
            Computer c1 = new Computer("Nasko", "first", 100);
            Computer c2 = new Computer("Valkata", "The best", 1000);

            this.manager.AddComputer(c1);
            this.manager.AddComputer(c2);

            var collection = this.manager.GetComputersByManufacturer("Asus").ToList();

            CollectionAssert.IsEmpty(collection);
        }
    }
}