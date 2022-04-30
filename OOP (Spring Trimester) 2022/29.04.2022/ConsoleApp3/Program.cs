using System;

namespace ConsoleApp3
{
    class MainClass
    {
        public static void Main()
        {
            Musician musician1 = new Musician("Alex", "088 232 3423", "Plovdiv");
            Musician musician2 = new Musician("Daniel", "089 236 5687", "Sofia");
            Musician musician3 = new Musician("Bob", "088 785 453 7853", "Plovdiv");
            Musician musician4 = new Musician("John", "089 348 598 5984", "Varna");

            Group group1 = new Group();
            group1.Add(musician1);
            group1.Add(musician2);
            group1.Add(musician3);
            group1.Add(musician4);

            string[] songsNames = { "Hello", "Song", "Sun", "Bye", "Summer", "Apple"};
            CD cd = new CD(group1, "Name", songsNames.Length, 3.45, songsNames);

            string[] songs = cd.GetTracks();
            Console.Write("Songs: ");
            for(int i = 0; i < songs.Length; i++)
            {
                Console.Write(i == songs.Length - 1 ? (songs[i] + "\n") : (songs[i] + ", "));
            }

            double duration = cd.GetLength();
            Console.WriteLine($"CD lenght: {duration.ToString("0.00")}");
        }
    }
}
