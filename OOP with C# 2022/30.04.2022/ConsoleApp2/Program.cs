using System;
using ConsoleApp2;

namespace ConsoleApp1
{
    class MainClass
    {
        public static void Main()
        {
            List<Building> buildingsList = new List<Building>();

            Person owner1 = new Person("Anna");
            Person owner2 = new Person("Tom");
            Person owner3 = new Person("Victoria");

            List<Room> rooms1 = new List<Room>();
            Bathroom bathroom1 = new Bathroom(23.21, "grey");
            Kitchen kitchen1 = new Kitchen(90.34, "white");
            Bedroom bedroom1 = new Bedroom(65.23, "pink");
            rooms1.Add(bathroom1);
            rooms1.Add(kitchen1);
            rooms1.Add(bedroom1);

            List<Room> rooms2 = new List<Room>();
            Bathroom bathroom2 = new Bathroom(37.12, "blue");
            Kitchen kitchen2 = new Kitchen(90.34, "white");
            Bedroom bedroom2 = new Bedroom(65.23, "grey");
            rooms1.Add(bathroom2);
            rooms1.Add(kitchen2);
            rooms1.Add(bedroom2);

            List<Room> rooms3 = new List<Room>();
            Bathroom bathroom3 = new Bathroom(45.7, "white");
            Kitchen kitchen3 = new Kitchen(68.44, "grey");
            Bedroom bedroom3 = new Bedroom(58.65, "purple");
            rooms1.Add(bathroom3);
            rooms1.Add(kitchen3);
            rooms1.Add(bedroom3);

            Building building1 = new Building(202.32, 5, "white", rooms1, owner1);
            Building building2 = new Building(202.32, 5, "grey", rooms2, owner2);
            Building building3 = new Building(202.32, 5, "grey", rooms3, owner3);

            buildingsList.Add(building1);
            buildingsList.Add(building2);
            buildingsList.Add(building3);

            foreach(Building building in buildingsList)
            {
                building.PrintInfo();
            }
        }
    }
}
