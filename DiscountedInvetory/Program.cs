using System;
using System.Collections;

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
            Console.Write("Enter your name: ");
            var name = Console.ReadLine();
            int price = 0;
            Hashtable answer = new Hashtable();

            //string response;

            switch (choice)
            {
                case 1:
                    answer.Add("Supply", "Rope");
                    answer.Add("Price", "10");
                    break;
                case 2:
                    answer.Add("Supply", "Torches");
                    answer.Add("Price", "15");
                    break;
                case 3:
                    answer.Add("Supply", "Equipment");
                    answer.Add("Price", "25");
                    break;
                case 4:
                    answer.Add("Supply", "Clean Water");
                    answer.Add("Price", "1");
                    break;
                case 5:
                    answer.Add("Supply", "Machete");
                    answer.Add("Price", "20");
                    break;
                case 6:
                    answer.Add("Supply", "Canoe");
                    answer.Add("Price", "200");
                    break;
                case 7:
                    answer.Add("Supply", "Food supplies");
                    answer.Add("Price", "1");
                    break;
                default:
                    answer.Add("Supply", choice);
                    answer.Add("Price", "That is not an option.");
                    break;
            };

            if (name == "Jason")
            {
                price = Convert.ToInt32(answer["Price"]) / 2;
            }
            else
            {
                price = Convert.ToInt32(answer["Price"]);
            }

            Console.WriteLine("{0} {1}", answer["Supply"], price);
        }
    }
}
