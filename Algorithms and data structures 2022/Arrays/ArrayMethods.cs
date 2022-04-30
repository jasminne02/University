using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace ConsoleApp1
{
    static class ArrayMethods
    {
     
        public static string ArrayName()
        {
            string name;
            bool repeat = true;

            do
            {
                Console.Write("Enter the name of the array: ");
                name = Console.ReadLine();

                Regex regexNamePattern = new Regex(@"\b[A-Z]{1}[a-z]{2,}");

                if (Char.IsDigit(name[0]) || regexNamePattern.IsMatch(name))
                {
                    repeat = false;
                }

                try
                {
                    foreach(Array n in Array.ArrayList)
                    {
                        if (n.Name == name) { repeat = true; }
                    }
                }
                catch (Exception)
                {
                    continue;
                }

            } while (repeat);

            Console.WriteLine();

            return name;
        }

        public static string ArrayType()
        {
            string type;
            int typeInNumber;
             
            do
            {
                try
                {
                    Console.Write("Choose the type of the array\n0 int  1 double  2 char  3 string  4 bool\nOption: ");
                    typeInNumber = int.Parse(Console.ReadLine());
                }
                catch (Exception)
                {
                    typeInNumber = -1;
                }

            } while (typeInNumber < 0 || typeInNumber > 4);

            switch (typeInNumber)
            {
                case 0: type = "int"; break;
                case 1: type = "double"; break;
                case 2: type = "char"; break;
                case 3: type = "string"; break;
                case 4: type = "bool"; break;
                default: type = ""; break;
            }

            Console.WriteLine();

            return type;
        }

        public static int ArrayLength()
        {
            int length;

            do
            {
                try
                {
                    Console.Write("Enter the length of the array: ");
                    length = int.Parse(Console.ReadLine());
                }
                catch (Exception)
                {
                    length = -1;
                }

            } while (length <= 0);

            Console.WriteLine();

            return length;
        }

        public static int[] IntArray(int length)
        {
            int[] array = new int[length];
            string[] arrayString;

            do
            {
                Console.Write("Enter an integer array: ");
                arrayString = Console.ReadLine().Split(' ');

            } while (arrayString.Length != length);

            for(int i = 0; i < length; i++)
            {
                try
                {
                    array[i] = int.Parse(arrayString[i]);
                }
                catch (Exception)
                {
                    Console.WriteLine($"Invalid input in index {i}");

                    int x = 0;
                    bool repeat;

                    do
                    {
                        try
                        {
                            Console.Write("Enter an integer: ");
                            x = int.Parse(Console.ReadLine());
                            repeat = false;
                        }
                        catch (Exception)
                        {
                            repeat = true;
                        }
                    } while (repeat);

                    array[i] = x;
                }
            }

            Console.WriteLine();

            return array;
        }

        public static double[] DoubleArray(int length)
        {
            double[] array = new double[length];
            string[] arrayString;

            do
            {
                Console.Write("Enter a double array: ");
                arrayString = Console.ReadLine().Split(' ');

            } while (arrayString.Length != length);

            for(int i = 0; i < length; i++)
            {
                try
                {
                    array[i] = double.Parse(arrayString[i]);
                }
                catch (Exception)
                {
                    Console.WriteLine($"Invalid input in index {i}");

                    bool repeat;
                    double x = 0;

                    do
                    {
                        Console.Write("Enter a double number: ");

                        try
                        {
                            x = double.Parse(Console.ReadLine());
                            repeat = false;
                        }
                        catch (Exception)
                        {
                            repeat = true;
                        }

                    } while (repeat);

                    array[i] = x;
                }
            }

            Console.WriteLine();

            return array;
        }

        public static char[] CharArray(int length)
        {
            char[] array = new char[length];
            string[] arrayString;

            do
            {
                Console.Write("Enter a char array: ");
                arrayString = Console.ReadLine().Split(' ');

            } while (arrayString.Length != length);

            for (int i = 0; i < length; i++)
            {
                try
                {
                    array[i] = char.Parse(arrayString[i]);
                }
                catch (Exception)
                {
                    Console.WriteLine($"Invalid input in index {i}");

                    bool repeat;
                    char x;

                    do
                    {
                        try
                        {
                            Console.Write("Enter a char: ");
                            x = char.Parse(Console.ReadLine());
                            repeat = false;
                        }
                        catch
                        {
                            repeat = true;
                        }

                    } while (repeat);
                }
            }

            Console.WriteLine();

            return array;
        }

        public static string[] StringArray(int length)
        {
            string[] array;

            do
            {
                Console.Write("Enter a string array: ");
                array = Console.ReadLine().Split(' ');

            } while (array.Length != length);

            Console.WriteLine();

            return array;
        }

        public static bool[] BoolArray(int length)
        {
            bool[] array = new bool[length];
            string[] arrayString;

            do
            {
                Console.Write("Enter a bool array: ");
                arrayString = Console.ReadLine().Split(' ');

            } while(arrayString.Length != length); 

            for (int i = 0; i < length; i++)
            {
                try
                {
                    array[i] = bool.Parse(arrayString[i]);
                }
                catch (Exception)
                {
                    Console.WriteLine($"Invalid input in index {i}");

                    bool repeat;
                    bool x;

                    do
                    {
                        try
                        {
                            x = bool.Parse(arrayString[i]);
                            repeat = false;
                        }
                        catch (Exception)
                        {
                            repeat = true;
                        }

                    } while (repeat);
                }
            }

            Console.WriteLine();

            return array;
        }

        public static void CompareTwoArrays()
        {
            if(Array.ArrayList.Count == 0)
            {
                Console.WriteLine("There are no arrays to compare!\n");
                return;
            }

            string arrayName1;
            string arrayName2;
            string arrayType;
            int arrayIndexAt1 = 0; 
            int arrayIndexAt2 = 0; 
            int indexCounter = 0;
            bool repeat = true;
            bool equals = true;

            Console.Write("Arrays: ");
            foreach(Array n in Array.ArrayList)
            {
                Console.Write(n.Name + " ");
            }

            Console.WriteLine();
            
            do
            {
                Console.Write("Choose an array name: ");
                arrayName1 = Console.ReadLine();

                foreach(Array n in Array.ArrayList)
                {
                    if (arrayName1 == n.Name)
                    {
                        arrayIndexAt1 = indexCounter;
                        repeat = false;
                    }

                    indexCounter++;
                }

            } while (repeat);

            indexCounter = 0;

            do
            {
                Console.Write("Choose another array name: ");
                arrayName2 = Console.ReadLine();

                foreach(Array n in Array.ArrayList)
                {
                    if (arrayName2 == n.Name && arrayName2 != arrayName1)
                    {
                        arrayIndexAt2 = indexCounter;
                        repeat = false;
                    }

                    indexCounter++;
                }

            } while (repeat);

            if(((Array)Array.ArrayList[arrayIndexAt1]).Type == ((Array)Array.ArrayList[arrayIndexAt2]).Type 
                && ((Array)Array.ArrayList[arrayIndexAt1]).Length == ((Array)Array.ArrayList[arrayIndexAt2]).Length)
            {
                arrayType = ((Array)Array.ArrayList[arrayIndexAt1]).Type;

                if(arrayType == "int")
                {
                    for (int i = 0; i < ((Array)Array.ArrayList[arrayIndexAt1]).Length; i++)
                    {
                        if(((Array)Array.ArrayList[arrayIndexAt1]).ArrayInt[i] != ((Array)Array.ArrayList[arrayIndexAt2]).ArrayInt[i])
                        {
                            equals = false;
                        }
                    }
                }
                else if (arrayType == "double")
                {
                    for (int i = 0; i < ((Array)Array.ArrayList[arrayIndexAt1]).Length; i++)
                    {
                        if (((Array)Array.ArrayList[arrayIndexAt1]).ArrayDouble[i] != ((Array)Array.ArrayList[arrayIndexAt2]).ArrayDouble[i])
                        {
                            equals = false;
                        }
                    }
                }
                else if (arrayType == "char")
                {
                    for (int i = 0; i < ((Array)Array.ArrayList[arrayIndexAt1]).Length; i++)
                    {
                        if (((Array)Array.ArrayList[arrayIndexAt1]).ArrayChar[i] != ((Array)Array.ArrayList[arrayIndexAt2]).ArrayChar[i])
                        {
                            equals = false;
                        }
                    }
                }
                else if (arrayType == "string")
                {
                    for (int i = 0; i < ((Array)Array.ArrayList[arrayIndexAt1]).Length; i++)
                    {
                        if (((Array)Array.ArrayList[arrayIndexAt1]).ArrayString[i] != ((Array)Array.ArrayList[arrayIndexAt2]).ArrayString[i])
                        {
                            equals = false;
                        }
                    }
                }
                else if (arrayType == "bool")
                {
                    for (int i = 0; i < ((Array)Array.ArrayList[arrayIndexAt1]).Length; i++)
                    {
                        if (((Array)Array.ArrayList[arrayIndexAt1]).ArrayBool[i] != ((Array)Array.ArrayList[arrayIndexAt2]).ArrayBool[i])
                        {
                            equals = false;
                        }
                    }
                }


                if (equals)
                {
                    Console.WriteLine("The two arrays are equal!");
                }
                else
                {
                    Console.WriteLine("The arrays are not equal!");
                }

            }
            else
            {
                Console.WriteLine("The arrays are not equal!");
            }
            
            Console.WriteLine();
        }
    }
}
