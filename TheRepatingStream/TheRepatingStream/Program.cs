using System;
using System.Threading;

RecentNumbers recentNumbers = new RecentNumbers();

Thread thread = new Thread(recentNumbers.GetRandomNumber);

thread.Start();

while (true)
{
    Console.ReadKey();
    
    if (recentNumbers.MostRecentNumber == recentNumbers.SecondMostRecentNumber)
    {
        Console.WriteLine($"Last two numbers are the same! {recentNumbers.MostRecentNumber} {recentNumbers.SecondMostRecentNumber}");
    }
    else
    {
        Console.WriteLine($"Last two numbers are the different {recentNumbers.MostRecentNumber} {recentNumbers.SecondMostRecentNumber}");
    }
}

class RecentNumbers
{
    public int MostRecentNumber { get; set; }
    public int SecondMostRecentNumber { get; set; }
    private object numberLock = new Object();

    public void GetRandomNumber()
    {
        while (true)
        {
            lock (numberLock)
            {
                Random random = new Random();
                this.MostRecentNumber = random.Next(0, 9);
                Console.WriteLine($"{this.MostRecentNumber}");
                Thread.Sleep(1000);
                this.SecondMostRecentNumber = random.Next(0, 9);
                Console.WriteLine($"{this.SecondMostRecentNumber}");
                Thread.Sleep(1000);
            }
        }
    }
}
