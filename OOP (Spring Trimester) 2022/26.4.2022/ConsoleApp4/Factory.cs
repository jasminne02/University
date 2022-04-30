using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp4
{
    class Factory
    {
        private int madeDetails = 0;

        public int MadeDetails {  get { return madeDetails; } }

        public void MakeADetail(double width, double height, double depth)
        {
            Detail detail = new Detail(width, height, depth);
            madeDetails++;
        }

    }
}
