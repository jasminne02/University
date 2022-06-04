using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Shop
{
    abstract class Product
    {
        protected string title;
        protected string description;
        protected decimal price;
        protected int stock;

        public string Title { get { return title; } }
        public string Description { get { return description; } }
        public decimal Price { get { return price; } }
        public int Stock { get { return stock; } }

        public Product(string title, string description, decimal price, int stock)
        {
            this.title = title;
            this.description = description;
            this.price = price;
            this.stock = stock;
        }

        public void AddStockToAProduct(int quantity)
        {
            stock += quantity;
        }

        public decimal CalculateTotalValueOfProduct()
        {
            return price * stock;
        }
    }
}
