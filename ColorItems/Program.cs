using System;

ColoredItem<Sword> coloredSword = new ColoredItem<Sword>(new Sword(), ConsoleColor.Blue);
ColoredItem<Bow> coloredBow = new ColoredItem<Bow>(new Bow(), ConsoleColor.Red);
ColoredItem<Axe> coloredAxe = new ColoredItem<Axe>(new Axe(), ConsoleColor.Green);

coloredSword.Display();
coloredBow.Display();
coloredAxe.Display();


public class Sword { };
public class Bow { };
public class Axe { };

public class ColoredItem<T>
{
    public T Item { get; }
    ConsoleColor Color { get; }

    public ColoredItem(T item, ConsoleColor color)
    {
        Item = item;
        Color = color;
    }

    public void Display()
    {
        Console.ForegroundColor = Color;
        Console.WriteLine($"The {Item} is {Color}");
    }
}