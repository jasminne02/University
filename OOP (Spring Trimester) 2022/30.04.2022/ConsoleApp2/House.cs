using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp2
{
    class House
    {
        private double area;
        private double height;
        private string color;
        private List<Room> rooms = new List<Room>();
        private Person owner;

        public double Area { get { return area; } set { } }
        public double Height { get { return height; } set { } }
        public string Color { get { return color; } set { } }
        public List<Room> Rooms { get { return rooms; } }
        public Person Owner { get { return owner; } set { } }

        public House(double area, double height, string color, List<Room> rooms, Person owner)
        {
            this.area = area;
            this.height = height;
            this.color = color;
            this.rooms = rooms;
            this.owner = owner;
        }

        private double SumHouseArea()
        {
            double area = 0;

            foreach(Room room in rooms)
            {
                area += room.Area;
            }

            return area;
        }
    }
}
