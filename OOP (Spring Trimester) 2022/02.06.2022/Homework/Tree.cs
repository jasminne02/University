using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Homework
{
    abstract class Tree : IGardenItem
    {
        public virtual double WaterRequired { get; set; }
    }
}
