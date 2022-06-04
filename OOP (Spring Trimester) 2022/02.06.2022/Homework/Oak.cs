using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Homework
{
    class Oak : DecorationTree
    {
        private double beautyScore = 5;
        private double waterRequired = 11;

        public override double BeautyScore { get { return beautyScore; } set { } }
        public override double WaterRequired { get { return waterRequired; } set { } }
    }
}
