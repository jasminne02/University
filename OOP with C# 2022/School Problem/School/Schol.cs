using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace School
{
    class Schol
    {
        protected List<Class> classes = new List<Class>();
        public List<Class> Classes { get { return classes; } }

        public void AddClass(Class c)
        {
            classes.Add(c);
        }

        public void SchoolInfo()
        {
            foreach (Class c in classes)
            {
                c.ClassInfo();
                Console.WriteLine("Students:");
                
                foreach (Student s in c.Students)
                {
                    s.StudentInfo();
                }

                Console.WriteLine("Teachers:");
                foreach(Teacher t in c.Teachers)
                {
                    t.TeacherInfo();
                }

                Console.WriteLine();
            }

            Console.WriteLine();
        }
    }
}
