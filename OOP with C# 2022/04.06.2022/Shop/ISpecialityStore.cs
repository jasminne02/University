using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Shop
{
    interface ISpecialityStore
    {
        string Model { get; }
        int Battery { get; }
        string Processor { get; }
    }
}
