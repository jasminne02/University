using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Homework
{
    abstract class EdiblePlant : Tree, IFood
    {
        public virtual double Energy { get; set; }
        public override double WaterRequired { get; set; }

    }
}
