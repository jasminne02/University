using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Shop
{
    interface IGroceryStore
    {
        int Grams { get; }
        string ExpirationDate { get; }
    }
}
