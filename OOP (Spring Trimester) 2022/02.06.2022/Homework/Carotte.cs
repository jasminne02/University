using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Homework
{
    class Carotte : FruitTree
    {
        private double energy = 10;
        private double waterRequired = 1;

        public override double Energy { get { return energy; } set { } }
        public override double WaterRequired { get { return waterRequired; } set { } }

    }
}
 