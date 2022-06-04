using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Shop
{
    class Phone : Product, ISpecialityStore
    {
        private string model;
        private int battery;
        private string processor;

        public virtual string Model { get { return model; } }
        public virtual int Battery { get { return battery; } }
        public virtual string Processor { get { return processor; } }

        public Phone(string title, string description, decimal price, int stock, string model, int battery, string processor) : base(title, description, price, stock)
        {
            this.model = model;
            this.battery = battery;
            this.processor = processor;
        }
    }
}
