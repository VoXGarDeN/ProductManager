using System;
using System.Windows.Forms;

namespace MealPlanner
{
    public partial class RecipeForm : Form
    {
        private Label nameLabel;
        private Label descriptionLabel;
        private Label ingredientsLabel;
        private Label instructionsLabel;
        private Label caloriesLabel;

        private TextBox nameTextBox;
        private TextBox descriptionTextBox;
        private TextBox ingredientsTextBox;
        private TextBox instructionsTextBox;
        private TextBox caloriesTextBox;

        private Recipe recipe; // Private field for the Recipe

        public Recipe Recipe
        {
            get { return recipe; }
            set
            {
                recipe = value;
                // Update the UI whenever the Recipe property is set
                UpdateUI();
            }
        }

        public RecipeForm()
        {
            InitializeComponent(); // Вызываем сгенерированный InitializeComponent!

            this.Text = "Рецепт";
            this.Width = 400;
            this.Height = 500;

            CreateControls(); // Создаем контролы

            // Call UpdateUI after the form is constructed
            UpdateUI();
        }

        private void CreateControls()
        {
            nameLabel = new Label { Text = "Название:", Location = new System.Drawing.Point(10, 10), Size = new System.Drawing.Size(70, 20) };
            descriptionLabel = new Label { Text = "Описание:", Location = new System.Drawing.Point(10, 40), Size = new System.Drawing.Size(70, 20) };
            ingredientsLabel = new Label { Text = "Ингредиенты:", Location = new System.Drawing.Point(10, 100), Size = new System.Drawing.Size(80, 20) };
            instructionsLabel = new Label { Text = "Инструкции:", Location = new System.Drawing.Point(10, 250), Size = new System.Drawing.Size(70, 20) };
            caloriesLabel = new Label { Text = "Калории:", Location = new System.Drawing.Point(10, 400), Size = new System.Drawing.Size(70, 20) };

            nameTextBox = new TextBox { Location = new System.Drawing.Point(90, 10), Size = new System.Drawing.Size(280, 20), ReadOnly = true };
            descriptionTextBox = new TextBox { Location = new System.Drawing.Point(90, 40), Size = new System.Drawing.Size(280, 50), Multiline = true, ScrollBars = ScrollBars.Vertical, ReadOnly = true };
            ingredientsTextBox = new TextBox { Location = new System.Drawing.Point(90, 100), Size = new System.Drawing.Size(280, 140), Multiline = true, ScrollBars = ScrollBars.Vertical, ReadOnly = true };
            instructionsTextBox = new TextBox { Location = new System.Drawing.Point(90, 250), Size = new System.Drawing.Size(280, 140), Multiline = true, ScrollBars = ScrollBars.Vertical, ReadOnly = true };
            caloriesTextBox = new TextBox { Location = new System.Drawing.Point(90, 400), Size = new System.Drawing.Size(100, 20), ReadOnly = true };

            Controls.Add(nameLabel);
            Controls.Add(descriptionLabel);
            Controls.Add(ingredientsLabel);
            Controls.Add(instructionsLabel);
            Controls.Add(caloriesLabel);

            Controls.Add(nameTextBox);
            Controls.Add(descriptionTextBox);
            Controls.Add(ingredientsTextBox);
            Controls.Add(instructionsTextBox);
            Controls.Add(caloriesTextBox);
        }
        private void UpdateUI()
        {
            if (Recipe != null)
            {
                nameTextBox.Text = Recipe.Name;
                descriptionTextBox.Text = Recipe.Description;
                ingredientsTextBox.Text = string.Join(Environment.NewLine, Recipe.Ingredients);
                instructionsTextBox.Text = string.Join(Environment.NewLine, Recipe.Instructions);
                caloriesTextBox.Text = Recipe.Calories.ToString();
            }
            else
            {
                // Clear the text boxes if the Recipe is null
                nameTextBox.Text = "";
                descriptionTextBox.Text = "";
                ingredientsTextBox.Text = "";
                instructionsTextBox.Text = "";
                caloriesTextBox.Text = "";
            }
        }
  
      

        private void RecipeForm_Load_1(object sender, EventArgs e)
        {

        }
    }
}
