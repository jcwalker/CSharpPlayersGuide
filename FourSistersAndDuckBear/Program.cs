using System;

namespace FourSistersAndDuckBear
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Enter the number of chocolate eggs");
            string numberOfEggs = Console.ReadLine();

            int numberOfEggsAsInt = Convert.ToInt32(numberOfEggs);

            int numberOfEggsPerSister = numberOfEggsAsInt / 4;

            int eggsForDuckBear = numberOfEggsAsInt % 4;

            Console.WriteLine("Each sister gets " + numberOfEggsPerSister + " eggs");
            Console.WriteLine("The duckbear gets " + eggsForDuckBear + " eggs");
        }
    }
}
