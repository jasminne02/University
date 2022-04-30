using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Text.RegularExpressions;

namespace ConsoleApp3
{
    class Musician
    {
        private string name;
        private string phoneNumber;
        private string address;

        public string Name { get { return name; } set { } }
        public string PhoneNumber { get { return phoneNumber; } set { } }
        public string Address { get { return address; } set { } }

        private Regex nameValidation = new Regex(@"\b[A-Z]{1}[a-z]{2,}");
        private Regex phoneNumberValidation = new Regex(@"\(?\d{3}\)?-? *\d{3}-? *-?\d{4}");

        public Musician(string name, string phoneNumber, string address)
        {
            if (nameValidation.IsMatch(name))
            {
                this.name = name;
            }
            if (phoneNumberValidation.IsMatch(phoneNumber))
            {
                this.phoneNumber = phoneNumber;
            }
            this.address = address;
        }

    }
}
