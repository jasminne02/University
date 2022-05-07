using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp6
{
    class PublicTransportationAutoPark : Autopark
    {
        private int maxPassengersInAutopark;
        private int currentPassengers = 0;

        public int MaxPassengersInAutopark { get { return maxPassengersInAutopark; } }

        public PublicTransportationAutoPark(int maxPassengers)
        {
            this.maxPassengersInAutopark = maxPassengers;
        }

        public override void AddVehicle(MotorVehicle vehicle)
        {
            if(currentPassengers + vehicle.MaximumPassengers <= maxPassengersInAutopark)
            {
                Vehicles.Add(vehicle);
                vehiclesNumber++;
                currentPassengers += vehicle.MaximumPassengers;
            }
        }
    }
}
