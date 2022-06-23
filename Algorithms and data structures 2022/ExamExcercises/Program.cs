using System;

namespace Exam
{
    class MainClass
    {
        public static void Main()
        {
            // Да се провери дали даден низ е симетричен.  ->  Symmetrical()
            string word = "yoyo";
            bool isSymmetrical = Symmetrical(word);
            if (isSymmetrical)
            {
                Console.WriteLine($"The word {word} is symmetrical.");
            }
            else
            {
                Console.WriteLine($"The word {word} is not symmetrical.");
            }


            // Даден е масив. Да се намери най-дългата поредица от равни елементи.  ->  LongestEqualNumbers()
            int[] array = {1, 1, 1, 1, 2, 3, 3, 3, 3, 3, 4, 4, 5, 6, 6, 6, 7, 7};
            int[] longest = LongestEqualNumbers(array);
            Console.Write("Longest equal numbers: ");
            PrintIntArray(longest);
            Console.WriteLine();


            // Два сортирани списъка да се слеят в трети списък, който също да е сортиран (да не се използва метода Sort).  ->  MergeLists(), BubbleSort()
            List<int> list1 = new List<int>() { 1, 2, 5, 7, 8, 9 };
            List<int> list2 = new List<int>() { 2, 3, 5, 6, 7, 8};
            List<int> mergedLists = MergeLists(list1, list2);
            Console.Write("Merged list: ");
            PrintList(mergedLists);
            BubbleSort(mergedLists);
            Console.Write("Merged sorted list: ");
            PrintList(mergedLists);
            Console.WriteLine("");


            // Имаме сортиран масив. Да се намери средното аритметично на всеки подмасив, в който съседните елементи се различават с 1 или 2.  ->  AritmeticalSumOfSubarrays()
            int[] sortedArray = { 1, 2, 4, 5, 7, 12, 15, 17, 18 };
            AritmeticalSumOfSubarrays(sortedArray);
            Console.WriteLine();


            // Да се провери дали зададена квадратна матрица е симетрична спрямо обратния си диагонал.  ->  CheckMatrix()
            int[,] matrix1 =
            {
                {0, 0, 0, 0, 1 },
                {0, 0, 0, 1, 0 },
                {0, 0, 1, 0, 0 },
                {0, 1, 0, 0, 0 },
                {1, 0, 0, 0, 0 }
            };
            int[,] matrix2 =
            {
                {0, 0, 0, 0, 1 },
                {0, 0, 0, 1, 0 },
                {2, 0, 1, 0, 0 },
                {0, 1, 0, 5, 0 },
                {1, 0, 0, 0, 0 }
            };


            bool matrixSymmetry1 = CheckMatrix(matrix1);
            if (matrixSymmetry1)
            {
                Console.WriteLine("The matrix is symmetrical to its inverse diagonal.");
            }
            else
            {
                Console.WriteLine("The matrix is not symmetrical.");
            }
            bool matrixSymmetry2 = CheckMatrix(matrix2);
            if (matrixSymmetry2)
            {
                Console.WriteLine("The matrix is symmetrical to its inverse diagonal.");
            }
            else
            {
                Console.WriteLine("The matrix is not symmetrical.");
            }


        }

        public static bool Symmetrical(string word)
        {
            string firstHalf = "";
            string secondHalf = "";
            int midIndex = 0;

            if (word.Length % 2 == 0)
            {
                midIndex = word.Length / 2;
            }
            else
            {
                midIndex = (word.Length / 2) + 1;
            }

            int firstIndex = 0;
            int secondIndex = midIndex;

            while (firstIndex < midIndex && secondIndex < word.Length)
            {
                firstHalf += word[firstIndex];
                secondHalf += word[secondIndex];
                firstIndex++;
                secondIndex++;
            }

            if (firstHalf == secondHalf)
            {
                return true;
            }
            
            return false;
        }

        public static int[] LongestEqualNumbers(int[] array)
        {
            int maxCounted = 0, currentCount = 0;
            int numberValue = 0;

            for (int idx = 0; idx < array.Length; idx++)
            {
                if (idx == 0)
                {
                    currentCount++;
                    numberValue = array[idx];
                }
                else if (array[idx] == array[idx-1])
                {
                    currentCount++;
                }
                else if (array[idx] != array[idx-1])
                {
                    if (currentCount > maxCounted)
                    {
                        maxCounted = currentCount;
                        numberValue = array[idx-1];
                    }
                    currentCount = 1;
                }
            }

            int[] longest = new int[maxCounted];

            for (int idx = 0; idx < maxCounted; idx++)
            {
                longest[idx] = numberValue;
            }

            return longest;
        } 

        public static void PrintIntArray(int[] array)
        {
            foreach (int i in array)
            {
                Console.Write(i + " ");
            }
            Console.WriteLine();
        }

        public static List<int> MergeLists(List<int> first, List<int> second)
        {
            List<int> merged =  first.Concat(second).ToList();
            return merged;
        }

        public static void BubbleSort(List<int> list)
        {
            for (int i = 0; i < list.Count - 1; i++)
            {
                for (int j = 0; j < list.Count - i - 1; j++)
                {
                    if (list[j] > list[j + 1])
                    {
                        int temp = list[j];
                        list[j] = list[j + 1];
                        list[j + 1] = temp;
                    }
                }
            }
           
        }

        public static void PrintList(List<int> list)
        {
            foreach(int i in list)
            {
                Console.Write(i + " ");
            }
            Console.WriteLine();
        }

        public static void AritmeticalSumOfSubarrays(int[] array)
        {
            List<List<int>> listOfLists = new List<List<int>>();
            List<int> list = new List<int>();
            float sum = 0;

            for (int idx = 0; idx < array.Length; idx++)
            {
                if (idx == 0)
                {
                    list = new List<int>();
                    list.Add(array[idx]);
                }
                else if (array[idx] == array[idx-1] + 1 || array[idx] == array[idx-1] + 2)
                {
                    list.Add(array[idx]);
                    if (idx == array.Length - 1)
                    {
                        listOfLists.Add(list);
                    }
                }
                else
                {
                    listOfLists.Add(list);
                    list = new List<int>();
                    list.Add(array[idx]);
                }
            }


            foreach (List<int> l in listOfLists)
            {
                sum = 0;
                foreach (int i in l)
                {
                    sum += i;
                }
                Console.Write($"Average sum: {sum/l.Count}  of subarray ");
                PrintList(l);
            }

        }

        public static bool CheckMatrix(int[,] matrix)
        {
            int col = matrix.GetLength(1)-1;
            int row = 0;
            string upper = "", lower = "";

            while (row < matrix.GetLength(0))
            {
                bool lowerPart = false;

                for (int i = 0; i < matrix.GetLength(1); i++)
                {
                    if (matrix[row, i] == matrix[row, col])
                    {
                        lowerPart = true;
                        continue;
                    }

                    if (lowerPart)
                    {
                        lower += matrix[row, i];
                    }
                    else
                    {
                        upper += matrix[row, i];
                    }
                }

                row++;
                col--;
            }

            lower.Reverse();

            if (upper != lower)
            {
                return false;
            }


            return true;
        }

    }
}
