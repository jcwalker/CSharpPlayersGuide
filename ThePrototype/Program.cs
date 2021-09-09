using System;

namespace ThePrototype
{
    class Program
    {
        static void Main(string[] args)
        {
            int toBeGuessed = 0;
            int guessed = 0;
            do
            {
                Console.WriteLine("Enter a between 0 and 100");
                var input = Console.ReadLine();
                toBeGuessed = Convert.ToInt32(input);
            }
            while (toBeGuessed < 0 || toBeGuessed > 100);

            Console.Clear();

            do
            {
                Console.WriteLine("Try to guess the number entered");
                var input = Console.ReadLine();
                guessed = Convert.ToInt32(input);

                if (guessed < toBeGuessed)
                {
                    Console.WriteLine("{0} is too low", guessed);
                }

                if (guessed > toBeGuessed)
                {
                    Console.WriteLine("{0} is too high", guessed);
                }
            }
            while (guessed != toBeGuessed);

            Console.WriteLine("You guessed the number!!!");
        }
    }
}
