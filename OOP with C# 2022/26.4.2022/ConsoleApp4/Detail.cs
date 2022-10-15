using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp4
{
    class Detail
    {
        private double width;
        private double height;
        private double depth;

        public double Width { get { return width; } set { } }
        public double Height { get { return height; } set { } }
        public double Depth { get { return depth; } set { } }

        public Detail(double width, double height, double depth)
        {
            this.width = width;
            this.height = height;
            this.depth = depth;
        }

    }
}
