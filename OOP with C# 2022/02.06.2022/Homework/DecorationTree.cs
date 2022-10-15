using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Homework
{
    abstract class DecorationTree : Tree, IBeauty
    {
        public virtual double BeautyScore { get; set; }
        public override double WaterRequired { get; set; }
    }
}
