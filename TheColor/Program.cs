using System;


Color randomColor = new Color(5, 230, 10);
Color greenColor = Color.Green;

Console.WriteLine($"R={randomColor.R} G={randomColor.G} B={randomColor.B}");
Console.WriteLine($"R={greenColor.R} G={greenColor.G} B={greenColor.B}");
public class Color
{
    public byte R { get; }
    public byte G { get; }
    public byte B { get; }

    public Color(byte r, byte g, byte b)
    {
        this.R = r;
        this.G = g;
        this.B = b;
    }

    public static Color White { get; } = new Color(255, 255, 255);
    public static Color Black { get; } = new Color(0, 0, 0);
    public static Color Red { get; } = new Color(255, 0, 0);
    public static Color Orange { get; } = new Color(255, 165, 0);
    public static Color Green { get; } = new Color(0, 128, 0);
    public static Color Blue { get; } = new Color(0, 0, 255);
    public static Color Purple { get; } = new Color(128, 0, 128);
}

