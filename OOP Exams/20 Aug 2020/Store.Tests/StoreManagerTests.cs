using NUnit.Framework;
using System;
using System.Linq;

namespace Store.Tests
{
    public class StoreManagerTests
    {
        private StoreManager manager;
        [SetUp]
        public void Setup()
        {
            this.manager = new StoreManager();
        }

        [Test]
        public void StoreManagerConstructorShouldInitialiseAnEmptyList()
        {
            int expectedCount = 0;

            Assert.AreEqual(expectedCount, this.manager.Count);
            CollectionAssert.IsEmpty(manager.Products);
        }

        [Test]
        public void AddProductShouldAddProductToTheCollection()
        {
            Product product = new Product("vino", 2, 5);
            this.manager.AddProduct(product);

            Assert.AreEqual(1, this.manager.Count);
        }

        [Test]
        public void AddProductShouldThrowExceptionWhenProductIsNull()
        {
            Product product = null;

            Assert.Throws<ArgumentNullException>(() => this.manager.AddProduct(product));
        }

        [Test]
        [TestCase("vino", 0, 5)]
        [TestCase("vino", -1, 5)]
        public void AddProductShouldThrowExceptionWhenProductQuantityisZeroOrBelow(string name, int quantity, decimal price)
        {
            Assert.Throws<ArgumentException>(() => this.manager.AddProduct(new Product(name, quantity, price)));
        }

        [Test]
        public void BuyProductShouldThrowExceptionWhenProductNotFound()
        {
            Product product = new Product("vino", 2, 5);
            this.manager.AddProduct(product);

            Assert.Throws<ArgumentNullException>(() => this.manager.BuyProduct("bira", 3));
        }

        [Test]
        public void BuyProductShouldThrowExceptionWhenWantedQuantityIsMoreThanAvailableQuantity()
        {
            Product product = new Product("vino", 2, 5);
            this.manager.AddProduct(product);

            Assert.Throws<ArgumentException>(() => this.manager.BuyProduct("vino", 3));
        }

        [Test]
        public void BuyProductShouldReducetheQuantityOfTheProductWithTheAmountBought()
        {
            Product product = new Product("vino", 10, 5);
            this.manager.AddProduct(product);
            int expectedAmount = 7;

            this.manager.BuyProduct("vino", 3);

            Assert.AreEqual(expectedAmount, product.Quantity);
        }

        [Test]
        public void BuyProductShouldReturnTotalPriceForBoughtProducts()
        {
            Product product = new Product("vino", 10, 5);
            this.manager.AddProduct(product);
            decimal expectedFinalPrice = 15;           

            Assert.AreEqual(expectedFinalPrice, this.manager.BuyProduct("vino", 3));
        }

        [Test]
        public void GetMostExpensiveProductShouldReturnProductWithHighestPrice()
        {
            Product product = new Product("vino", 10, 5);
            Product product2 = new Product("bira", 10, 3);
            Product product3 = new Product("whiskey", 10, 15);

            this.manager.AddProduct(product);
            this.manager.AddProduct(product2);
            this.manager.AddProduct(product3);

            var mostExpensive = this.manager.GetTheMostExpensiveProduct();
            var expectedProduct = product3;

            Assert.AreEqual(expectedProduct, mostExpensive);
        }
    }
}