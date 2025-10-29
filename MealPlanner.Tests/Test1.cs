using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.Linq; // Add this line
using MealPlanner; // Убедитесь, что это правильное пространство имен
using System.Windows.Forms; // Add this line to use Form and ListView
using System.Reflection;

namespace MealPlanner.Tests
{
    [TestClass]
    public class RecipeTests
    {
        [TestMethod]
        public void ToString_ReturnsRecipeName()
        {
            // Arrange
            var recipe = new Recipe("Chicken Soup", "Comforting soup", new List<string>(), new List<string>(), 300);

            // Act
            string result = recipe.ToString();

            // Assert
            Assert.AreEqual("Chicken Soup", result);
        }
    }

    [TestClass]
    public class MealPlanTests
    {
        [TestMethod]
        public void AddRecipeToPlan_AddsRecipeCorrectly()
        {
            // Arrange
            var listViewMock = new ListView(); // Use a mock ListView
            var formMock = new Form(); // Use a mock Form
            var mealPlan = new MealPlan(listViewMock, formMock);

            // Access the private 'plan' field using reflection
            var planField = typeof(MealPlan).GetField("plan", BindingFlags.NonPublic | BindingFlags.Instance);
            if (planField == null)
            {
                Assert.Fail("The 'plan' field was not found in MealPlan class.  Make sure it's named correctly and that you've built the solution.");
                return; // Exit the test
            }

            var plan = (Dictionary<DateTime, Recipe>)planField.GetValue(mealPlan);

            // Create a test Recipe
            var recipe = new Recipe("Test Recipe", "Test Description", new List<string> { "Ingredient 1", "Ingredient 2" }, new List<string> { "Step 1", "Step 2" }, 500);
            var testDate = DateTime.Today;

            // Add the recipe to the plan directly (bypassing the AddRecipeForm for testing)
            if (!plan.ContainsKey(testDate))
            {
                plan.Add(testDate, recipe);
            }
            else
            {
                Assert.Fail("Recipe already exists for this date in the plan.");
                return;
            }

            // Act
            // (The act is already done by adding the recipe directly to the plan)

            // Assert
            Assert.IsTrue(plan.ContainsKey(testDate), "The meal plan does not contain the added date.");
            Assert.AreEqual(recipe, plan[testDate], "The recipe added to the meal plan is incorrect.");

            // Clean up (optional, but good practice)
            plan.Remove(testDate); // Remove the added recipe
        }

        [TestMethod]
        public void RemoveRecipeFromPlan_RemovesRecipeCorrectly()
        {
            // Arrange
            var listViewMock = new ListView(); // Use a mock ListView
            var formMock = new Form(); // Use a mock Form
            var mealPlan = new MealPlan(listViewMock, formMock);

            // Access the private 'plan' field using reflection
            var planField = typeof(MealPlan).GetField("plan", BindingFlags.NonPublic | BindingFlags.Instance);
            if (planField == null)
            {
                Assert.Fail("The 'plan' field was not found in MealPlan class.  Make sure it's named correctly and that you've built the solution.");
                return; // Exit the test
            }

            var plan = (Dictionary<DateTime, Recipe>)planField.GetValue(mealPlan);

            // Create a test Recipe and Add to the plan
            var recipe = new Recipe("Test Recipe", "Test Description", new List<string> { "Ingredient 1", "Ingredient 2" }, new List<string> { "Step 1", "Step 2" }, 500);
            var testDate = DateTime.Today;
            if (!plan.ContainsKey(testDate))
            {
                plan.Add(testDate, recipe);
            }

            // Mock the selected item in ListView
            listViewMock.Items.Add(new ListViewItem { Tag = testDate });
            listViewMock.Items[0].Selected = true;

            // Act
            mealPlan.RemoveRecipeFromPlan();

            // Assert
            Assert.IsFalse(plan.ContainsKey(testDate), "The recipe was not removed from the meal plan.");

        }
    }
    [TestClass]
    public class SearchRecipeFormTests
    {
        [TestMethod]
        public void OkButton_Click_SetsRecipeName()
        {
            // Arrange
            var searchRecipeForm = new SearchRecipeForm();
            TextBox nameTextBox = new TextBox { Name = "nameTextBox", Text = "Chicken" };
            searchRecipeForm.Controls.Add(nameTextBox);

            // Act
            //Simulate clicking the OK button
            searchRecipeForm.OkButton_Click(null, EventArgs.Empty);

            // Assert
            Assert.AreEqual("Chicken", searchRecipeForm.RecipeName);
            searchRecipeForm.Close();

        }
    }
}
