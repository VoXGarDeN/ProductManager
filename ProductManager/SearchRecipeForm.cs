using System;
using System.Windows.Forms;

namespace MealPlanner
{
    public partial class SearchRecipeForm : Form
    {
        public string RecipeName { get; set; }

        private TextBox nameTextBox;
        private Button okButton;
        private Button cancelButton;

        public SearchRecipeForm()
        {
            InitializeComponent(); 
            this.Text = "Поиск рецепта";
            this.Width = 300;
            this.Height = 150;

            CreateControls();
        }

        private void CreateControls()
        {
            // Label
            Label nameLabel = new Label { Text = "Название:", Location = new System.Drawing.Point(10, 10), Size = new System.Drawing.Size(70, 20) };

            // Input control
            nameTextBox = new TextBox { Location = new System.Drawing.Point(90, 10), Size = new System.Drawing.Size(180, 20) };

            // Buttons
            okButton = new Button { Text = "OK", Location = new System.Drawing.Point(110, 50), Size = new System.Drawing.Size(75, 25) };
            okButton.Click += OkButton_Click;
            cancelButton = new Button { Text = "Отмена", Location = new System.Drawing.Point(190, 50), Size = new System.Drawing.Size(75, 25) };
            cancelButton.Click += CancelButton_Click;

            // Add controls to the form
            Controls.Add(nameLabel);
            Controls.Add(nameTextBox);
            Controls.Add(okButton);
            Controls.Add(cancelButton);
        }

        private void OkButton_Click(object sender, EventArgs e)
        {
            RecipeName = nameTextBox.Text;
            this.DialogResult = DialogResult.OK;
            this.Close();
        }

        private void CancelButton_Click(object sender, EventArgs e)
        {
            this.DialogResult = DialogResult.Cancel;
            this.Close();
        }

        private void SearchRecipeForm_Load(object sender, EventArgs e)
        {

        }
    }
}
