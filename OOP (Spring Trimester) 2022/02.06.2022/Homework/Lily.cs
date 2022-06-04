using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Homework
{
    class Lily : DecorationTree
    {
        private double beautyScore = 7;
        private double waterRequired = 2;

        public override double BeautyScore { get { return beautyScore; } set { } }
        public override double WaterRequired { get { return waterRequired; } set { } }
    }
}
