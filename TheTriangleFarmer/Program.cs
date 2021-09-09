using System;

namespace TheTriangleFarmer
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Enter the length of the base of the triangle");
            string baseInput = Console.ReadLine();

            Console.WriteLine("Enter the height of the triangle");
            string heightInput = Console.ReadLine();

            int triangleBase = Convert.ToInt32(baseInput);
            int triangleHeight = Convert.ToInt32(heightInput);

            int areaResult = (triangleBase * triangleHeight) / 2;

            Console.WriteLine("The area of the triangle is " + areaResult);
        }
    }
}
