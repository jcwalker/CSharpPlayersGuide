using System;
using System.Threading.Tasks;

Console.Write("Enter a 4 letter word: ");
var word = Console.ReadLine();
DateTime start = DateTime.Now;
int result = await RandomlyRecreateAsync(word);
DateTime end = DateTime.Now;

TimeSpan elapseTime = end - start;
Console.WriteLine($"It {result} times to match the word {word}.");
Console.WriteLine($"It took {elapseTime.Minutes} minutes {elapseTime.Seconds} seconds {elapseTime.Milliseconds} milliseconds to complete.");

int RandomlyRecreate(string word)
{
    // int wordLength = word.Length;
    Random random = new Random();
    string randomWord = String.Empty;
    int randomWordCounter = 0;
    char[] randomChars = new char[word.Length];

    while (word != randomWord)
    {
        for (int counter = 0; counter < word.Length; counter++)
        {
            randomChars[counter] = (char)('a' + random.Next(26));
        }

        randomWord = String.Join("", randomChars);
        randomWordCounter++;
    }

    return randomWordCounter;
}

Task<int> RandomlyRecreateAsync(string word)
{
    return Task.Run(() =>
    {
        return RandomlyRecreate(word);
    });
}
