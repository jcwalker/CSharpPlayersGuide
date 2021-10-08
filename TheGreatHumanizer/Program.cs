using System;
using Humanizer;

Console.WriteLine($"When is the feast? {DateTime.UtcNow.AddHours(90).Humanize()}");
