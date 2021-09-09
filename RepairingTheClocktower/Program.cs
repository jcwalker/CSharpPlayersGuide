using System;

namespace RepairingTheClocktower
{
    class Program
    {
        static void Main(string[] args)
        {
            int validateResult = 0;
            Console.Write("Enter a number: ");
            var input = Console.ReadLine();

            while(!int.TryParse(input, out validateResult))
            {
                Console.WriteLine("Please enter a number.");
                input = Console.ReadLine();
            }

            int intInput = Convert.ToInt32(input);

            if (intInput %2 == 0)
            {
                Console.WriteLine("Tick");
                return;
            }

            Console.WriteLine("Tock");
        }
    }
}
