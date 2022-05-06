using System;

namespace Homework
{
    class MainClass
    {
        public static void Main()
        {
            //  1 Задача
            int doubleArraySize;
            double[] doubleArray;
            double arraySum;

            do
            {
                Console.Write("Enter the size of the array (a number lower than 20): ");
                try
                {
                    doubleArraySize = int.Parse(Console.ReadLine());
                }
                catch (FormatException)
                {
                    Console.WriteLine("Invalid input!");
                    doubleArraySize = 0;
                }

            } while (doubleArraySize <= 0 || doubleArraySize >= 20);

            doubleArray = EnterArrayElements(doubleArraySize);
            arraySum = SumArray(doubleArray);
            Console.WriteLine("Array's elements sum: {0:0.00}\n", arraySum);



            //  2 Задача
            int[] intArray = RandomIntArray();
            PrintArray(intArray);
            MostCommonNumber(intArray);



            //  3 Задача
            int[,] matrix = EnterMatrixElements();
            PrintMatrix(matrix);
            MagicSquare(matrix);



            //  4 Задача
            double[] numbers = EnterNumbers();
            MonotonicallyIncreasingNumbers(numbers);



            //  5 Задача
            long prime = CloseToPrimeNum();
            Console.WriteLine($"{prime} is the closest bigger prime number\n");



            //  6 Заадача
            int number;

            do
            {
                try
                {
                    Console.Write("Enter a number in range 10 to 10010: ");
                    number = int.Parse(Console.ReadLine());
                }
                catch (Exception)
                {
                    Console.WriteLine("Invalid input!");
                    number = 0;
                }
            } while (number < 10 || number > 10010);

            int sum = SumOfDigits(number);
            Console.WriteLine($"The sum of the digits: {sum}");
        }

        public static double[] EnterArrayElements(int size)
        {
            double[] array = new double[size];

            for (int i = 0; i < size; i++)
            {
                bool repeat = false;

                do
                {
                    Console.Write($"array[{i}]: ");
                    try
                    {
                        array[i] = double.Parse(Console.ReadLine());
                        repeat = false;
                    }
                    catch
                    {
                        Console.WriteLine("Invalid input!");
                        repeat = true;
                    }
                } while (repeat);
            }

            return array;
        }

        public static double SumArray(double[] array)
        {
            double sum = 0;

            for (int i = 0; i < array.Length; i++)
            {
                sum += array[i];
            }

            return sum;
        }

        public static int[] RandomIntArray()
        {
            Random random = new Random();
            int size;
            int[] array;

            do
            {
                Console.Write("Enter the size of the array: ");
                try
                {
                    size = int.Parse(Console.ReadLine());
                }
                catch (FormatException)
                {
                    Console.WriteLine("Invalid input!");
                    size = 0;
                }

            } while (size <= 0);

            array = new int[size];

            for (int i = 0; i < size; i++)
            {
                array[i] = random.Next(10, 99);
            }


            return array;
        }
        
        public static void MostCommonNumber(int[] array)
        {
            int mostCommon = array[0];
            int maxOccurences = 0;
            int occurences = 0;
            
            for(int i = 0; i < array.Length; i++)
            {
                occurences = 0;

                for (int j = 0; j < array.Length; j++)
                {
                    if (array[j] == array[i])
                    {
                        occurences++;
                    }
                }

                if (occurences > maxOccurences)
                {
                    mostCommon = array[i];
                    maxOccurences = occurences;
                }
            }

            if (maxOccurences > 1)
            {
                Console.WriteLine($"The most common number: {mostCommon}\nIts occurrences: {maxOccurences}\n");
            }
            else
            {
                Console.WriteLine("There are no repeated numbers!\n");
            }
        }

