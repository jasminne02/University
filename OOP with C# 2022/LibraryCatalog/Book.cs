using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LibraryCatalog
{
    class Book
    {
        private string name;
        private string author;

        public string Name {  get { return name; } }
        public string Author { get { return author; } }

        public Book(string name, string author)
        {
            this.name = name;
            this.author = author;
        }

    }
}
