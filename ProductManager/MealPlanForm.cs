using System;
using System.Windows.Forms;

namespace MealPlanner
{
    public partial class MealPlanForm : Form
    {
        private MealPlan mealPlan;
        private System.Windows.Forms.ListView listView;
        private DateTimePicker startDatePicker;
        private DateTimePicker endDatePicker;

        public MealPlanForm()
        {

            this.Text = "Планирование меню";
            this.Width = 400;
            this.Height = 400;

            InitializeListView(); // Инициализация listView
            mealPlan = new MealPlan(listView, this);

            startDatePicker.Value = new DateTime(2025, 10, 5); // 5 октября 2025
            endDatePicker.Value = new DateTime(2025, 10, 12); // 12 октября 2025 (например, неделя после начальной даты)
        }

        private void InitializeListView()
        {
            listView = new ListView();
            listView.Location = new System.Drawing.Point(10, 10);
            listView.Size = new System.Drawing.Size(370, 250);
            listView.View = View.Details;
            listView.Columns.Add("Дата", 100);
            listView.Columns.Add("Рецепт", 250);

            Controls.Add(listView);

            Button addRecipeButton = new Button { Text = "Добавить рецепт", Location = new System.Drawing.Point(10, 270), Size = new System.Drawing.Size(120, 25) };
            addRecipeButton.Click += addRecipeButton_Click;
            Controls.Add(addRecipeButton);

            Button removeRecipeButton = new Button { Text = "Удалить рецепт", Location = new System.Drawing.Point(140, 270), Size = new System.Drawing.Size(120, 25) };
            removeRecipeButton.Click += removeRecipeButton_Click;
            Controls.Add(removeRecipeButton);

            Button searchRecipeButton = new Button { Text = "Найти рецепт", Location = new System.Drawing.Point(270, 270), Size = new System.Drawing.Size(100, 25) };
            searchRecipeButton.Click += searchRecipeButton_Click;
            Controls.Add(searchRecipeButton);

            Label startDateLabel = new Label { Text = "Начальная дата:", Location = new System.Drawing.Point(200, 300), Size = new System.Drawing.Size(90, 20) };
            Controls.Add(startDateLabel);

            startDatePicker = new DateTimePicker { Location = new System.Drawing.Point(290, 300), Size = new System.Drawing.Size(100, 25) };
            Controls.Add(startDatePicker);

            Label endDateLabel = new Label { Text = "Конечная дата:", Location = new System.Drawing.Point(200, 330), Size = new System.Drawing.Size(90, 20) };
            Controls.Add(endDateLabel);

            endDatePicker = new DateTimePicker { Location = new System.Drawing.Point(290, 330), Size = new System.Drawing.Size(100, 25) };
            Controls.Add(endDatePicker);

            Button generateShoppingListButton = new Button { Text = "Сгенерировать список покупок", Location = new System.Drawing.Point(10, 330), Size = new System.Drawing.Size(180, 25) };
            generateShoppingListButton.Click += generateShoppingListButton_Click;
            Controls.Add(generateShoppingListButton);
        }

        private void addRecipeButton_Click(object sender, EventArgs e)
        {
            mealPlan.AddRecipeToPlan();
        }

        private void removeRecipeButton_Click(object sender, EventArgs e)
        {
            mealPlan.RemoveRecipeFromPlan();
        }

        private void searchRecipeButton_Click(object sender, EventArgs e)
        {
            mealPlan.SearchRecipeByName();
        }

        private void generateShoppingListButton_Click(object sender, EventArgs e)
        {
            mealPlan.GenerateShoppingList(startDatePicker.Value, endDatePicker.Value);
        }

        private void MealPlanForm_Load(object sender, EventArgs e)
        {

        }
    }
}
