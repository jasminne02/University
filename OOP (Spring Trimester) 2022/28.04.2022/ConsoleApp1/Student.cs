using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp1
{
    class Student
    {
        private string fullName = "";
        private string firstName;
        private string surName = "-";
        private string lastName;
        private int age;
        private string address;
        private string phoneNumber;
        private string email;
        private int course;
        private string specialty;
        private Enums.Universities university;
        private Enums.Faculties faculty;

        public string FullName { get { return fullName; } }
        public string FirstName { get { return firstName; } set { } }
        public string SurName { get { return surName; } set { } }
        public string LastName { get { return lastName; } set { } }
        public int Age { get { return age; } set { } }
        public string Address { get { return address; } set { } }
        public string PhoneNumber { get { return phoneNumber; } set { } }
        public string Email { get { return email; } set { } }
        public int Course { get { return course; } set { } }
        public string Specialty { get { return specialty; } set { } }
        public Enums.Universities University { get { return university; } set { if (Enum.IsDefined(typeof(Enums.Universities), value)) { this.university = value; } } }
        public Enums.Faculties Faculty { get { return faculty; } set { if (Enum.IsDefined(typeof(Enums.Faculties), value)) { this.faculty = value; } } }

        public Student(string fname, string sname, string lname, int age, string address, string number, string email, int course, string spec, Enums.Universities uni, Enums.Faculties faclty)
        {
            this.firstName = fname;
            this.surName = sname;
            this.lastName = lname;
            this.age =age;
            this.address = address;
            this.phoneNumber = number;
            this.email = email;
            this.course = course;
            this.specialty = spec;
            this.university = uni;
            this.faculty = faclty;

            fullName = firstName + " " + surName + " " + lastName;
        }

        public Student(string fname, string sname, string lname, int age)
        {
            this.firstName = fname;
            this.surName = sname;
            this.lastName = lname;
            this.age =age;

            fullName = firstName + " " + surName + " " + lastName;
        }

        public Student(string fname, string lname, string address, string number, string email, int course, string spec, Enums.Universities uni, Enums.Faculties f)
        {
            this.firstName = fname;
            this.lastName = lname;
            this.address = address;
            this.phoneNumber = number;
            this.email = email;
            this.course = course;
            this.specialty = spec;
            this.university = uni;
            this.faculty = f;

            fullName = firstName + " " + surName + " " + lastName;
        }

        public void Info()
        {
            Console.WriteLine(ToString());
        }

        public string ToString()
        {
            return "Name: " + fullName + "\nAge: " + age +"\nAddress: " + address + "\nPhoneNumber: " + phoneNumber + "\nEmail: " + email + "\nCourse: " + course
                + "\nSpeciality: " + specialty + "\nUniversity: " + university + "\nFaculty: " + faculty;
        }
    }
}
