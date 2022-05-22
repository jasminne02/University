using System;

namespace School
{
    class MainClass
    {
        public static void Main()
        {
            /*  First School  */
            Schol school1 = new Schol();

            //Disciplines
            Discipline mathematics = new Discipline("Mathematics", 17, 30);
            Discipline biology = new Discipline("Biology", 7, 3);
            Discipline computerScience = new Discipline("Computer Science", 24, 39);
            Discipline sport = new Discipline("Sport", 0, 15);
            Discipline history = new Discipline("History", 10, 0);
            Discipline english = new Discipline("English", 10, 19);
            Discipline french = new Discipline("French", 10, 19);
            Discipline geography = new Discipline("Geography", 4, 4);

            computerScience.AddComment("The best class in the school!");

            //Class 1
            List<Student> studentsClass1 = new List<Student>();
            Student stu1 = new Student("Ana", 1);
            Student stu2 = new Student("Alex", 2);
            Student stu3 = new Student("Sally", 3);
            Student stu4 = new Student("Bob", 4);
            studentsClass1.Add(stu1);
            studentsClass1.Add(stu2);
            studentsClass1.Add(stu3);
            studentsClass1.Add(stu4);
            
            List<Teacher> teachersClass1 = new List<Teacher>();
            List<Discipline> t1Disciplines = new List<Discipline>();
            List<Discipline> t2Disciplines = new List<Discipline>();
            List<Discipline> t3Disciplines = new List<Discipline>();
            List<Discipline> t4Disciplines = new List<Discipline>();
            t1Disciplines.Add(geography);
            t1Disciplines.Add(history); 
            Teacher teacher1 = new Teacher("Petrov", t1Disciplines);
            t2Disciplines.Add(english);
            t2Disciplines.Add(french);
            Teacher teacher2 = new Teacher("Monica", t2Disciplines);
            t3Disciplines.Add(sport);
            Teacher teacher3 = new Teacher("George", t3Disciplines);
            t4Disciplines.Add(mathematics);
            t4Disciplines.Add(computerScience);
            Teacher teacher4 = new Teacher("John", t4Disciplines);
            teachersClass1.Add(teacher1);
            teachersClass1.Add(teacher2);
            teachersClass1.Add(teacher3);
            teachersClass1.Add(teacher4);

            teacher2.AddComment("She's a good teacher");
            
            Class class1 = new Class("11a", studentsClass1, teachersClass1);

            //Class 2
            List<Student> studentsClass2 = new List<Student>();
            Student stud1 = new Student("Iva", 1);
            Student stud2 = new Student("John", 2);
            Student stud3 = new Student("Victoria", 3);
            Student stud4 = new Student("Kris", 4);
            studentsClass2.Add(stud1);
            studentsClass2.Add(stud2);
            studentsClass2.Add(stud3);
            studentsClass2.Add(stud4);

            stu3.AddComment("Good work!");
            stu1.AddComment("Sleeps in class");
            stu3.AddComment("Excelent grades :)");

            List<Teacher> teachersClass2 = new List<Teacher>();
            List<Discipline> t1Dcpl = new List<Discipline>();
            List<Discipline> t2Dcpl = new List<Discipline>();
            List<Discipline> t3Dcpl = new List<Discipline>();
            List<Discipline> t4Dcpl = new List<Discipline>();
            List<Discipline> t5Dcpl = new List<Discipline>();
            t1Dcpl.Add(geography);
            t1Dcpl.Add(history);
            Teacher tchr1 = new Teacher("Ivanov", t1Dcpl);
            t2Dcpl.Add(english);
            t2Dcpl.Add(french);
            Teacher tchr2 = new Teacher("Maria", t2Dcpl);
            t3Dcpl.Add(sport);
            Teacher tchr3 = new Teacher("Peter", t3Dcpl);
            t4Dcpl.Add(mathematics);
            t4Dcpl.Add(computerScience);
            Teacher tchr4 = new Teacher("Ivan", t4Dcpl);
            t5Dcpl.Add(biology);
            Teacher tchr5 = new Teacher("Nick", t5Dcpl);
            teachersClass2.Add(tchr1);
            teachersClass2.Add(tchr2);
            teachersClass2.Add(tchr3);
            teachersClass2.Add(tchr4);
            teachersClass2.Add(tchr5);

            Class class2 = new Class("10b", studentsClass2, teachersClass2);

            school1.AddClass(class1);
            school1.AddClass(class2);

            school1.SchoolInfo();
        }
    }
}
