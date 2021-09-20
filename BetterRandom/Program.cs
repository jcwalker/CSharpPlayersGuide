using System;

Random improvedRandom = new Random();

string randomWord = improvedRandom.NextString("one", "two", "three");
double randomDouble = improvedRandom.NextDouble(0, 9);
bool flip = improvedRandom.CoinFlip();

Console.WriteLine($"Random word {randomWord}");  
Console.WriteLine($"Random double {randomDouble}");
Console.WriteLine($"Coin flip, true equals head flase equals tails {flip}");

public static class RandomExtensions
{
    public static double NextDouble(this Random rando, double min, double max)
    {
        return (rando.NextDouble() * (max - min)) + min;
    }

    public static string NextString(this Random rando, params string[] words)
    {
        int randomIndex = rando.Next(words.Length);

        return words[randomIndex];
    }

    public static bool CoinFlip(this Random rando, double headsChance = 0.5)
    {
        return rando.NextDouble() < headsChance;
    }
}

