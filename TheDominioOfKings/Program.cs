using System;

namespace TheDominioOfKings
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Enter the number of owned provinces");
            string provinces = Console.ReadLine();

            Console.WriteLine("Enter the number of owned duchies");
            string duchies = Console.ReadLine();

            Console.WriteLine("Enter the number of owned estates");
            string estates = Console.ReadLine();

            int provinceScore = Convert.ToInt32(provinces) * 6;
            int duchiesScore = Convert.ToInt32(duchies) * 3;
            int estateScore = Convert.ToInt32(estates);
            int totalScore = provinceScore + duchiesScore + estateScore;

            Console.WriteLine("Total points: " + totalScore);
        }
    }
}
