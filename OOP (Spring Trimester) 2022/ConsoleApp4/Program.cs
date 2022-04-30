using System;

namespace ConsoleApp4
{
    class MainClass
    {
        public static void Main()
        {
            Factory factory1 = new Factory();
            Factory factory2 = new Factory();
            Factory factory3 = new Factory();

            factory1.MakeADetail(23, 54.3, 12);
            factory1.MakeADetail(58, 62.34, 3);
            factory1.MakeADetail(6, 3.32, 43);
            factory1.MakeADetail(23, 5.3, 12);

            factory2.MakeADetail(6, 3.2, 4);
            factory2.MakeADetail(87, 1.3, 21);
            factory2.MakeADetail(90, 3.32, 3);

            factory3.MakeADetail(58, 62.34, 3);
            factory3.MakeADetail(5, 34.6, 53);


            Console.WriteLine($"Factory 1 has made {factory1.MadeDetails} details");
            Console.WriteLine($"Factory 2 has made {factory2.MadeDetails} details");
            Console.WriteLine($"Factory 3 has made {factory3.MadeDetails} details");
        }
    }
}
