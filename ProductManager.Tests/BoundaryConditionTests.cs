using MealPlanner;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Windows.Forms;

namespace MealPlanner.Tests
{
    [TestClass]
    public class BoundaryConditionTests
    {
        [TestMethod]
        public void AddRecipeForm_Calories_MinimumValueAllowed()
        {
            using (AddRecipeForm form = new AddRecipeForm())
            {
                form.caloriesNumericUpDown.Value = form.caloriesNumericUpDown.Minimum;
                Assert.AreEqual(form.caloriesNumericUpDown.Minimum, form.caloriesNumericUpDown.Value);
            }
        }

        [TestMethod]
        public void AddRecipeForm_Calories_MaximumValueAllowed()
        {
            using (AddRecipeForm form = new AddRecipeForm())
            {
                form.caloriesNumericUpDown.Value = form.caloriesNumericUpDown.Maximum;
                Assert.AreEqual(form.caloriesNumericUpDown.Maximum, form.caloriesNumericUpDown.Value);
            }
        }

        [TestMethod]
        public void AddRecipeForm_Calories_ValueGreaterThanMaximumThrowsException()
        {
            using (AddRecipeForm form = new AddRecipeForm())
            {
                Assert.ThrowsException<ArgumentOutOfRangeException>(() => form.caloriesNumericUpDown.Value = form.caloriesNumericUpDown.Maximum + 1, "Ожидалось исключение ArgumentOutOfRangeException");
            }
        }

        [TestMethod]
        public void AddRecipeForm_Calories_ValueLessThanMinimumThrowsException()
        {
            using (AddRecipeForm form = new AddRecipeForm())
            {
                Assert.ThrowsException<ArgumentOutOfRangeException>(() => form.caloriesNumericUpDown.Value = form.caloriesNumericUpDown.Minimum - 1, "Ожидалось исключение ArgumentOutOfRangeException");
            }
        }

        [TestMethod]
        public void AddRecipeForm_RecipeName_EmptyStringAllowed()
        {
            using (AddRecipeForm form = new AddRecipeForm())
            {
                form.nameTextBox.Text = "";
                Assert.AreEqual("", form.nameTextBox.Text);
            }
        }

        [TestMethod]
        public void AddRecipeForm_RecipeDescription_LongStringAllowed()
        {
            using (AddRecipeForm form = new AddRecipeForm())
            {
                string longString = new string('A', 5000);
                form.descriptionTextBox.Text = longString;
                Assert.AreEqual(longString, form.descriptionTextBox.Text);
            }
        }

        [TestMethod]
        public void AddRecipeForm_Date_MinimumDateAllowed()
        {
            using (AddRecipeForm form = new AddRecipeForm())
            {
                form.datePicker.Value = DateTimePicker.MinimumDateTime;
                Assert.AreEqual(DateTimePicker.MinimumDateTime, form.datePicker.Value);
            }
        }

        [TestMethod]
        public void AddRecipeForm_Date_MaximumDateAllowed()
        {
            using (AddRecipeForm form = new AddRecipeForm())
            {
                form.datePicker.Value = DateTimePicker.MaximumDateTime;
                Assert.AreEqual(DateTimePicker.MaximumDateTime, form.datePicker.Value);
            }
        }
    }
}
