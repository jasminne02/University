using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Homework
{
    class Peach : FruitTree
    {
        private double energy = 5;
        private double waterRequired = 5;

        public override double Energy { get { return energy; } set { } }
        public override double WaterRequired { get { return waterRequired; } set { } }

    }
}
