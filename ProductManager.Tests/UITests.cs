using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Windows.Forms;
using System;
using System.Linq;
using System.Threading.Tasks;
using ProductManager;  

namespace ProductManager.Tests
{
    [TestClass]
    public class UITests
    {
        private MainWindow _productForm;
        private AddProductForm _addProductForm;

        [TestInitialize]
        public void SetUp()
        {
            // создание экзмепляря форм перед тестов
            _productForm = new MainWindow();
            _addProductForm = new AddProductForm();
        }

        [TestCleanup]
        public void TearDown()
        {
            // освобождение ресурсов после каждого теста
            if (_productForm != null && !_productForm.IsDisposed)
            {
                _productForm.Close();
                _productForm.Dispose();
            }
            if (_addProductForm != null && !_addProductForm.IsDisposed)
            {
                _addProductForm.Close();
                _addProductForm.Dispose();
            }
        }

        private async Task WaitForControlVisible(Control control, int timeoutMs = 1000)
        {
            var startTime = DateTime.Now;
            while (!control.Visible && (DateTime.Now - startTime).TotalMilliseconds < timeoutMs)
            {
                Application.DoEvents(); // обработка событий UI
                await Task.Delay(10); 
            }
        }

        [TestMethod]
        public async Task AddProductForm_Controls_HaveCorrectLocations()
        {
            _addProductForm.Show(); 
            await WaitForControlVisible(_addProductForm.nameTextBox); 

            Label nameLabel = _addProductForm.Controls.OfType<Label>().FirstOrDefault(l => l.Text == "Название:");
            Assert.IsNotNull(nameLabel, "Метка 'Название' не найдена.");
            Assert.IsTrue(nameLabel.Location.X >= 0 && nameLabel.Location.Y >= 0, "Некорректное расположение метки 'Название'.");

            TextBox nameTextBox = _addProductForm.Controls.OfType<TextBox>().FirstOrDefault(t => t.Name == "nameTextBox");
            Assert.IsNotNull(nameTextBox, "Текстовое поле 'Название' не найдено.");
            Assert.IsTrue(nameTextBox.Visible, "Текстовое поле 'Название' не видимо.");
            Assert.IsTrue(nameTextBox.Enabled, "Текстовое поле 'Название' не активно.");
            Assert.IsTrue(nameTextBox.Location.X > nameLabel.Location.X, "Некорректное расположение текстового поля 'Название'.");

            _addProductForm.Close();

        }


        [TestMethod]
        public async Task AddProductForm_NameTextBox_IsVisibleAndEnabled()
        {
            _addProductForm.Show(); 
            await WaitForControlVisible(_addProductForm.nameTextBox); 

            TextBox nameTextBox = _addProductForm.Controls.OfType<TextBox>().FirstOrDefault(t => t.Name == "nameTextBox");
            Assert.IsNotNull(nameTextBox, "Текстовое поле 'Название' не найдено.");
            Assert.IsTrue(nameTextBox.Visible, "Текстовое поле 'Название' не видимо.");
            Assert.IsTrue(nameTextBox.Enabled, "Текстовое поле 'Название' не активно.");
            _addProductForm.Close();
        }
    }
}
