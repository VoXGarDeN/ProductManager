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
            // Создание экземпляров форм перед каждым тестом
            _productForm = new MainWindow();
            _addProductForm = new AddProductForm();
        }

        [TestCleanup]
        public void TearDown()
        {
            // Освобождение ресурсов после каждого теста
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

        // Вспомогательный метод для ожидания видимости контрола
        private async Task WaitForControlVisible(Control control, int timeoutMs = 1000)
        {
            var startTime = DateTime.Now;
            // Ожидаем пока контрол станет видимым или истечет время ожидания
            while (!control.Visible && (DateTime.Now - startTime).TotalMilliseconds < timeoutMs)
            {
                Application.DoEvents(); // Обработка событий UI для обновления формы
                await Task.Delay(10); // Небольшая задержка для уменьшения нагрузки на CPU
            }
        }

        [TestMethod]
        public async Task AddProductForm_Controls_HaveCorrectLocations()
        {
            // Arrange - показываем форму добавления товара
            _addProductForm.Show();
            // Ожидаем пока текстовое поле станет видимым
            await WaitForControlVisible(_addProductForm.nameTextBox);

            // Act & Assert - проверка метки "Название:"
            Label nameLabel = _addProductForm.Controls.OfType<Label>().FirstOrDefault(l => l.Text == "Название:");
            Assert.IsNotNull(nameLabel, "Метка 'Название' не найдена.");
            Assert.IsTrue(nameLabel.Location.X >= 0 && nameLabel.Location.Y >= 0, "Некорректное расположение метки 'Название'.");

            // Act & Assert - проверка текстового поля названия
            TextBox nameTextBox = _addProductForm.Controls.OfType<TextBox>().FirstOrDefault(t => t.Name == "nameTextBox");
            Assert.IsNotNull(nameTextBox, "Текстовое поле 'Название' не найдено.");
            Assert.IsTrue(nameTextBox.Visible, "Текстовое поле 'Название' не видимо.");
            Assert.IsTrue(nameTextBox.Enabled, "Текстовое поле 'Название' не активно.");
            // Проверяем, что текстовое поле расположено правее метки
            Assert.IsTrue(nameTextBox.Location.X > nameLabel.Location.X, "Некорректное расположение текстового поля 'Название'.");

            // Cleanup - закрываем форму
            _addProductForm.Close();
        }

        [TestMethod]
        public async Task AddProductForm_NameTextBox_IsVisibleAndEnabled()
        {
            // Arrange - показываем форму добавления товара
            _addProductForm.Show();
            // Ожидаем пока текстовое поле станет видимым
            await WaitForControlVisible(_addProductForm.nameTextBox);

            // Act - находим текстовое поле названия
            TextBox nameTextBox = _addProductForm.Controls.OfType<TextBox>().FirstOrDefault(t => t.Name == "nameTextBox");

            // Assert - проверяем свойства текстового поля
            Assert.IsNotNull(nameTextBox, "Текстовое поле 'Название' не найдено.");
            Assert.IsTrue(nameTextBox.Visible, "Текстовое поле 'Название' не видимо.");
            Assert.IsTrue(nameTextBox.Enabled, "Текстовое поле 'Название' не активно.");

            // Cleanup - закрываем форму
            _addProductForm.Close();
        }
    }
}