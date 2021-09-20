using System;
using System.Collections.Generic;

Random random = new Random();
int oatmealCookie = random.Next(0, 9);
List<int> previouslyGuessed = new List<int>();

while (true) 
{
    Cookie.GetPlayerInput(ref previouslyGuessed, oatmealCookie, "one");
    Cookie.GetPlayerInput(ref previouslyGuessed, oatmealCookie, "two");

}

public class Cookie
{
    public static void GetPlayerInput(ref List<int> guessTracker,int cookeLocation, string player)
    {
        try
        {
            bool canProceed = false;
            while (!canProceed)
            {
                Console.Write($"Player {player} enter your guess: ");

                var guess = Console.ReadLine();
                int guessInt = Convert.ToInt32(guess);

                if (guessTracker.Contains(guessInt))
                {
                    Console.WriteLine($"{guessInt} has already been guessed.");
                }
                else if (guessInt == cookeLocation)
                {
                    throw new NotImplementedException("Haven't fixed this yet");
                }
                else
                {
                    canProceed = true;
                    guessTracker.Add(guessInt);
                }
            }
        }
        catch
        {
            Console.WriteLine($"Player {player} picked the oatmeal cookie!");
            Environment.Exit(0);
        }
    }
}
