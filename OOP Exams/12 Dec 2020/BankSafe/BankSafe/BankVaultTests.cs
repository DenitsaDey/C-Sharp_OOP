using NUnit.Framework;
using System;
using System.Linq;

namespace BankSafe.Tests
{
    public class BankVaultTests
    {
        private BankVault vault;
        private Item item;
        [SetUp]
        public void Setup()
        {
            this.vault = new BankVault();
            this.item = new Item("Deni", "id");
        }

        [Test]
        public void ConstructorShouldInitialiseADictionary()
        {
            int expectedCount = 12;

            CollectionAssert.IsNotEmpty(this.vault.VaultCells);
            Assert.AreEqual(expectedCount, this.vault.VaultCells.Count);
        }

        [Test]
        public void AddItemShouldThrowExceptionWhenCellDoesNotExist()
        {
            Assert.Throws<ArgumentException>(() => this.vault.AddItem("D1", this.item));
        }

        [Test]
        public void AddItemShouldThrowExceptionWhenCellIsTaken()
        {
            this.vault.AddItem("A1", this.item);

            Assert.Throws<ArgumentException>(() => this.vault.AddItem("A1", new Item("Pepa", "PepaId")));
        }

        [Test]
        public void AddItemShouldThrowExceptionWhenItemIsAlreadyAddedToCell()
        {
            this.vault.AddItem("A1", this.item);


            Assert.Throws<InvalidOperationException>(() => this.vault.AddItem("A2", this.item));
        }

        [Test]
        public void AddItemShouldAddUniqueItemToEmptyCell()
        {
            this.vault.AddItem("A1", this.item);
            this.vault.AddItem("A2", new Item("Pepa", "PepaId"));
            this.vault.AddItem("B2", new Item("Mira", "MiraId"));

            Assert.AreEqual("Pepa", this.vault.VaultCells["A2"].Owner);
            Assert.AreEqual("Mira", this.vault.VaultCells["B2"].Owner);
            Assert.IsNotNull(this.vault.VaultCells["A1"]);
        }

        [Test]
        public void AddItemShouldReturnStringMessageAfterSuccessfullAdding()
        {
            string expectedMessage = "Item:id saved successfully!";
            string result = this.vault.AddItem("A1", this.item);

            Assert.AreEqual(expectedMessage, result);
        }

        [Test]
        public void RemoveItemShouldThrowExceptionWhenCellDoesNotExist()
        {
            Assert.Throws<ArgumentException>(() => this.vault.RemoveItem("D1", this.item));
        }

        [Test]
        public void RemoveItemShouldThrowExceptionWhenItemDoesNotExistInCell()
        {
            this.vault.AddItem("A1", this.item);

            Assert.Throws<ArgumentException>(() => this.vault.RemoveItem("A1", new Item("Pepa", "PepaId")));
            Assert.Throws<ArgumentException>(() => this.vault.RemoveItem("A2", this.item));
        }

        [Test]
        public void RemoveItemShouldSetCellValueToNull()
        {
            this.vault.AddItem("A1", this.item);
            this.vault.RemoveItem("A1", this.item);

            Assert.AreEqual(null, this.vault.VaultCells["A1"]);
        }


        [Test]
        public void RemoveItemShouldReturnStringMessageWhenSuccessfull()
        {
            this.vault.AddItem("A1", this.item);
            string expectedMessage = "Remove item:id successfully!";
            string result = this.vault.RemoveItem("A1", this.item);

            Assert.AreEqual(expectedMessage, result);
        }
    }
}