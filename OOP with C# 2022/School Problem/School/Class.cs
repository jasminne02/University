using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace School
{
    class Class : Schol, IComments
    {
        protected string nameIdentifier;
        protected List<Student> students = new List<Student>();
        protected List<Teacher> teachers = new List<Teacher>();
        private List<string> comments = new List<string>();

        public string NameIdentifier { get { return nameIdentifier; } }
        public List<Student> Students { get { return students; } }
        public List<Teacher> Teachers { get { return teachers; } }

        public Class() { }

        public Class(string nameIdentifier, List<Student> students, List<Teacher> teachers)
        {
            this.nameIdentifier = nameIdentifier;
            this.students = students;
            this.teachers = teachers;
        }

        public void ClassInfo()
        {
            Console.WriteLine($"{NameIdentifier} - Students Count: {Students.Count}; Teachers Count: {Teachers.Count}");
        }

        public void AddStudent(Student student)
        {
            students.Add(student);
        }

        public void RemoveStudent(Student student)
        {
            students.Remove(student);
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
            foreach(String comment in comments)
            {
                Console.Write(comment + " ");
            }

            Console.WriteLine();
        }
    }
}
