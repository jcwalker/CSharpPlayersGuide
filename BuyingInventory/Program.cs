using System;

namespace BuyingInventory
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("The following items are available:");
            Console.WriteLine("1 - Rope");
            Console.WriteLine("2 - Torches");
            Console.WriteLine("3 - Climbing Equipment");
            Console.WriteLine("4 - Clean Water");
            Console.WriteLine("5 - Machete");
            Console.WriteLine("6 - Canoe");
            Console.WriteLine("7 - Food Supplies");
            Console.Write("What number so you want to see the price of? ");

            var input = Console.ReadLine();
            int choice = Convert.ToInt32(input);

            string response;

            response = choice switch
            {
                1 => "Rope 10 gold.",
                2 => "Torches 15 gold.",
                3 => "Climbing Equipment 25 gold",
                4 => "Clean Water 1 gold",
                5 => "Machete 20 gold.",
                6 => "Canoe 200 gold.",
                7 => "Food supplies 1 gold",
                _ => "That is not an option."
            };

            Console.WriteLine(response);
        }
    }
}
