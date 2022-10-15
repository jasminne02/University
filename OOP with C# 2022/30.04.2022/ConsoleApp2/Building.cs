using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp2
{
    class Building : House
    {
        public Building(double area, double height, string color, List<Room> rooms, Person owner) : base(area, height, color, rooms, owner)
        {
        }

        public void PrintInfo()
        {
            Console.WriteLine($"Area: {Area}, Height: {Height}, Color: {Color}");
        }
    }
}