        public static void MagicSquare(int[,] matrix)
        {
            int rowsSum = 0;
            int columnsSum = 0;
            int d1Sum = 0;
            int d2Sum = 0;

            for(int i = 0; i < matrix.GetLength(0); i++)
            {
                rowsSum += matrix[0, i];
            }

            for(int i = 0; i < matrix.GetLength(1); i++)
            {
                columnsSum += matrix[i, 0];
            }

            for(int i = 0, j = 0; i < matrix.GetLength(1) && j < matrix.GetLength(0); i++, j++)
            {
                d1Sum += matrix[i, j];
            }

            for(int i = matrix.GetLength(1) - 1, j = matrix.GetLength(0) - 1; i >= 0 && j >= 0; i--, j--)
            {
                d2Sum += matrix[i, j];
            }

            if(rowsSum == columnsSum && columnsSum == d1Sum && d1Sum == d2Sum)
            {
                Console.WriteLine("The matrix is a Magic Square!\n");
            }
            else
            {
                Console.WriteLine("The matrix is NOT a Magic Square!\n");
            }
        }

        public static int[,] EnterMatrixElements()
        {
            int[,] matrix;
            int size;

            do
            {
                Console.Write("Enter the size of the matrix: ");
                try
                {
                    size = int.Parse(Console.ReadLine());
                }
                catch (Exception)
                {
                    Console.Write("Invalid input!");
                    size = 0;
                }
            } while (size < 0);

            matrix = new int[size, size];
            Console.WriteLine("Enter matrix elements in range 1 to 20");

            for (int i = 0; i < size; i++)
            {
                for (int j = 0; j < size; j++)
                {
                    do
                    {
                        try
                        {
                            Console.Write($"matrix[{i},{j}]: ");
                            matrix[i, j] = int.Parse(Console.ReadLine());
                        }
                        catch (Exception)
                        {
                            Console.WriteLine("Invalid input!");
                            matrix[i, j] = 0;
                        }

                    } while(matrix[i, j] < 1 || matrix[i, j] > 20);
                }
            }


            return matrix;
        }

        public static void MonotonicallyIncreasingNumbers(double[] numbers)
        {
            bool monotonical = false;
            for (int i = 0; i < numbers.Length - 1; i++)
            {
                if (! (numbers[i + 1] >= numbers[i]))
                {
                    monotonical = false;
                    Console.WriteLine("The numbers are not monotonically increasing\n");
                    return;
                }
                else if (numbers[i + 1] == numbers[i])
                {
                    monotonical = true;
                }
            }
            if (monotonical)
            {
                Console.WriteLine("The numbers are monotonically increasing\n");
            }
            else
            {
                Console.WriteLine("The numbers are not monotonically increasing\n");
            }
        }

        public static double[] EnterNumbers()
        {
            double[] numbers = new double[9];

            Console.WriteLine("Enter 9 numbers in range [-99.99...99.99]");
            for(int i = 0; i < numbers.Length; i++)
            {
                do
                {
                    try
                    {
                        numbers[i] = double.Parse(Console.ReadLine());
                    }
                    catch (Exception)
                    {
                        Console.WriteLine("Invalid input!");
                        numbers[i] = -100;
                    }
                } while(numbers[i] > 99.99 || numbers[i] < -99.99);
            }

            return numbers;
        }

        public static long CloseToPrimeNum()
        {
            int number;
            long prime = 0;
            bool notPrime = false;

            do
            {
                try
                {
                    Console.Write("Enter a number in range 10 to 100010: ");
                    number = int.Parse(Console.ReadLine());
                }
                catch (Exception)
                {
                    Console.WriteLine("Invalid input!");
                    number = 0;
                }
            } while (number < 10 || number > 100010);

            for (long i = number + 1; i < number * 2; i++)
            {
                notPrime = false;

                for (int j = 2; j < i / 2; j++)
                {
                    if(i % j == 0)
                    {
                        notPrime = true;
                        j = (int)i;
                    }
                }

                if (!notPrime)
                {
                    prime = i;
                    break;
                }
            }

            return prime;
        }

        public static int SumOfDigits(int number)
        {
            if(number == 0)
            {
                return 0;
            }

            return (number % 10 + SumOfDigits(number / 10));
        }

        public static void PrintArray(int[] array)
        {
            for (int i = 0; i < array.Length; i++)
            {
                System.Console.Write(array[i] + " ");
            }
            Console.WriteLine();
        }

        public static void PrintMatrix(int[,] matrix)
        {
            for(int i = 0; i < matrix.GetLength(0); i++)
            {
                for(int j = 0; j < matrix.GetLength(1); j++)
                {
                    Console.Write(matrix[i, j] + " ");
                }
                Console.WriteLine();
            }
        }
    }
}
