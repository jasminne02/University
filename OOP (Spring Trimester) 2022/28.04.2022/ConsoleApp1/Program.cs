using System;

namespace ConsoleApp1
{
    class MainClass
    {
        public static void Main()
        {
            Student stu = new Student("P", "P.", "P.", 20, "Plovdiv", "+356 3248932", "p@gmail.com", 2, "Law", Enums.Universities.MedicalUniversity, Enums.Faculties.MathAndInformatics);

            stu.Info();
        }
    }
}
