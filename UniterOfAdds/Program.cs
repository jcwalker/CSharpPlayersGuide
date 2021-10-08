using System;

int usingInts = Adds.Add(2, 3);
Console.WriteLine($"Using ints result {usingInts}");

double usingDoubles = Adds.Add(1.3, 3.4);
Console.WriteLine($"Using doubles result {usingDoubles}");

string usingStrings = Adds.Add("Hello", " World!");
Console.WriteLine($"Using strings result {usingStrings}");


var dateTime = DateTime.Now;
var timespan = new TimeSpan(2, 1, 5);

var usingDateTime = Adds.Add(dateTime, timespan);
Console.WriteLine($"Using DateTime Year {usingDateTime.Year} Month {usingDateTime.Month} Day {usingDateTime.Day}");


public static class Adds
{
    public static dynamic Add(dynamic a, dynamic b) => a+b;
}
