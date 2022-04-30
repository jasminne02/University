using System;
using System.Collections;
using static ConsoleApp1.ArrayMethods;

namespace ConsoleApp1
{
    class MainClass
    {
        static void Main()
        {
            int command;

            do
            {
                //Choose an option
                do
                {
                    try
                    {
                        Console.Write("Choose an option\n0 exit  1 enter an array  2 compare two arrays  3 delete an array  4 all arrays info\nOption: ");
                        command = int.Parse(Console.ReadLine());
                    }
                    catch (Exception)
                    {
                        command = -1;
                    }
                    Console.WriteLine();

                } while (command < 0 || command > 4);

                //Options
                switch (command)
                {
                    //Exits
                    case 0: Console.WriteLine("Bye!"); break;
                    
                    //Enters an array
                    case 1:
                        string name = ArrayName();
                        string type = ArrayType();
                        int length = ArrayLength();

                        if (type == "int")
                        {
                            int[] array = IntArray(length);

                            Array arrayObj = new Array(name, type, length, array);
                            arrayObj.AddToArrayList();
                        }
                        else if (type == "double")
                        {
                            double[] array = DoubleArray(length);

                            Array arrayObj = new Array(name, type, length, array);
                            arrayObj.AddToArrayList();
                        }
                        else if (type == "char")
                        {
                            char[] array = CharArray(length);

                            Array arrayObj = new Array(name, type, length, array);
                            arrayObj.AddToArrayList();
                        }
                        else if (type == "string")
                        {
                            string[] array = StringArray(length);

                            Array arrayObj = new Array(name, type, length, array);
                            arrayObj.AddToArrayList();
                        }
                        else if (type == "bool")
                        {
                            bool[] array = BoolArray(length);

                            Array arrayObj = new Array(name, type, length, array);
                            arrayObj.AddToArrayList();
                        }

                        break;

                    //Compares two arrays
                    case 2:
                        ArrayMethods.CompareTwoArrays();
                        break;

                    //Deletes an array
                    case 3:
                        Array.DeleteFromArrayList();
                        break;

                    //Prints all arrays
                    case 4:
                        Array.AllArrays();
                        break;

                    default: break;
                }

                if (command != 0)
                {
                    Console.WriteLine(" - - - - - - - - - - - - - - - \n");
                }

            } while (command != 0);
        }
    }
}
