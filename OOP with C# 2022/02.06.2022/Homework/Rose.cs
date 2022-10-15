using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Homework
{
    class Rose : DecorationTree
    {
        private double beautyScore = 15;
        private double waterRequired = 5;

        public override double BeautyScore { get { return beautyScore; } set { } }
        public override double WaterRequired { get { return waterRequired; } set { } }
    }
}
