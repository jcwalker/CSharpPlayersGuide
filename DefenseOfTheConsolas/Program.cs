using System;

namespace DefenseOfTheConsolas
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Target Row?");
            var row = Console.ReadLine();
            int rowInt = Convert.ToInt32(row);

            Console.WriteLine("Target Column?");
            var column = Console.ReadLine();
            int columnInt = Convert.ToInt32(column);

            // calculate one left
            Console.WriteLine($"{rowInt},{columnInt -1}");
            // calculate one down
            Console.WriteLine($"{rowInt -1},{columnInt}");
            // caluculate one up
            Console.WriteLine($"{rowInt},{columnInt +1}");
            // caluculate one right
            Console.WriteLine($"{rowInt +1},{columnInt}");
            Console.Beep();
        }
    }
}
