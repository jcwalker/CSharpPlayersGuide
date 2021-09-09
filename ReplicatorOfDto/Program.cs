using System;

namespace ReplicatorOfDto
{
    class Program
    {
        static void Main(string[] args)
        {
            int[] list = new int[5];
            int[] listCopy = new int[5];

            for (int i = 0;i < 5; i++)
            {
                Console.WriteLine("Enter a number 5 times");
                var input = Console.ReadLine();
                list[i] = Convert.ToInt32(input);
            }

            for (int index = 0; index < list.Length; index++)
            {
                listCopy[index] = list[index];
            }

            for (int index = 0; index < list.Length; index++)
            {
                Console.WriteLine($"OG list {list[index]} copy list {listCopy[index]}");
            }
        }
    }
}
