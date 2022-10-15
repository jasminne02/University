using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace School
{
    class Student :Class, IComments
    {
        private Person person;
        private int classNumber;
        private List<string> comments = new List<string>();

        public string Name { get { return person.Name; } }
        public int ClassNumber { get { return classNumber; } }

        public Student(string name, int classNumber)
        {
            person = new Person(name);
            this.classNumber = classNumber;
        }

        public void StudentInfo()
        {
            Console.Write(Name + " - ClassNumber: " + classNumber);
            if(comments.Count > 0)
            {
                Console.Write("(" + comments.Count + " comments)");
            }
            else
            {
                Console.Write(" (no comments)");
            }

            Console.WriteLine();
        }

        //IComments methods
        public void AddComment(string comment)
        {
            comments.Add(comment);
        }

        public void RemoveComment(string comment)
        {
            comments.Remove(comment);
        }

        public void ReadComments()
        {
            foreach (String comment in comments)
            {
                Console.Write(comment + " ");
            }

            Console.WriteLine();
        }
    }
}
