using System;

using System;

Arrow myArrow = GetArrow();

Console.WriteLine($"This arrow will cost {myArrow.GetCost()}");

Arrow GetArrow()
{
    ArrowHeadType arrowHead = GetArrowHead();
    FletchingType fletching = GetFletching();
    float length = GetLength();

    return new Arrow(arrowHead, fletching, length);
}

ArrowHeadType GetArrowHead()
{
    Console.Write("What type of arrowHead will be used (Steel, wood, or obsidian): ");
    string input = Console.ReadLine();
    return input switch
    {
        "steel" => ArrowHeadType.Steel,
        "wood" => ArrowHeadType.Wood,
        "obsidian" => ArrowHeadType.Obsidian
    };
}

FletchingType GetFletching()
{
    Console.Write("What type of fletching will be used (Plastic, TurkeyFeather, or GooseFeather): ");
    string input = Console.ReadLine();
    return input switch
    {
        "plastic" => FletchingType.Plastic,
        "turkeyFeather" => FletchingType.TurkeyFeather,
        "gooseFeather" => FletchingType.GooseFeather
    };
}

float GetLength()
{
    float length = 0;
    while (length < 60 || length > 100)
    {
        Console.Write("Arrow length (between 60 and 100): ");
        string input = Console.ReadLine();
        length = Convert.ToSingle(input);
    }

    return length;
}

class Arrow
{
    private ArrowHeadType ArrowHead;
    private FletchingType Fletching;
    private float Length;

    public Arrow(ArrowHeadType ArrowHead, FletchingType Fletching, float Length)
    {
        this.ArrowHead = ArrowHead;
        this.Fletching = Fletching;
        this.Length = Length;
    }

    public ArrowHeadType GetArrowHeadTypeValue() => this.ArrowHead;
    public FletchingType GetFletchingTypeValue() => this.Fletching;
    public float GetLengthValue() => this.Length;

    public float GetCost()
    {
        float runningTotal = 0;
        // calculate arrowhead cost
        if (this.ArrowHead == ArrowHeadType.Steel) runningTotal += 10;
        if (this.ArrowHead == ArrowHeadType.Wood) runningTotal += 3;
        if (this.ArrowHead == ArrowHeadType.Obsidian) runningTotal += 5;
        // calculate fletching cost
        if (this.Fletching == FletchingType.Plastic) runningTotal += 10;
        if (this.Fletching == FletchingType.TurkeyFeather) runningTotal += 5;
        if (this.Fletching == FletchingType.GooseFeather) runningTotal += 3;
        // calculate cost for length
        runningTotal += (float)(this.Length * .05);
        return runningTotal;
    }
}

public enum ArrowHeadType { Steel, Wood, Obsidian };
public enum FletchingType { Plastic, TurkeyFeather, GooseFeather };
