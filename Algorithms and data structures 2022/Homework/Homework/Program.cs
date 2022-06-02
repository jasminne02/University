using System;

namespace Homework
{
    class MainClass
    {
        public static void Main()
        {
            string myFacultyNumber = "2101321021";
            int lastDigit = GetLastDigit(myFacultyNumber);

            decimal decimalNumber = 0;
            bool repeat = false;

            do
            {
                try
                {
                    Console.Write("Enter a float number: ");
                    decimalNumber = decimal.Parse(Console.ReadLine());
                    repeat = false;
                }
                catch (Exception ex)
                {
                    repeat = true;
                }
            } while (repeat);

            decimalNumber = decimal.Round(decimalNumber, 1);
            Console.WriteLine($"Decimal number rounded to {lastDigit} digit after decimal point: {decimalNumber}");

            string hexNumber = ConvertToHexadecimal(decimalNumber);
            Console.WriteLine($"Hexadecimal representation of {decimalNumber}: {hexNumber}");
        }

        public static int GetLastDigit(string number)
        {
            char last = number[number.Length-1];
            return (int)Char.GetNumericValue(last);
        }

        public static string ConvertToHexadecimal(decimal number)
        {
            string hex = "";
            int integerPart = (int)decimal.Floor(number);
            int temp, character;
            int x = 0;

            for (int num = integerPart; num > 0 ; num=num/16)
            {
                temp = num % 16;

                if (temp < 10)
                {
                    temp = temp + 48;
                }
                else
                {
                    temp = temp + 55;
                }
                    
                x = x * 100 + temp;
            }

            for (int i = x; i > 0; i = i / 100)
            {
                character = i % 100;
                hex += (char)character;
            }

            decimal decimalPart = number % integerPart;
            x = 0;
            int counter = 0;
            string tempString = "";

            if (decimalPart > 0)
            {
                hex += ".";
            }


            while (decimalPart > 0)
            {
                decimal num = decimalPart * 16;
                integerPart = (int)decimal.Floor(num);

                if (integerPart < 10)
                {
                    temp = integerPart + 48;
                }
                else
                {
                    temp = integerPart + 55;
                }

                x = x * 100 + temp;

                decimalPart = num % integerPart;

                counter++;
                if (counter == 3)
                {
                    break;
                }
            }

            for (int i = x; i > 0; i = i / 100)
            {
                character = i % 100;
                tempString += (char)character;
            }

            for (int i = tempString.Length - 1; i >= 0; i--)
            {
                hex += tempString[i];
            }


            return hex;
        }
    }
}