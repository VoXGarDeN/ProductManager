using System;
using System.Collections.Generic;
using System.Windows.Forms;

namespace MealPlanner
{
    public partial class ShoppingListForm : Form
    {
        private List<string> shoppingList;

        public ShoppingListForm(List<string> initialList)
        {
            InitializeComponent();
            shoppingList = new List<string>(initialList); // Копируем список
            UpdateShoppingListBox();
        }

        private void AddIngredientButton_Click(object sender, EventArgs e)
        {
            string newIngredient = newIngredientTextBox.Text.Trim();
            if (!string.IsNullOrEmpty(newIngredient))
            {
                shoppingList.Add(newIngredient);
                UpdateShoppingListBox();
                newIngredientTextBox.Clear();
            }
        }

        private void RemoveIngredientButton_Click(object sender, EventArgs e)
        {
            if (shoppingListBox.SelectedIndex >= 0)
            {
                shoppingList.RemoveAt(shoppingListBox.SelectedIndex);
                UpdateShoppingListBox();
            }
        }

        private void SaveButton_Click(object sender, EventArgs e)
        {
            //TODO: Реализовать сохранение списка покупок (например, в файл)
            SaveFileDialog saveFileDialog = new SaveFileDialog();
            saveFileDialog.Filter = "Text files (*.txt)|*.txt|All files (*.*)|*.*";
            saveFileDialog.Title = "Сохранить список покупок";

            if (saveFileDialog.ShowDialog() == DialogResult.OK)
            {
                try
                {
                    System.IO.File.WriteAllLines(saveFileDialog.FileName, shoppingList);
                    MessageBox.Show("Список покупок успешно сохранен!", "Успех", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                catch (Exception ex)
                {
                    MessageBox.Show($"Ошибка при сохранении файла: {ex.Message}", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

        private void CloseButton_Click(object sender, EventArgs e)
        {
            this.DialogResult = DialogResult.OK;
            this.Close();
        }

        private void UpdateShoppingListBox()
        {
            shoppingListBox.Items.Clear();
            foreach (string ingredient in shoppingList)
            {
                shoppingListBox.Items.Add(ingredient);
            }
        }

        public List<string> GetShoppingList()
        {
            return shoppingList;
        }

        private void ShoppingListForm_Load(object sender, EventArgs e)
        {
        }
    }
}
