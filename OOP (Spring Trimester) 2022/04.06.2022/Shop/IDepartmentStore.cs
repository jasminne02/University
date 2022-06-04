using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Shop
{
    interface IDepartmentStore
    {
        string Size { get; }
        string Color { get; }
        string Fabric { get; }
    }
}
