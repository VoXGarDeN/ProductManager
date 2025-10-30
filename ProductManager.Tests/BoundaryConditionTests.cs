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
            // тест проверяет, что минимальное значение калорий корректно устанавливается
            using (AddRecipeForm form = new AddRecipeForm())
            {
                // Устанавливаем минимальное значение в NumericUpDown для калорий
                form.caloriesNumericUpDown.Value = form.caloriesNumericUpDown.Minimum;
                // Проверяем, что значение установилось корректно
                Assert.AreEqual(form.caloriesNumericUpDown.Minimum, form.caloriesNumericUpDown.Value);
            }
        }

        [TestMethod]
        public void AddRecipeForm_Calories_MaximumValueAllowed()
        {
            // Тест проверяет, что максимальное значение калорий корректно устанавливается
            using (AddRecipeForm form = new AddRecipeForm())
            {
                // Устанавливаем максимальное значение в NumericUpDown для калорий
                form.caloriesNumericUpDown.Value = form.caloriesNumericUpDown.Maximum;
                // Проверяем, что значение установилось корректно
                Assert.AreEqual(form.caloriesNumericUpDown.Maximum, form.caloriesNumericUpDown.Value);
            }
        }

        [TestMethod]
        public void AddRecipeForm_Calories_ValueGreaterThanMaximumThrowsException()
        {
            // Тест проверяет, что попытка установить значение больше максимального вызывает исключение
            using (AddRecipeForm form = new AddRecipeForm())
            {
                // Проверка, что при установке значения больше максимального выбрасывается ArgumentOutOfRangeException
                Assert.ThrowsException<ArgumentOutOfRangeException>(
                    () => form.caloriesNumericUpDown.Value = form.caloriesNumericUpDown.Maximum + 1,
                    "Ожидалось исключение ArgumentOutOfRangeException");
            }
        }

        [TestMethod]
        public void AddRecipeForm_Calories_ValueLessThanMinimumThrowsException()
        {
            // Тест проверяет, что попытка установить значение меньше минимального вызывает исключение
            using (AddRecipeForm form = new AddRecipeForm())
            {
                // Проверка, что при установке значения меньше минимального выбрасывается ArgumentOutOfRangeException
                Assert.ThrowsException<ArgumentOutOfRangeException>(
                    () => form.caloriesNumericUpDown.Value = form.caloriesNumericUpDown.Minimum - 1,
                    "Ожидалось исключение ArgumentOutOfRangeException");
            }
        }

        [TestMethod]
        public void AddRecipeForm_RecipeName_EmptyStringAllowed()
        {
            // Тест проверяет, что поле названия рецепта может быть пустым
            using (AddRecipeForm form = new AddRecipeForm())
            {
                // Устанавливаем пустую строку в текстовое поле названия
                form.nameTextBox.Text = "";
                // Проверка, что пустая строка сохраняется корректно
                Assert.AreEqual("", form.nameTextBox.Text);
            }
        }

        [TestMethod]
        public void AddRecipeForm_RecipeDescription_LongStringAllowed()
        {
            // Тест проверяет, что поле описания рецепта принимает длинные строки
            using (AddRecipeForm form = new AddRecipeForm())
            {
                // Создаем очень длинную строку (5000 символов 'A')
                string longString = new string('A', 5000);
                // Устанавливаем длинную строку в текстовое поле описания
                form.descriptionTextBox.Text = longString;
                // Проверка, что длинная строка сохраняется полностью
                Assert.AreEqual(longString, form.descriptionTextBox.Text);
            }
        }

        [TestMethod]
        public void AddRecipeForm_Date_MinimumDateAllowed()
        {
            // Тест проверяет, что можно установить минимальную допустимую дату
            using (AddRecipeForm form = new AddRecipeForm())
            {
                // Устанавливаем минимальную дату из DateTimePicker
                form.datePicker.Value = DateTimePicker.MinimumDateTime;
                // Проверка, что минимальная дата установилась корректно
                Assert.AreEqual(DateTimePicker.MinimumDateTime, form.datePicker.Value);
            }
        }

        [TestMethod]
        public void AddRecipeForm_Date_MaximumDateAllowed()
        {
            // Тест проверяет, что можно установить максимальную допустимую дату
            using (AddRecipeForm form = new AddRecipeForm())
            {
                // Устанавливаем максимальную дату из DateTimePicker
                form.datePicker.Value = DateTimePicker.MaximumDateTime;
                // Проверка, что максимальная дата установилась корректно
                Assert.AreEqual(DateTimePicker.MaximumDateTime, form.datePicker.Value);
            }
        }
    }
}