using System;

namespace Homework
{
    class MainClass
    {
        public static void Main()
        {
            Garden garden = new Garden();
            Peach peach = new Peach();
            Apricot apricot = new Apricot();
            Acacia acacia = new Acacia();
            Oak oak = new Oak();
            Lily lily = new Lily();
            Rose rose = new Rose();
            Carotte carotte = new Carotte();
            Strawberry strawberry = new Strawberry();

            double beautyScore = 0;
            double waterRequired = 0;
            double energy = 0;
            string command;
            string[] splitedCommand = new string[2];
            string name;
            int quantity;

            do
            {
                command = Console.ReadLine().ToLower();

                if (command != "end" && command != null)
                {
                    splitedCommand = command.Split(' ');
                    name = splitedCommand[0];

                    try
                    {
                        quantity = int.Parse(splitedCommand[1]);
                    }
                    catch (FormatException)
                    {
                        Console.WriteLine("Invalid input!");
                        continue;
                    }
                }
                else
                {
                    continue;
                }

                switch (name)
                {
                    case "peach":
                        energy += quantity * peach.Energy;
                        waterRequired += quantity * peach.WaterRequired;
                        break;
                    case "apricot":
                        energy += quantity * apricot.Energy;
                        waterRequired += quantity * apricot.WaterRequired;
                        break;
                    case "acacia":
                        beautyScore += quantity * acacia.BeautyScore;
                        waterRequired += quantity * acacia.WaterRequired;
                        break;
                    case "oak":
                        beautyScore += quantity * oak.BeautyScore;
                        waterRequired += quantity * oak.WaterRequired;
                        break;
                    case "lily":
                        beautyScore += quantity * lily.BeautyScore;
                        waterRequired += quantity * lily.WaterRequired;
                        break;
                    case "rose":
                        beautyScore += quantity * rose.BeautyScore;
                        waterRequired += quantity * rose.WaterRequired;
                        break;
                    case "carotte":
                        energy += quantity * strawberry.Energy;
                        waterRequired += quantity * strawberry.WaterRequired;
                        break;
                    case "strawberry":
                        energy += quantity * strawberry.Energy;
                        waterRequired += quantity * strawberry.WaterRequired;
                        break;
                    default:
                        Console.WriteLine("Invalid input!");
                        break;
                }



            } while (command != "end");

            Console.WriteLine();

            if (beautyScore == 0 && energy == 0 && waterRequired == 0)
            {
                Console.WriteLine("There are any plants in the garden");
            }
            else
            {
                Console.WriteLine($"BeautyScore: {beautyScore}");
                Console.WriteLine($"WaterRequired: {waterRequired}");
                Console.WriteLine($"Energy: {energy}");
            }

        }
    }
}
