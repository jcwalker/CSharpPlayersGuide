using System;

namespace CSharpPlayersGuideHellowWorld
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Bread is ready.");
            Console.WriteLine("Who is ready for bread?");
            var name = Console.ReadLine();
            Console.WriteLine("Noted: " + name + " got bread.");
        }
    }
}
