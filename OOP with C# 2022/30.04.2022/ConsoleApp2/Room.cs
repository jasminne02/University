using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp2
{
    abstract class Room
    {
        private double area;
        private string color;

        public double Area { get { return area; } set { } }
        public string Color { get { return color; } set { } }

        public Room(double roomArea, string roomColor)
        {
            this.area = roomArea;
            this.color = roomColor;
        }

    }
}
