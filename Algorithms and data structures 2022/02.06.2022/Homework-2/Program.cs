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

            DoublyLinkedList doublyLinkedList = new DoublyLinkedList();
            doublyLinkedList.add(1);
            doublyLinkedList.add(12);
            doublyLinkedList.add(34);
            doublyLinkedList.add(5);

            doublyLinkedList.deleteNode(doublyLinkedList.head);

            int[] array = doublyLinkedList.returnListElementsAsArray(doublyLinkedList.head);
            Console.Write("Doubly Linked List: ");
            PrintArray(array);

            doublyLinkedList.InsertAt(1, 90);
            array = doublyLinkedList.returnListElementsAsArray(doublyLinkedList.head);
            Console.Write("Doubly Linked List: ");
            PrintArray(array);

            int index = 0;
            int value = doublyLinkedList.GetElementValueAtIndex(index);
            Console.WriteLine($"Value at index {index}: {value}");

            int elementValue = 34;
            int indexAt = doublyLinkedList.SearchForElement(elementValue);
            Console.WriteLine($"The element {elementValue} is at index {indexAt}");

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

        public static void PrintArray(int[] array)
        {
            for (int i = 0; i < array.Length; i++)
            {
                Console.Write(array[i] + " ");
            }
            Console.WriteLine();
        }
    }

    class DoublyLinkedList
    {
        public Node head;
        public static int size;

        public class Node
        {
            public int data;
            public Node prev;
            public Node next;

            public Node(int d)
            {
                data = d;
            }
        }

        public void add(int newData)
        {
            Node newNode = new Node(newData);
            Node last = head;
            newNode.next = null;

            if (head == null)
            {
                newNode.prev = null;
                head = newNode;
                size++;
                return;
            }

            while (last.next != null)
                last = last.next;

            last.next = newNode;

            newNode.prev = last;
            size++;
        }

        public void deleteNode(Node node)
        {
            if (head == null || node == null)
            {
                return;
            }

            if (head == node)
            {
                head = node.next;
            }

            if (node.next != null)
            {
                node.next.prev = node.prev;
            }

            if (node.prev != null)
            {
                node.prev.next = node.next;
            }

            size--;
            return;
        }

        public void InsertAt(int index, int newData)
        {

            if (index < 0 || index > size)
            {
                Console.WriteLine("Invalid index!");
                return;
            }
            else if (index == 0)
            {
                Node newNode = new Node(newData);

                newNode.next = head;
                newNode.prev = null;

                if (head != null)
                    head.prev = newNode;

                head = newNode;
            }
            else if(index == size)
            {
                this.add(newData);
            }
            else
            {
                Node currentNode = head;
                Node prevNode = head;

                for (int i = 0; i < index; i++)
                {
                    if (i == index)
                    {
                        prevNode = currentNode;
                    }
                    currentNode = currentNode.next;
                }

                Node newNode = new Node(newData);

                newNode.next = prevNode.next;

                prevNode.next = newNode;

                newNode.prev = prevNode;

                if (newNode.next != null)
                    newNode.next.prev = newNode;

            }
            

            size++;
        }

        public int GetElementValueAtIndex(int index)
        {
            int value = 0;
            Node currentNode = head;

            for (int i = 0; i <= index; i++)
            {
                value = currentNode.data;
                currentNode = currentNode.next;
            }

            return value;
        }

        public int SearchForElement(int value)
        {
            int index = 0;
            Node node = head;

            for (int i = 0; i < size; i++)
            {
                if(node.data == value)
                {
                    index = i;
                    break;
                }

                node = node.next;
            }

            return index;
        }

        public int[] returnListElementsAsArray(Node node)
        {
            int[] array = new int[size];
            int index = 0;

            while (node != null)
            {
                array[index] = node.data;
                index++;
                if (index == size)
                {
                    break;
                }
                node = node.next;
            }

            return array;
        }
    }
}