using System;

bool canParse = false;

while (!canParse)
{
    Console.Write("Enter a int value: ");
    string intInput = Console.ReadLine();
    canParse = int.TryParse(intInput, out int value);

    if (canParse)
    {
        Console.WriteLine($"{intInput} converted to an int!! Result: {value}");
    }
}

bool canParseDouble = false;

while(!canParseDouble)
{
    Console.Write("Enter a double: ");
    string doubleInput = Console.ReadLine();
    canParseDouble = double.TryParse(doubleInput, out double value);

    if (canParseDouble)
    {
        Console.WriteLine($"{doubleInput} converted to a double!! Result: {value}");
    }
}

bool canParseBool = false;

while (!canParseBool)
{
    Console.Write("Enter a bool value: ");
    string boolInput = Console.ReadLine();
    canParseBool = bool.TryParse(boolInput, out bool value);

    if (canParseBool)
    {
        Console.WriteLine($"{boolInput} converted to a bool!! Result: {value}");
    }
}
