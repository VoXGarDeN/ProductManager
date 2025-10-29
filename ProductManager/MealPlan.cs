using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows.Forms;
using System.IO;

namespace MealPlanner
{
    public class MealPlan
    {
        private Dictionary<DateTime, Recipe> plan = new Dictionary<DateTime, Recipe>();
        private ListView listView;
        private Form parentForm;

        public MealPlan(ListView listView, Form parentForm)
        {
            this.listView = listView;
            this.parentForm = parentForm;
            LoadPlan();
        }

        private void LoadPlan()
        {
            Console.WriteLine("LoadPlan() called");
            listView.Items.Clear();
            foreach (var entry in plan)
            {
                Console.WriteLine($"Adding to ListView: Date = {entry.Key}, Recipe = {entry.Value.Name}");
                ListViewItem item = new ListViewItem(new[] { entry.Key.ToString("dd.MM.yyyy"), entry.Value.Name });
                item.Tag = entry.Key;
                listView.Items.Add(item);
            }
            Console.WriteLine($"ListView item count: {listView.Items.Count}");
        }

        public void AddRecipeToPlan()
        {
            AddRecipeForm addRecipeForm = new AddRecipeForm();
            if (addRecipeForm.ShowDialog(parentForm) == DialogResult.OK)
            {
                Recipe recipe = new Recipe(
                    addRecipeForm.RecipeName,
                    addRecipeForm.RecipeDescription,
                    addRecipeForm.RecipeIngredients,
                    addRecipeForm.RecipeInstructions,
                    addRecipeForm.RecipeCalories);

                if (plan.ContainsKey(addRecipeForm.RecipeDate))
                {
                    MessageBox.Show("На эту дату рецепт уже добавлен.", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                }
                else
                {
                    plan.Add(addRecipeForm.RecipeDate, recipe);
                    LoadPlan();
                    MessageBox.Show("Рецепт добавлен в план.", "Успех", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
            }
        }

        public void RemoveRecipeFromPlan()
        {
            if (listView.SelectedItems.Count == 0)
            {
                MessageBox.Show("Сначала выберите рецепт для удаления.", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            ListViewItem selectedItem = listView.SelectedItems[0];
            DateTime date = (DateTime)selectedItem.Tag;

            if (plan.ContainsKey(date))
            {
                plan.Remove(date);
                LoadPlan();
                MessageBox.Show("Рецепт удалён.", "Успех", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            else
            {
                MessageBox.Show("Рецепт не найден.", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        public void SearchRecipeByName()
        {
            SearchRecipeForm searchForm = new SearchRecipeForm();
            if (searchForm.ShowDialog(parentForm) == DialogResult.OK)
            {
                var foundRecipe = plan.Values.FirstOrDefault(r =>
                   r.Name.ToLower().Contains(searchForm.RecipeName.ToLower()));

                if (foundRecipe != null)
                {
                    RecipeForm recipeForm = new RecipeForm();
                    recipeForm.Recipe = foundRecipe;
                    Console.WriteLine($"Found recipe: {foundRecipe.Name}, Calories: {foundRecipe.Calories}");
                    recipeForm.ShowDialog(parentForm);
                }
                else
                {
                    MessageBox.Show("Рецепт не найден.", "Информация", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
            }
        }

        public void GenerateShoppingList(DateTime startDate, DateTime endDate)
        {
            // 1. Сбор рецептов за период
            List<Recipe> recipesForPeriod = plan.Where(entry => entry.Key >= startDate && entry.Key <= endDate)
                                         .Select(entry => entry.Value)
                                         .ToList();

            // 2. Извлечение ингредиентов
            List<string> allIngredients = new List<string>();
            foreach (var recipe in recipesForPeriod)
            {
                allIngredients.AddRange(recipe.Ingredients);
            }

            // 3. Формирование списка покупок (убираем дубликаты)
            List<string> shoppingList = allIngredients.Distinct().ToList();

            // 4. Открытие формы для редактирования списка
            ShoppingListForm shoppingListForm = new ShoppingListForm(shoppingList);
            shoppingListForm.ShowDialog(parentForm);

            // 5. Получение отредактированного списка (если нужно)
            // shoppingList = shoppingListForm.GetShoppingList();
        }
    }
}
