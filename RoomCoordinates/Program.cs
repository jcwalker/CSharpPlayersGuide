using System;

// group 1 should be true
Coordinate coordinateOne = new Coordinate(1, 3);
Coordinate coordinateTwo = new Coordinate(2, 3);

//group 2 should be true
Coordinate coordinateThree = new Coordinate(2, 1);
Coordinate coordinateFour = new Coordinate(3, 2);

// group 3 should be false
Coordinate coordinateFive = new Coordinate(3, 5);
Coordinate coordinateSix = new Coordinate(3, 3);


bool group1Result = coordinateOne.IsAdjacent(coordinateTwo);
Console.WriteLine($"Is group 1's coordinates adjacent?: {group1Result}");

bool group2Result = coordinateThree.IsAdjacent(coordinateFour);
Console.WriteLine($"Is group 2's coordinates adjacent?: {group2Result}");

bool group3Result = coordinateFive.IsAdjacent(coordinateSix);
Console.WriteLine($"Is group 3's coordinates adjacent?: {group3Result}");

public struct Coordinate
{
    public int Row { get; }
    public int Column { get; }

    public Coordinate (int row, int column)
    {
        this.Row = row;
        this.Column = column;
    }

    public bool IsAdjacent(Coordinate location)
    {
        int columnDistance = Math.Abs(location.Column - this.Column);
        int rowDistance    = Math.Abs(location.Row - this.Row);

        if (columnDistance <= 1 && rowDistance <= 1)
        {
            return true;
        }

        return false;
    }
}
