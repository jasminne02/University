using System;

namespace ConsoleApp6
{
    class MainClass
    {
        public static void Main()
        {
            Car car1 = new Car(500, 5, 40);
            Car car2 = new Car(350, 2, 920);
            Car car3 = new Car(334, 4, 220);
            Car car4 = new Car(231, 5, 222);
            Car car5 = new Car(453, 5, 170);
            Car car6 = new Car(893, 4, 150);
            Car car7 = new Car(333, 3, 120);

            Van van1 = new Van(340, 8, 293);
            Van van2 = new Van(880, 9, 938);
            Van van3 = new Van(2340, 6, 893);
            Van van4 = new Van(430, 8, 333);
            Van van5 = new Van(400, 7, 133);

            Bus bus1 = new Bus(2343, 16, 2324);
            Bus bus2 = new Bus(5455, 17, 5324);
            Bus bus3 = new Bus(458, 19, 274);
            Bus bus4 = new Bus(7555, 18, 286);
            Bus bus5 = new Bus(5645, 15, 974);

            PublicTransportationAutoPark transportationAutoPark1 = new PublicTransportationAutoPark(20);
            PublicTransportationAutoPark transportationAutoPark2 = new PublicTransportationAutoPark(40);
            PublicTransportationAutoPark transportationAutoPark3 = new PublicTransportationAutoPark(30);

            LogisticsAutopark logisticsAutopark1 = new LogisticsAutopark(1700);
            LogisticsAutopark logisticsAutopark2 = new LogisticsAutopark(2450);
            LogisticsAutopark logisticsAutopark3 = new LogisticsAutopark(3380);

            transportationAutoPark1.AddVehicle(car1);
            transportationAutoPark1.AddVehicle(van2);
            transportationAutoPark1.AddVehicle(car2);
            transportationAutoPark1.AddVehicle(car3);

            transportationAutoPark2.AddVehicle(van1);
            transportationAutoPark2.AddVehicle(bus1);
            transportationAutoPark2.AddVehicle(van3);
            transportationAutoPark2.AddVehicle(van4);
            transportationAutoPark2.AddVehicle(van2);

            transportationAutoPark3.AddVehicle(car4);
            transportationAutoPark3.AddVehicle(bus3);
            transportationAutoPark3.AddVehicle(car5);
            transportationAutoPark3.AddVehicle(van5);

            logisticsAutopark1.AddVehicle(car1);
            logisticsAutopark1.AddVehicle(bus2);
            logisticsAutopark1.AddVehicle(bus5);
            logisticsAutopark1.AddVehicle(car5);

            logisticsAutopark2.AddVehicle(car6);
            logisticsAutopark2.AddVehicle(bus4);
            logisticsAutopark2.AddVehicle(bus1);
            logisticsAutopark2.AddVehicle(car7);

            logisticsAutopark3.AddVehicle(bus5);
            logisticsAutopark3.AddVehicle(car1);
            logisticsAutopark3.AddVehicle(van3);
            logisticsAutopark3.AddVehicle(bus3);

            Console.WriteLine("Number of vehicles in Public Transportation AutoPark 1: " + transportationAutoPark1.VehiclesNumber);
            Console.WriteLine("Number of vehicles in Public Transportation AutoPark 2: " + transportationAutoPark2.VehiclesNumber);
            Console.WriteLine("Number of vehicles in Public Transportation AutoPark 3: " + transportationAutoPark3.VehiclesNumber);
            Console.WriteLine("Number of vehicles in Logistics Autopark 1: " + logisticsAutopark1.VehiclesNumber);
            Console.WriteLine("Number of vehicles in Logistics Autopark 2: " + logisticsAutopark2.VehiclesNumber);
            Console.WriteLine("Number of vehicles in Logistics Autopark 3: " + logisticsAutopark3.VehiclesNumber);
        }
    }
}