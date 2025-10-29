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

            // Act
            Recipe recipe = new Recipe(name, description, ingredients, instructions, calories);

            // Assert
            Assert.AreEqual(name, recipe.Name);
            Assert.AreEqual(description, recipe.Description);
            CollectionAssert.AreEqual(ingredients, recipe.Ingredients);
            CollectionAssert.AreEqual(instructions, recipe.Instructions);
            Assert.AreEqual(calories, recipe.Calories);
        }

        [TestMethod]
        public void ToString_ReturnsRecipeName()
        {
            // Arrange
            Recipe recipe = new Recipe("Test Recipe", "Test Description", new List<string>(), new List<string>(), 500);

            // Act
            string result = recipe.ToString();

            // Assert
            Assert.AreEqual("Test Recipe", result);
        }
    }
}
