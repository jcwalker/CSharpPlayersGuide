using System;

namespace TheLawsOfFreach
{
    class Program
    {
        static void Main(string[] args)
        {
            int[] array = new int[] { 4, 51, -7, 13, -99, 15, -8, 45, 90 };
            int currentMinimum = int.MaxValue;
            int total = 0;

            foreach (int index in array)
            {
                if (index < currentMinimum)
                {
                    currentMinimum = index;
                }

                total += index;
            }

            float average = (float) total / array.Length;
            Console.WriteLine($"Average values in the array {average}");
            Console.WriteLine($"Minimum value in the array {currentMinimum}");
        }
    }
}
