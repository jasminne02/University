using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Shop
{
    class Inventory
    {
        private List<Product> products = new List<Product>();

        public List<Product> Products { get { return products; } }

        public void AddProduct(Product product)
        {
            products.Add(product);
        }

        public decimal CalculateTotalValue()
        {
            decimal totalValue = 0;
            foreach (Product product in products)
            {
                totalValue += product.Price * product.Stock;
            }

            return totalValue;
        }
    }
}
