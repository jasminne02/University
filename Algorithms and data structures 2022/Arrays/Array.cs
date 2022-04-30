using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp1
{
    class Array
    {
        private string name;
        private string type;
        private int length;
        private static ArrayList arrayList = new ArrayList();
        
        private int[] arrayInt;
        private double[] arrayDouble;
        private char[] arrayChar;
        private string[] arrayString;
        private bool[] arrayBool;

        public static ArrayList ArrayList { get { return arrayList; } }
        public string Name { get { return name; } }
        public string Type { get { return type; } }
        public int Length { get { return length; } }
        public int[] ArrayInt { get { return arrayInt; } }
        public double[] ArrayDouble { get { return arrayDouble; } }
        public char[] ArrayChar { get { return arrayChar; } }
        public string[] ArrayString { get { return arrayString; } }
        public bool[] ArrayBool { get { return arrayBool; } }  


        //Constructors 
        public Array(string name, string type, int length, int[] array)
        {
            this.name = name;
            this.type = type;
            this.length = length;
            this.arrayInt = array;
        }

        public Array(string name, string type, int length, double[] array)
        {
            this.name = name;
            this.type = type;
            this.length = length;
            this.arrayDouble = array;
        }

        public Array(string name, string type, int length, char[] array)
        {
            this.name = name;
            this.type = type;
            this.length = length;
            this.arrayChar = array;
        }

        public Array(string name, string type, int length, string[] array)
        {
            this.name = name;
            this.type = type;
            this.length = length;
            this.arrayString = array;
        }

        public Array(string name, string type, int length, bool[] array)
        {
            this.name = name;
            this.type = type;
            this.length = length;
            this.arrayBool = array;
        }


        //Methods
        public void AddToArrayList()
        {
            arrayList.Add(this);
        }

        public static void DeleteFromArrayList()
        {
            if(ArrayList.Count == 0)
            {
                Console.WriteLine("There are no arrays!");
                return;
            }

            string nameToDelete;
            int removeAtIndex = 0;
            int indexCounter = 0;
            bool repeat = true;

            Console.WriteLine("The names of arrays:");
            foreach (Array n in ArrayList)
            {
                Console.Write(n.Name + " ");
            }

            Console.WriteLine();

            do
            {
                Console.Write("Which array u want to delete ? ");
                nameToDelete = Console.ReadLine();

                foreach (Array n in ArrayList)
                {
                    if(nameToDelete == n.Name)
                    {
                        removeAtIndex = indexCounter;
                        repeat = false;
                    }

                    indexCounter++;
                }

            } while (repeat);

            arrayList.RemoveAt(removeAtIndex);

            Console.WriteLine();

        }

        public static void AllArrays()
        {
            string command;
            string nameMoreInfo;
            int indexArrayAt = 0;
            int indexCounter = 0;
            string typeOfInfo;
            bool repeat = true;

            if(ArrayList.Count == 0)
            {
                Console.WriteLine("There are no arrays!");
                return;
            }

            Console.Write("All arrays' names: ");
            foreach (Array n in ArrayList)
            {
                Console.Write(n.Name + " ");
            }

            Console.WriteLine();

            do
            {
                Console.Write("Do u want to check more info? (yes/no) ");
                command = Console.ReadLine().ToLower();

                if (command == "yes" || command == "no")
                {
                    repeat = false;
                }

            }while(repeat);

            Console.WriteLine();

            if (command == "yes")
            {
                do
                {
                    repeat = true;
                    Console.Write("Enter the name of the array u want more info about: ");
                    nameMoreInfo = Console.ReadLine();

                    foreach (Array n in ArrayList)
                    {
                        if(nameMoreInfo == n.Name)
                        {
                            indexArrayAt = indexCounter;
                            repeat = false;
                        }
                        indexCounter++;
                    }

                } while (repeat);

                do
                {
                    repeat = true;
                    Console.Write("What type of info u want? (array/length/type) ");
                    typeOfInfo = Console.ReadLine().ToLower();

                    if (typeOfInfo == "array" || typeOfInfo == "length" || typeOfInfo == "type")
                    {
                        repeat = false;
                    }

                } while (repeat);

                if (typeOfInfo == "array")
                {
                    string type = ((Array)ArrayList[indexArrayAt]).type;

                    if (type == "int")
                    {
                        int[] arr = ((Array)ArrayList[indexArrayAt]).ArrayInt;

                        foreach (int i in arr)
                        {
                            Console.Write(i + " ");
                        }
                    }
                    else if (type == "double")
                    {
                        double[] arr = ((Array)ArrayList[indexArrayAt]).ArrayDouble;

                        foreach (double d in arr)
                        {
                            Console.WriteLine(d + " ");
                        }
                    }
                    else if(type == "char")
                    {
                        char[] arr = ((Array)ArrayList[indexArrayAt]).ArrayChar;

                        foreach (char c in arr)
                        {
                            Console.Write(c + " ");
                        }
                    }
                    else if (type == "string")
                    {
                        string[] arr = ((Array)ArrayList[indexArrayAt]).ArrayString;

                        foreach (string s in arr)
                        {
                            Console.Write(s + " ");
                        }
                    }
                    else if (type == "bool")
                    {
                        bool[] arr = ((Array)ArrayList[indexArrayAt]).ArrayBool;

                        foreach (bool b in arr)
                        {
                            Console.Write(b + " ");
                        }
                    }
                }
                else if(typeOfInfo == "length")
                {
                    Console.WriteLine($"The length of the array: {((Array)ArrayList[indexArrayAt]).Length}");
                }
                else if (typeOfInfo == "type")
                {
                    Console.WriteLine($"The type of the array: {((Array)ArrayList[indexArrayAt]).Type}");
                }
            }

            Console.WriteLine();
        }

    }
}
