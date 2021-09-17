using System;

namespace HuntingTheManticore
{
    class Program
    {
        static void Main(string[] args)
        {
            int manticoreHealth = 10;
            int cityHealth = 15;
            int roundCounter = 1;
            Random random = new Random();

            int distance = random.Next(0, 100);

            // clear screen
            Console.Clear();
            Console.WriteLine("Player 2 it's your turn.");

            while (manticoreHealth > 0 && cityHealth > 0)
            {
                // determine damage
                var damage = GetCannonBlast(roundCounter);

                // send results to console output
                Console.WriteLine($"STATUS: ROUND: {roundCounter}  City: {cityHealth}/15  Manticore: {manticoreHealth}/10");
                Console.WriteLine($"The cannon is expected to deal {damage} damage this round.");
                // get distance guess
                Console.Write("Enter desired cannon range: ");
                var guess = Console.ReadLine();
                int distanceGuess = Convert.ToInt32(guess);
                var isDirectHit = AssertHit(distanceGuess, distance);
                Console.WriteLine("---------------------------------------------------");

                // subtract health
                cityHealth--;

                if (isDirectHit)
                {
                    manticoreHealth = manticoreHealth - damage;
                }
                // increment roundCounter
                roundCounter++;
            }

            if (manticoreHealth <= 0)
            {
                Console.WriteLine("The Manticore has been destroyed! The city of Consolas has been saved!");
            }
            else if (cityHealth <= 0)
            {
                Console.WriteLine("The Manticore has been has destroyed the city!");
            }

            #region Methods
            // method to determine hit
            bool AssertHit(int distanceGuess, int manticoreDistance)
            {
                if (distanceGuess < manticoreDistance)
                {
                    Console.WriteLine("That round FELL short of the target!");
                    return false;
                }
                else if (distanceGuess > manticoreDistance)
                {
                    Console.WriteLine("That round OVERSHOT the target.");
                    return false;
                }
                else
                {
                    Console.WriteLine("That round was a DIRECT HIT!");
                    return true;
                }
            }

            // method to calculate fire multiple of 3, electronic multiple of 5, fire-electric blast multiple of 3 and 5
            int GetCannonBlast(int round)
            {
                int damage = 0;

                if (round % 3 == 0 && round % 5 == 0)
                {
                    damage = 10;
                }
                else if (round % 3 == 0 || round % 5 == 0)
                {
                    damage = 3;
                }
                else
                {
                    damage = 1;
                }

                return damage;
            }

            int AskForNumberInRange(string text, int min, int max)
            {
                while (true)
                {
                    int number = AskForNumber(text);
                    if (number >= min && number < max)
                        return number;
                }
            }

            // Gets a number from the user, asking the prompt supplied by 'text'.
            int AskForNumber(string text)
            {
                Console.Write(text + " ");
                Console.ForegroundColor = ConsoleColor.Cyan;
                int number = Convert.ToInt32(Console.ReadLine());
                return number;
            }
            #endregion
        }
    }
}
