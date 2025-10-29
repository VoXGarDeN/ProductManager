using System;
using System.Windows.Forms;

namespace ProductManager
{
    public partial class AddProductForm : Form
    {
        public TextBox nameTextBox;
        private NumericUpDown priceNumericUpDown;
        private NumericUpDown quantityNumericUpDown;
        private Button okButton;
        private Button cancelButton;

        public AddProductForm()
        {
            InitializeComponent();

            this.Text = "Добавить продукт";
            this.Width = 300;
            this.Height = 250;

            CreateControls();
        }

        private void CreateControls()
        {
            // Labels
            Label nameLabel = new Label { Text = "Название:", Location = new System.Drawing.Point(10, 10), Size = new System.Drawing.Size(70, 20) };
            Label priceLabel = new Label { Text = "Цена:", Location = new System.Drawing.Point(10, 40), Size = new System.Drawing.Size(70, 20) };
            Label quantityLabel = new Label { Text = "Количество:", Location = new System.Drawing.Point(10, 70), Size = new System.Drawing.Size(70, 20) };

            // Input controls
            nameTextBox = new TextBox { Location = new System.Drawing.Point(90, 10), Size = new System.Drawing.Size(180, 20), Name = "nameTextBox" };
            priceNumericUpDown = new NumericUpDown { Location = new System.Drawing.Point(90, 40), Size = new System.Drawing.Size(100, 20) };
            quantityNumericUpDown = new NumericUpDown { Location = new System.Drawing.Point(90, 70), Size = new System.Drawing.Size(100, 20) };

            // Buttons
            okButton = new Button { Text = "OK", Location = new System.Drawing.Point(110, 120), Size = new System.Drawing.Size(75, 25) };
            okButton.Click += OkButton_Click;
            cancelButton = new Button { Text = "Отмена", Location = new System.Drawing.Point(190, 120), Size = new System.Drawing.Size(75, 25) };
            cancelButton.Click += CancelButton_Click;

            // Add controls to the form
            Controls.Add(nameLabel);
            Controls.Add(priceLabel);
            Controls.Add(quantityLabel);

            Controls.Add(nameTextBox);
            Controls.Add(priceNumericUpDown);
            Controls.Add(quantityNumericUpDown);

            Controls.Add(okButton);
            Controls.Add(cancelButton);
        }

        private void OkButton_Click(object sender, EventArgs e)
        {
            this.DialogResult = DialogResult.OK;
            this.Close();
        }

        private void CancelButton_Click(object sender, EventArgs e)
        {
            this.DialogResult = DialogResult.Cancel;
            this.Close();
        }

        private void InitializeComponent()
        {
            this.SuspendLayout();
            // 
            // AddProductForm
            // 
            this.ClientSize = new System.Drawing.Size(284, 211);
            this.Name = "AddProductForm";
            this.Load += new System.EventHandler(this.AddProductForm_Load);
            this.ResumeLayout(false);

        }

        private void AddProductForm_Load(object sender, EventArgs e)
        {

        }
    }
}
