using System;
namespace ProductManager
{
    public class Product
    {
        public string Name { get; set; }
        public decimal Price { get; set; }
        public int Quantity { get; set; }
        public Product(string name, decimal price, int quantity)
        {
            Name = name;
            Price = price;
            Quantity = quantity;
        }
        public override string ToString()
        {
            return $"Товар: {Name}, Цена: {Price}, Количество: {Quantity}";
        }
        public bool IsAvailable()
        {
            return Quantity > 0;
        }
    }
}