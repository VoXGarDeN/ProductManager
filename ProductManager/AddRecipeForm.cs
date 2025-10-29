// AddRecipeForm.cs
using System;
using System.Collections.Generic;
using System.Windows.Forms;

namespace MealPlanner
{
    public partial class AddRecipeForm : Form
    {
        public string RecipeName { get; set; }
        public string RecipeDescription { get; set; }
        public List<string> RecipeIngredients { get; set; }
        public List<string> RecipeInstructions { get; set; }
        public int RecipeCalories { get; set; }
        public DateTime RecipeDate { get; set; }

        public TextBox nameTextBox;
        public TextBox descriptionTextBox;
        private TextBox ingredientsTextBox;
        private TextBox instructionsTextBox;
        public NumericUpDown caloriesNumericUpDown;
        public DateTimePicker datePicker;
        private Button okButton;
        private Button cancelButton;

        public AddRecipeForm()
        {
            InitializeComponent();
            this.Text = "Добавить рецепт";
            this.Width = 400;
            this.Height = 450;

            CreateControls();
        }

        private void CreateControls()
        {
            // Labels
            Label nameLabel = new Label { Text = "Название:", Location = new System.Drawing.Point(10, 10), Size = new System.Drawing.Size(70, 20) };
            Label descriptionLabel = new Label { Text = "Описание:", Location = new System.Drawing.Point(10, 40), Size = new System.Drawing.Size(70, 20) };
            Label ingredientsLabel = new Label { Text = "Ингредиенты:", Location = new System.Drawing.Point(10, 100), Size = new System.Drawing.Size(80, 20) };
            Label instructionsLabel = new Label { Text = "Инструкции:", Location = new System.Drawing.Point(10, 190), Size = new System.Drawing.Size(70, 20) };
            Label caloriesLabel = new Label { Text = "Калории:", Location = new System.Drawing.Point(10, 280), Size = new System.Drawing.Size(70, 20) };
            Label dateLabel = new Label { Text = "Дата:", Location = new System.Drawing.Point(10, 310), Size = new System.Drawing.Size(70, 20) };

            // Input controls
            nameTextBox = new TextBox { Location = new System.Drawing.Point(100, 10), Size = new System.Drawing.Size(280, 20) };
            descriptionTextBox = new TextBox { Location = new System.Drawing.Point(100, 40), Size = new System.Drawing.Size(280, 50), Multiline = true, ScrollBars = ScrollBars.Vertical };
            ingredientsTextBox = new TextBox { Location = new System.Drawing.Point(100, 100), Size = new System.Drawing.Size(280, 80), Multiline = true, ScrollBars = ScrollBars.Vertical };
            instructionsTextBox = new TextBox { Location = new System.Drawing.Point(100, 190), Size = new System.Drawing.Size(280, 80), Multiline = true, ScrollBars = ScrollBars.Vertical };
            caloriesNumericUpDown = new NumericUpDown { Location = new System.Drawing.Point(100, 280), Size = new System.Drawing.Size(100, 20), Maximum = 10000, Minimum = 0 };
            datePicker = new DateTimePicker { Location = new System.Drawing.Point(100, 310), Size = new System.Drawing.Size(150, 20) };

            // Buttons
            okButton = new Button { Text = "OK", Location = new System.Drawing.Point(220, 350), Size = new System.Drawing.Size(75, 25) };
            okButton.Click += OkButton_Click;
            cancelButton = new Button { Text = "Отмена", Location = new System.Drawing.Point(300, 350), Size = new System.Drawing.Size(75, 25) };
            cancelButton.Click += CancelButton_Click;

            // Add controls to the form
            Controls.Add(nameLabel);
            Controls.Add(descriptionLabel);
            Controls.Add(ingredientsLabel);
            Controls.Add(instructionsLabel);
            Controls.Add(caloriesLabel);
            Controls.Add(dateLabel);

            Controls.Add(nameTextBox);
            Controls.Add(descriptionTextBox);
            Controls.Add(ingredientsTextBox);
            Controls.Add(instructionsTextBox);
            Controls.Add(caloriesNumericUpDown);
            Controls.Add(datePicker);

            Controls.Add(okButton);
            Controls.Add(cancelButton);
        }

        private void OkButton_Click(object sender, EventArgs e)
        {
            // **VALIDATION**
            if (string.IsNullOrWhiteSpace(nameTextBox.Text))
            {
                MessageBox.Show("Название рецепта не может быть пустым.", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return; // Stop processing
            }

            RecipeName = nameTextBox.Text;
            RecipeDescription = descriptionTextBox.Text;
            RecipeIngredients = new List<string>(ingredientsTextBox.Text.Split(new string[] { Environment.NewLine }, StringSplitOptions.RemoveEmptyEntries));
            RecipeInstructions = new List<string>(instructionsTextBox.Text.Split(new string[] { Environment.NewLine }, StringSplitOptions.RemoveEmptyEntries));

            RecipeCalories = (int)caloriesNumericUpDown.Value;
            RecipeDate = datePicker.Value;

            this.DialogResult = DialogResult.OK;
            this.Close();
        }

        private void CancelButton_Click(object sender, EventArgs e)
        {
            this.DialogResult = DialogResult.Cancel;
            this.Close();
        }

        private void AddRecipeForm_Load(object sender, EventArgs e)
        {
        }
    }
}
