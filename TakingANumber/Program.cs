using System;

namespace TakingANumber
{
    class Program
    {
        static void Main(string[] args)
        {
            int AskForNumber(string input)
            {
                int result = Convert.ToInt32(input);
                return result;
            }

            AskForNumber("12");

            int AskForNumberInRange(string text, int min, int max)
            {
                int textInt = Convert.ToInt32(text);

                if (textInt > min && textInt < max)
                {
                    return textInt;
                }

                return textInt;
            }
        }
    }
}
