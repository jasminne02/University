using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace School
{
    interface IComments
    {
        void AddComment(string comment);

        void RemoveComment(string comment);

        void ReadComments();
    }
}
