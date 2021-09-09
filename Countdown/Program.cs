using System;

namespace Countdown
{
    class Program
    {
        static void Main(string[] args)
        {
            int CountDown(int number)
            {
                if (number == 1) return number;
                Console.WriteLine(number);
                return CountDown(number - 1);
            }

            CountDown(10);
        }
    }
}
