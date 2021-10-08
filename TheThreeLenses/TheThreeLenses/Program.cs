using System;
using System.Collections.Generic;
using System.Linq;

int[] numberList = { 1, 9, 2, 8, 3, 7, 4, 6, 5 };

List<int> numberListResult = numberList.ToList<int>();

foreach (int number in numberList)
{
    if (number % 2 != 0)
    {
        numberListResult.Remove(number);
    }
}

numberListResult.Sort();

Console.WriteLine("Using procedural code.");
foreach (int n in numberListResult)
{
    Console.Write($"{n * 2} ");
}

Console.WriteLine();

///////////////////////////////////


Console.WriteLine("Using keyword based queries");
IEnumerable<int> everything = from number in numberList
                              where number % 2 == 0
                              orderby number ascending
                              select (number * 2);

foreach (int n in everything)
{
    Console.Write($"{n} ");
}

Console.WriteLine();

/////////////////////////////////////
Console.WriteLine("Using keyword based queries");
IEnumerable<int> everything2 = numberList
                               .Where(number => number % 2 == 0)
                               .OrderBy(number => number)
                               .Select(number => number * 2);

foreach (int n in everything2)
{
    Console.Write($"{n} ");
}
