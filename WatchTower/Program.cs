using System;

namespace WatchTower
{
    class Program
    {
        static void Main(string[] args)
        {
            string firstDirection  = "";
            string secondDirection = "";

            Console.Write("Enter X cordinates: ");
            var inputX = Console.ReadLine();
            int intX = Convert.ToInt32(inputX);

            Console.Write("Enter Y coordinates: ");
            var inputY = Console.ReadLine();
            int intY = Convert.ToInt32(inputY);


            if (intY > 0)
            {
                firstDirection = "N";
            }
            else if (intY < 0)
            {
                firstDirection = "S";
            }

            if (intX > 0)
            {
                secondDirection = "E";
            }
            else if (intX < 0)
            {
                secondDirection = "W";
            }

            if (intX == 0 && intY ==0)
            {
                Console.WriteLine("The enemy is here!");
            }
            else
            {
                Console.WriteLine($"The enemy is to the {firstDirection + secondDirection}");
            }
        }
    }
}
