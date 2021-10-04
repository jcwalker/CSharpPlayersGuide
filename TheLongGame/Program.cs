using System;
using System.IO;

Console.Write("Enter your name: ");
var playerNameArgument = Console.ReadLine();


String filePath = $"{playerNameArgument}.txt";
int newScore = 0;

if (File.Exists(filePath))
{
    var currentScore = Convert.ToInt32(File.ReadAllText(filePath));
    newScore = currentScore +1;
    File.WriteAllText(filePath, newScore.ToString());
}
else
{
    newScore = 1;
    File.WriteAllText(filePath, newScore.ToString());
}

Console.WriteLine($"{playerNameArgument} current score is: {newScore}");
Console.WriteLine("Pres ESC to exit.");

while (true)
{
    var readKey = Console.ReadKey();
    
    if (readKey.Key == ConsoleKey.Escape)
    {
        Environment.Exit(0);
    }
}
