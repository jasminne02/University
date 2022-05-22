using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace School
{
    class Teacher : Class, IComments
    {
        private Person person;
        protected List<Discipline> disciplines = new List<Discipline>();
        private List<string> comments = new List<string>();

        public string Name { get { return person.Name; } }
        public List<Discipline> Disciplines { get { return disciplines; } }

        public Teacher(string name, List<Discipline> disciplines)
        {
            person = new Person(name);
            this.disciplines = disciplines;
        }

        public void TeacherInfo()
        {
            Console.Write($"{Name} ");

            if (comments.Count > 0)
            {
                Console.Write("(" + comments.Count + " comments)");
            }
            else
            {
                Console.Write(" (no comments)");
            }

            Console.Write("  Disciplines: ");

            for(int i = 0; i < disciplines.Count; i++)
            {
                if(i == disciplines.Count - 1)
                {
                    Console.Write(disciplines[i].Name);
                }
                else
                {
                    Console.Write(disciplines[i].Name + ", ");
                }
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
