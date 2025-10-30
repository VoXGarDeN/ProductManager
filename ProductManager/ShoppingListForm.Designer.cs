namespace MealPlanner
{
    partial class ShoppingListForm
    {
        private System.ComponentModel.IContainer components = null;
        private System.Windows.Forms.ListBox shoppingListBox;
        private System.Windows.Forms.TextBox newIngredientTextBox;
        private System.Windows.Forms.Button addIngredientButton;
        private System.Windows.Forms.Button removeIngredientButton;
        private System.Windows.Forms.Button saveButton;
        private System.Windows.Forms.Button closeButton;

        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        private void InitializeComponent()
        {
            this.shoppingListBox = new System.Windows.Forms.ListBox();
            this.newIngredientTextBox = new System.Windows.Forms.TextBox();
            this.addIngredientButton = new System.Windows.Forms.Button();
            this.removeIngredientButton = new System.Windows.Forms.Button();
            this.saveButton = new System.Windows.Forms.Button();
            this.closeButton = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // shoppingListBox
            // 
            this.shoppingListBox.FormattingEnabled = true;
            this.shoppingListBox.Location = new System.Drawing.Point(12, 12);
            this.shoppingListBox.Name = "shoppingListBox";
            this.shoppingListBox.Size = new System.Drawing.Size(360, 160);
            this.shoppingListBox.TabIndex = 0;
            // 
            // newIngredientTextBox
            // 
            this.newIngredientTextBox.Location = new System.Drawing.Point(12, 185);
            this.newIngredientTextBox.Name = "newIngredientTextBox";
            this.newIngredientTextBox.Size = new System.Drawing.Size(200, 20);
            this.newIngredientTextBox.TabIndex = 1;
            // 
            // addIngredientButton
            // 
            this.addIngredientButton.Location = new System.Drawing.Point(218, 183);
            this.addIngredientButton.Name = "addIngredientButton";
            this.addIngredientButton.Size = new System.Drawing.Size(75, 23);
            this.addIngredientButton.TabIndex = 2;
            this.addIngredientButton.Text = "Добавить";
            this.addIngredientButton.UseVisualStyleBackColor = true;
            this.addIngredientButton.Click += new System.EventHandler(this.AddIngredientButton_Click);
            // 
            // removeIngredientButton
            // 
            this.removeIngredientButton.Location = new System.Drawing.Point(299, 183);
            this.removeIngredientButton.Name = "removeIngredientButton";
            this.removeIngredientButton.Size = new System.Drawing.Size(75, 23);
            this.removeIngredientButton.TabIndex = 3;
            this.removeIngredientButton.Text = "Удалить";
            this.removeIngredientButton.UseVisualStyleBackColor = true;
            this.removeIngredientButton.Click += new System.EventHandler(this.RemoveIngredientButton_Click);
            // 
            // saveButton
            // 
            this.saveButton.Location = new System.Drawing.Point(12, 220);
            this.saveButton.Name = "saveButton";
            this.saveButton.Size = new System.Drawing.Size(75, 23);
            this.saveButton.TabIndex = 4;
            this.saveButton.Text = "Сохранить";
            this.saveButton.UseVisualStyleBackColor = true;
            this.saveButton.Click += new System.EventHandler(this.SaveButton_Click);
            // 
            // closeButton
            // 
            this.closeButton.Location = new System.Drawing.Point(93, 220);
            this.closeButton.Name = "closeButton";
            this.closeButton.Size = new System.Drawing.Size(75, 23);
            this.closeButton.TabIndex = 5;
            this.closeButton.Text = "Закрыть";
            this.closeButton.UseVisualStyleBackColor = true;
            this.closeButton.Click += new System.EventHandler(this.CloseButton_Click);
            // 
            // ShoppingListForm
            // 
            this.ClientSize = new System.Drawing.Size(384, 255);
            this.Controls.Add(this.closeButton);
            this.Controls.Add(this.saveButton);
            this.Controls.Add(this.removeIngredientButton);
            this.Controls.Add(this.addIngredientButton);
            this.Controls.Add(this.newIngredientTextBox);
            this.Controls.Add(this.shoppingListBox);
            this.Name = "ShoppingListForm";
            this.Text = "Список покупок";
            this.Load += new System.EventHandler(this.ShoppingListForm_Load);
            this.ResumeLayout(false);
            this.PerformLayout();
        }
    }
}