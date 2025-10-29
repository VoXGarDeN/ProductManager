using System;
using System.Collections.Generic;
using System.Windows.Forms;

namespace ProductManager
{
    public partial class MainWindow : Form
    {
        private List<Product> products = new List<Product>();
        private const string Version = "1.0";

        public MainWindow()
        {
            InitializeComponent();
            // Добавляем обработчик события Load для формы
        }

        private void MainWindow_Load(object sender, EventArgs e)
        {
            this.Text = $"Product Manager - Version {Version}";
        }


        private void button1_Click(object sender, EventArgs e)
        {
            try
            {
                string name = nameTextBox.Text.Trim(); // Убираем лишние пробелы
                decimal price = numericUpDown1.Value;
                int quantity = (int)numericUpDown2.Value;

                if (string.IsNullOrWhiteSpace(name))
                {
                    MessageBox.Show("Введите наименование товара!", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }
                if (price <= 0)
                {
                    MessageBox.Show("Цена должна быть положительной!", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }
                if (quantity < 0)
                {
                    MessageBox.Show("Количество не может быть отрицательным!", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }

                Product product = new Product(name, price, quantity);
                products.Add(product);
                UpdateProductList();
                MessageBox.Show("Товар добавлен!", "Успех", MessageBoxButtons.OK, MessageBoxIcon.Information);

                // Очищаем поля после добавления
                nameTextBox.Clear();
                numericUpDown1.Value = 0;
                numericUpDown2.Value = 0;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void removeButton_Click(object sender, EventArgs e)
        {
            try
            {
                if (productsList.SelectedIndex >= 0)
                {
                    int selectedIndex = productsList.SelectedIndex;
                    products.RemoveAt(selectedIndex);
                    UpdateProductList();
                    MessageBox.Show("Товар удален!", "Успех", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                else
                {
                    MessageBox.Show("Выберите товар для удаления!", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void checkButton_Click(object sender, EventArgs e)
        {
            try
            {
                if (productsList.SelectedIndex >= 0)
                {
                    Product product = products[productsList.SelectedIndex];
                    string message = product.IsAvailable() ? "Товар доступен!" : "Товар недоступен!";
                    MessageBox.Show(message, "Статус", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                else
                {
                    MessageBox.Show("Выберите товар для проверки!", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void UpdateProductList()
        {
            productsList.Items.Clear();
            foreach (var product in products)
            {
                productsList.Items.Add(product.ToString());
            }
        }
    }
}
