using Microsoft.VisualStudio.TestTools.UnitTesting;
using ProductManager; // Подключение пространства имен ProductManager
using System;

namespace MealPlanner.Tests
{
    [TestClass]
    public class ProductTests
    {
        [TestMethod]
        public void ProductConstructor_ValidData_CreatesProduct()
        {
            // Arrange - подготовка тестовых данных
            string name = "Test Product";
            decimal price = 10.99m;
            int quantity = 10;

            // Act - выполнение тестируемого действия (создание продукта)
            Product product = new Product(name, price, quantity);

            // Assert - проверка результатов
            Assert.AreEqual(name, product.Name);        // Проверяем, что имя установлено корректно
            Assert.AreEqual(price, product.Price);      // Проверяем, что цена установлена корректно
            Assert.AreEqual(quantity, product.Quantity); // Проверяем, что количество установлено корректно
        }

        [TestMethod]
        public void ToString_ReturnsCorrectFormat()
        {
            // Arrange 
            Product product = new Product("Test Product", 10.99m, 10);

            // Act - выполнение тестируемого действия (вызов метода ToString)
            string result = product.ToString();

            // Assert - проверка формата строки
            Assert.AreEqual("Товар: Test Product, Цена: 10,99, Количество: 10", result);
        }

        [TestMethod]
        public void IsAvailable_QuantityGreaterThanZero_ReturnsTrue()
        {
            // Arrange - подготовка тестовых данных (продукт с количеством > 0)
            Product product = new Product("Test Product", 10.99m, 10);

            // Act - выполнение тестируемого действия (проверка доступности)
            bool result = product.IsAvailable();

            // Assert - проверка, что продукт доступен (возвращает true)
            Assert.IsTrue(result);
        }

        [TestMethod]
        public void IsAvailable_QuantityZero_ReturnsFalse()
        {
            // Arrange - подготовка тестовых данных (продукт с количеством = 0)
            Product product = new Product("Test Product", 10.99m, 0);

            // Act - выполнение тестируемого действия (проверка доступности)
            bool result = product.IsAvailable();

            // Assert - проверка, что продукт недоступен (возвращает false)
            Assert.IsFalse(result);
        }
    }
}