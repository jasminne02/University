using System;

namespace ConsoleApp5
{
    class MainClass
    {
        public static void Main()
        {
            string message;
            int seconds;

            Console.Write("Your message: ");
            message = Console.ReadLine();

            do
            {
                Console.Write("The alarm time in seconds: ");
                try
                {
                    seconds = int.Parse(Console.ReadLine());
                }
                catch (FormatException)
                {
                    Console.WriteLine("Invalid input!");
                    seconds = -1;
                }
            } while (seconds < 0);

            CountdownClock alarm = new CountdownClock(message, seconds);
            
        }
    }
}
