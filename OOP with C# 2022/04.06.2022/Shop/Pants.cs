using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Shop
{
    class Pants : Product, IDepartmentStore
    {
        private string size;
        private string color;
        private string fabric;
        public virtual string Size { get { return size; } }
        public virtual string Color { get { return color; } }
        public virtual string Fabric { get { return fabric; } }

        public Pants(string title, string description, decimal price, int stock, string size, string color, string fabric) : base(title, description, price, stock)
        {
            this.size = size;
            this.color = color;
            this.fabric = fabric;
        }

    }
}
