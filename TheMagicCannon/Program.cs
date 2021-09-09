using System;

namespace TheMagicCannon
{
    class Program
    {
        static void Main(string[] args)
        {
            

            for (int i = 1; i <= 100 ;i++)
            {
                string mode = "Normal";
                Console.ForegroundColor = ConsoleColor.White;

                if (i %3 == 0)
                {
                    mode = "Fire";
                    Console.ForegroundColor = ConsoleColor.Red;
                }

                if (i % 5 == 0)
                {
                    mode = "Electric";
                    Console.ForegroundColor = ConsoleColor.Yellow;
                }

                if (i % 5 == 0 && i % 3 ==0)
                {
                    mode = "Fire&Electric";
                    Console.ForegroundColor = ConsoleColor.Blue;
                }

                Console.WriteLine($"{i,2}: {mode}");
                Console.ReadKey();
            }
        }
    }
}
