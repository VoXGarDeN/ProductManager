using Microsoft.VisualStudio.TestTools.UnitTesting;
using ProductManager; // Make sure to reference the ProductManager project
using System;

namespace MealPlanner.Tests
{
    [TestClass]
    public class ProductTests
    {
        [TestMethod]
        public void ProductConstructor_ValidData_CreatesProduct()
        {
            // Arrange
            string name = "Test Product";
            decimal price = 10.99m;
            int quantity = 10;

            // Act
            Product product = new Product(name, price, quantity);

            // Assert
            Assert.AreEqual(name, product.Name);
            Assert.AreEqual(price, product.Price);
            Assert.AreEqual(quantity, product.Quantity);
        }

        [TestMethod]
        public void ToString_ReturnsCorrectFormat()
        {
            // Arrange
            Product product = new Product("Test Product", 10.99m, 10);

            // Act
            string result = product.ToString();

            // Assert
            Assert.AreEqual("Товар: Test Product, Цена: 10,99, Количество: 10", result);
        }

        [TestMethod]
        public void IsAvailable_QuantityGreaterThanZero_ReturnsTrue()
        {
            // Arrange
            Product product = new Product("Test Product", 10.99m, 10);

            // Act
            bool result = product.IsAvailable();

            // Assert
            Assert.IsTrue(result);
        }

        [TestMethod]
        public void IsAvailable_QuantityZero_ReturnsFalse()
        {
            // Arrange
            Product product = new Product("Test Product", 10.99m, 0);

            // Act
            bool result = product.IsAvailable();

            // Assert
            Assert.IsFalse(result);
        }
    }
}
