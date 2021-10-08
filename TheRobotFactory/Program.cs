using System;
using System.Collections.Generic;
using System.Dynamic;

int robotCounter = 0;
while (true)
{
    robotCounter++;
    Console.WriteLine($"You are producing robot #{robotCounter}");
    dynamic robot = new ExpandoObject();
    robot.Id = robotCounter;

    Console.Write("Do you want to name this robot? ");
    var nameResult = Console.ReadLine().ToLower();

    if (nameResult == "yes")
    {
        Console.Write("What is the name? ");
        var name = Console.ReadLine();
        robot.Name = name;
    }

    Console.Write("Does this robat have a specific size? ");
    var sizeResult = Console.ReadLine().ToLower();
    if (sizeResult == "yes")
    {
        Console.Write("What is the height? ");
        var heightResult = Console.ReadLine();
        Console.Write("What is the widith? "); ;
        var widthResult = Console.ReadLine();

        robot.Height = heightResult;
        robot.Width = widthResult;
    }

    Console.Write("Does this robot need to be a specific color? ");
    var colorAsk = Console.ReadLine().ToLower();
    if (colorAsk == "yes")
    {
        Console.Write("What color? ");
        var colorResult = Console.ReadLine();
        robot.Color = colorResult;
    }

    foreach (KeyValuePair<string, object> property in (IDictionary<string, object>)robot)
        Console.WriteLine($"{property.Key}: {property.Value}");
}
