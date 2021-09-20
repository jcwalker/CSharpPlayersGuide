using System;

namespace TheFeud
{
    using Flame;
    using Frost;
    using FlamePig = Flame.Pig; // using an alias

    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Create objects from both namespaces");

            Flame.Pig flamePig = new Flame.Pig();
            Sheep flameSheep = new Sheep();

            Frost.Pig frostPig = new Frost.Pig();
            Cow frostCow = new Cow();

            FlamePig flamePig2 = new FlamePig(); // using an alias

            Console.WriteLine($"{flamePig.ToString()}");
            Console.WriteLine($"{flameSheep.ToString()}");
            Console.WriteLine($"{frostPig.ToString()}");
            Console.WriteLine($"{frostCow.ToString()}");
            Console.WriteLine($"{flamePig2.ToString()}");
        }
    }
}
