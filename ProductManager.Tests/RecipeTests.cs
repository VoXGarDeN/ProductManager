using Microsoft.VisualStudio.TestTools.UnitTesting;
using MealPlanner;
using System.Collections.Generic;

namespace MealPlanner.Tests
{
    [TestClass]
    public class RecipeTests
    {
        [TestMethod]
        public void RecipeConstructor_ValidData_CreatesRecipe()
        {
            // Arrange
            string name = "Test Recipe";
            string description = "Test Description";
            List<string> ingredients = new List<string> { "Ingredient 1", "Ingredient 2" };
            List<string> instructions = new List<string> { "Step 1", "Step 2" };
            int calories = 500;

            // Act выполнение тестируемого действия (создание объекта Recipe)
            Recipe recipe = new Recipe(name, description, ingredients, instructions, calories);

            // проверка, что все свойства рецепта установлены корректно
            Assert.AreEqual(name, recipe.Name);                    // Проверка названия рецепта
            Assert.AreEqual(description, recipe.Description);      // Проверка описания рецепта
            CollectionAssert.AreEqual(ingredients, recipe.Ingredients);  // Проверка списка ингредиентов
            CollectionAssert.AreEqual(instructions, recipe.Instructions); // Проверка списка инструкций
            Assert.AreEqual(calories, recipe.Calories);            // Проверка калорийности
        }

        [TestMethod]
        public void ToString_ReturnsRecipeName()
        {
            // Arrange
            Recipe recipe = new Recipe("Test Recipe", "Test Description", new List<string>(), new List<string>(), 500);

            // вызов метода ToString()
            string result = recipe.ToString();

            // проверка, что метод возвращает только название рецепта
            Assert.AreEqual("Test Recipe", result);
        }
    }
}