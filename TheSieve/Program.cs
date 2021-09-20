using System;

Console.Write("Enter a number filter (Even, Positive, or MultipleOfTen): ");
var input = Console.ReadLine().ToLower();

Sieve sieve = new Sieve();

while (true)
{
    Console.Write("Enter a number: ");
    var inputNumber = Console.ReadLine();
    int intNumber = Convert.ToInt32(inputNumber);

    bool result = input switch
    {
        "even" => sieve.IsGood(intNumber, sieve.IsEven),
        "positive" => sieve.IsGood(intNumber, sieve.IsPositive),
        "multipleoften" => sieve.IsGood(intNumber, sieve.IsMultipleOfTen)
    };

    Console.WriteLine($"{intNumber} is {result}");
}

public class Sieve
{
    public bool IsGood(int number, GoodNumberDelegate _delegate)
    {
        return _delegate(number);
    }

    // even numbers
    public bool IsEven(int number) => number % 2 == 0;

    // positive numbers
    public bool IsPositive(int number) => number >= 0;

    //multiples of 10
    public bool IsMultipleOfTen(int number) => number % 10 == 0;

    public delegate bool GoodNumberDelegate(int number);
}


