using System;

namespace Homework
{
    class MainClass
    {
        public static void Main()
        {
            // 1 Задача

            List<int> firstList = new List<int> { 1, 2, 3, 4, 5, 6 };
            List<int> secondList = new List<int> { 4, 5, 6, 7, 8, 9, 10};
            List<int> sectionList = new List<int>();
            List<int> mergedList = new List<int>();

            // Сечение
            sectionList = SectionLists(firstList, secondList);
            Console.Write("Section List: ");
            PrintList(sectionList);

            // Обединение
            mergedList = MergeLists(firstList, secondList);
            Console.Write("Merged List: ");
            PrintList(mergedList);


            // 2 Задача

            List<int> list = new List<int> { 1, 1, 1, 2, 2, 3, 3, 3, 3, 3, 3, 4, 5, 5, 6, 6, 6, 6, 7, 7, 7, 8, 9, 0, 0};
            List<int> longest = new List<int>();

            Console.Write("Longest List of Equal Numbers: ");
            longest = LongestEqualNumbers(list);
            PrintList(longest);


            // 3 Задача

            List<int> listWithNegativeNums = new List<int> { 0, -1, -12, 4, 2, 41, 7, -8, -3, 32 };

            Console.Write("Positive List: ");
            RemoveNegativeNums(listWithNegativeNums);
            PrintList(listWithNegativeNums);


            // 4 Задача

            
            
            
        }

        public static List<int> MergeLists(List<int> first, List<int> second)
        {
            return first.Concat(second).ToList();
        }

        public static List<int> SectionLists(List<int> first, List<int> second)
        {
            List<int> list = new List<int>();

            for (int i = 0; i < first.Count; i++)
            {
                for (int j = 0; j < second.Count; j++)
                {
                    if (first[i] == second[j])
                    {
                        list.Add(first[i]);
                    }
                }
            }


            return list;
        }

        public static List<int> LongestEqualNumbers(List<int> list)
        {
            List<int> longest = new List<int>();
            int counter = 0, maxCounted = 0;
            int numberValue = 0;

            for (int i = 0; i < list.Count; i++)
            {
                if (i == 0)
                {
                    numberValue = list[i];
                    counter++;
                }
                else if (list[i] == list[i-1])
                {
                    counter++;
                }
                else if (list[i] != list[i-1])
                {
                    if (counter > maxCounted)
                    {
                        numberValue = list[i-1];
                        maxCounted = counter;
                    }

                    counter = 1;
                }
            }

            for (int i = 0; i < maxCounted; i++)
            {
                longest.Add(numberValue);
            }

            return longest;
        }

        public static void RemoveNegativeNums(List<int> list)
        {
            List<int> toRemove = new List<int>();

            foreach (int i in list)
            {
                if (i < 0)
                {
                    toRemove.Add(i);
                }
            }

            foreach (int i in toRemove)
            {
                list.Remove(i);
            }
        }

        public static void PrintList(List<int> list)
        {
            foreach (int item in list)
            {
                Console.Write(item + " ");
            }
            Console.WriteLine();
        }
    }
}