using System;

namespace Exam
{
    class MainClass
    {
        public static void Main()
        {
            char[,] matrix =
            {
                { 'a', 'a', 'b', 'b', 'a' },
                { 'a', 'a', 'b', 'b', 'a' },
                { 'a', 'a', 'a', 'c', 'b' }
            };

            int areasCount = 0;

            for (int r = 0; r < matrix.GetLength(0); r++)
            {
                for (int c = 0; c < matrix.GetLength(1); c++)
                {
                    if (r == 0)
                    {
                        if (c == 0)
                        {
                            areasCount++;
                        }
                        else
                        {
                            if (matrix[r, c] != matrix[r, c - 1])
                            {
                                areasCount++;
                            }
                        }
                    }
                    else
                    {
                        if (c == 0)
                        {
                            if (matrix[r,c] != matrix[r-1, c])
                            {
                                areasCount++;
                            }
                        }
                        else
                        {
                            if (matrix[r,c] != matrix[r, c - 1] && matrix[r,c] != matrix[r-1, c])
                            {
                                areasCount++;
                            }
                        }
                    }
                }
            }

            Console.WriteLine($"There are {areasCount} different areas in the matrix.");
        }
    }
}
