using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace School
{
    class Discipline : IComments
    {
        private string name;
        private int lecturesNumber;
        private int exercisesNumber;
        private List<string> comments = new List<string>();

        public string Name { get { return name; } }
        public int LecturesNumber { get { return lecturesNumber; } }
        public int ExercisesNumber { get { return exercisesNumber; } }

        public Discipline(string name, int lecturesNumber, int exercisesNumber)
        {
            this.name= name;
            this.lecturesNumber = lecturesNumber;
            this.exercisesNumber = exercisesNumber;
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
