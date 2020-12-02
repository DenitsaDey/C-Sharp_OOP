namespace Computers.Tests
{
    using NUnit.Framework;
    using System;
    using System.Collections.Generic;

    public class ComputerTests
    {
        private Part part;
        //private ICollection<Part> parts;
        private Computer computer;

        [SetUp]
        public void Setup()
        {
            this.part = new Part("keyA", 5.5m);
            //this.parts = new List<Part> { new Part("key1", 5.5m), new Part("key2", 4.7m)};
            this.computer = new Computer("Nasko");
        }

        [Test]
        public void PartConstructorShouldInitialisePartCorrectly()
        {
            string expectedName = "keyA";
            decimal expectedPrice = 5.5m;

            Assert.AreEqual(expectedName, this.part.Name);
            Assert.AreEqual(expectedPrice, this.part.Price);
      
        }

        [Test]
        public void ComputerConstructorShouldInitialiseComputerCorrectly()
        {
            string expectedName = "Nasko";
            int expectedPartCount = 0;


            Assert.AreEqual(expectedName, this.computer.Name);
            Assert.AreEqual(expectedPartCount, this.computer.Parts.Count);
        }

        [Test]
        [TestCase ("")]
        [TestCase (" ")]
        public void NameWhenNullOrWhiteSpaceShouldThrowException(string name)
        {
            Assert.Throws<ArgumentNullException>(() => new Computer(name));
        }

        [Test]
        public void AddPartShouldAddNewPartToTheComputer()
        {
            this.computer.AddPart(this.part);

            Assert.AreEqual(1, this.computer.Parts.Count);
        }

        [Test]
        public void AddPartShouldThrowExceptionWhenPartIsNull()
        {
            Part part = null;
            Assert.Throws<InvalidOperationException>(() => this.computer.AddPart(part));
        }
        
        [Test]
        public void TotalPriceShouldGiveTheSumOfAllPartsPrices()
        {
            this.computer.AddPart(new Part("key1", 4.4m));
            this.computer.AddPart(new Part("key2", 5.5m));
            decimal expectedSum = 9.9m;

            Assert.AreEqual(expectedSum, this.computer.TotalPrice);
        }

        [Test]
        public void RemovePartShouldReturnTrueWhenAPartISremoved()
        {
            Part partA = new Part("A", 1);
            Part partB = new Part("B", 2);
            this.computer.AddPart(partA);
            this.computer.AddPart(partB);

            Assert.AreEqual(true, this.computer.RemovePart(partA));

        }

        [Test]
        public void GetPartShouldReturnPartWithTheGivenName()
        {
            Part partA = new Part("A", 1);
            Part partB = new Part("B", 2);
            this.computer.AddPart(partA);
            this.computer.AddPart(partB);

            Assert.AreEqual(partA, this.computer.GetPart("A"));
        }
    }
}