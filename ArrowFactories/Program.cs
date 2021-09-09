using System;

Arrow myArrow = GetArrow();

Console.WriteLine($"This arrow will cost {myArrow.GetCost()}");
Console.WriteLine($"The arrow has arrow head of {myArrow.ArrowHead}");
Console.WriteLine($"The arrow has fletching of {myArrow.Fletching}");
Console.WriteLine($"The arrow has a length of {myArrow.Length}");

Arrow GetArrow()
{
    var arrowTypeInt = 0;

    while (arrowTypeInt != 1 && arrowTypeInt != 2)
    {
        Console.Write("Press 1 for a customer arrow, Press 2 for a premade arrow: ");
        var arrowType = Console.ReadLine();
        arrowTypeInt = Convert.ToInt32(arrowType);
    }

    if (arrowTypeInt == 1)
    {
        return CreateCustomArrow();
    }

    return CreatePreBuiltArrow();
}

Arrow CreatePreBuiltArrow()
{
    Console.Write("What type of prebuilt arrow do you want, Elite, Beginner, or Marksman: ");
    var desiredArrow = Console.ReadLine();

    return desiredArrow switch
    { 
        "Elite" => Arrow.CreateEliteArrow(),
        "Beginner" => Arrow.CreateBeginnerArrow(),
        "Marksman" => Arrow.CreateMarksmanArrow()
    };
}

Arrow CreateCustomArrow()
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
    public ArrowHeadType ArrowHead { get; set; }
    public FletchingType Fletching { get; set; }
    public float Length { get; set; }

    public Arrow(ArrowHeadType ArrowHead, FletchingType Fletching, float Length)
    {
        this.ArrowHead = ArrowHead;
        this.Fletching = Fletching;
        this.Length = Length;
    }

    public static Arrow CreateEliteArrow() => new Arrow(ArrowHeadType.Steel, FletchingType.Plastic, 95);
    public static Arrow CreateBeginnerArrow() => new Arrow(ArrowHeadType.Wood, FletchingType.GooseFeather, 75);
    public static Arrow CreateMarksmanArrow() => new Arrow(ArrowHeadType.Steel, FletchingType.GooseFeather, 65);

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

