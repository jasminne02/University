using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Homework
{
    class Apricot : FruitTree
    {
        private double energy = 7;
        private double waterRequired = 7;

        public override double Energy { get { return energy; } set { } }
        public override double WaterRequired { get { return waterRequired; } set { } }

    }
}

