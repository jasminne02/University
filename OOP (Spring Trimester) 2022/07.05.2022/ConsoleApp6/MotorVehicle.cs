using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp6
{
    abstract class MotorVehicle
    {
        private int power;
        private int maximumPassengers;
        private int maximumCargoWeight;

        public int Power { get { return power; } }
        public int MaximumPassengers { get { return maximumPassengers; } }
        public int MaximumCargoWeight { get { return maximumCargoWeight; } }

        public MotorVehicle(int power, int maximumPassengers, int maximumCargoWeight)
        {
            this.power = power;
            this.maximumPassengers = maximumPassengers;
            this.maximumCargoWeight = maximumCargoWeight;
        }

    }
}
