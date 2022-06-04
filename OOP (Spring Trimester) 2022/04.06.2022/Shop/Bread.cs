using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Shop
{
    class Bread : Product, IGroceryStore
    {
        private int grams;
        private string expirationDate;

        public virtual int Grams { get { return grams; } }
        public virtual string ExpirationDate { get { return expirationDate; } }

        public Bread(string title, string description, decimal price, int stock, int grams, string expirationDate) : base(title, description, price, stock)
        {
            this.grams = grams;
            this.expirationDate = expirationDate;
        }
    }
}
 