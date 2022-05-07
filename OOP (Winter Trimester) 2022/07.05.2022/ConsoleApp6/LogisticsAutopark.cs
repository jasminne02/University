using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp6
{
    class LogisticsAutopark : Autopark
    {
        private int maxCargoWeightInAutoark;
        private int currentCargoWight;
        public int MaxCargoWeightInAutoark { get { return maxCargoWeightInAutoark; } }

        public LogisticsAutopark(int maxCargoWeight)
        {
            this.maxCargoWeightInAutoark = maxCargoWeight;
        }

        public override void AddVehicle(MotorVehicle vehicle)
        {
            if(currentCargoWight + vehicle.MaximumCargoWeight <= maxCargoWeightInAutoark)
            {
                Vehicles.Add(vehicle);
                vehiclesNumber++;
                currentCargoWight += vehicle.MaximumCargoWeight;
            }
        }
    }
}
