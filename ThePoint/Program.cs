using System;

Point asteroidPointDefault = new Point();
Point asteroidPointCustom = new Point(-4,0);

Console.WriteLine($"Default asteroid point position X {asteroidPointDefault.PositionX} positionY: {asteroidPointDefault.PositionY}");
Console.WriteLine($"Custom asteroid point position X {asteroidPointCustom.PositionX} positionY: {asteroidPointCustom.PositionY}");

public class Point
{
    public float PositionX { get; private set; }
    public float PositionY { get; private set; }

    public Point()
    {
        this.PositionX = 0;
        this.PositionY = 0;
    }

    public Point(float PositionX, float PositionY)
    {
        this.PositionX = PositionX;
        this.PositionY = PositionY;
    }
}
