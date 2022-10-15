using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Homework
{
    class Acacia : DecorationTree
    {
        private double beautyScore = 10;
        private double waterRequired = 3;

        public override double BeautyScore { get { return beautyScore; } set { } }
        public override double WaterRequired { get { return waterRequired; } set { } }
    }
}
