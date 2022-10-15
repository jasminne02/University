using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp6
{
    abstract class Autopark
    {
        protected int vehiclesNumber;
        private List<MotorVehicle> vehicles = new List<MotorVehicle>();

        public int VehiclesNumber { get { return vehiclesNumber; } }
        public List<MotorVehicle> Vehicles { get { return vehicles; } }

        public abstract void AddVehicle(MotorVehicle vehicle);
    }
}
