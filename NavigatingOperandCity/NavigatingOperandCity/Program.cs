using System;

BlockCoordinate myBlockCoordinate = new BlockCoordinate(0, 0);
BlockOffset myBlockOffset = new BlockOffset(2, 0);

BlockCoordinate result = myBlockCoordinate + myBlockOffset;
BlockCoordinate resultFromEnum = myBlockCoordinate + Direction.South;
BlockCoordinate resultFromEnum2 = myBlockCoordinate + Direction.East;

Console.WriteLine($"Result from blockCoordinate + blockOffset {result.Row},{result.Column}");
Console.WriteLine($"Result from blockCoordinate + Direction.South {resultFromEnum.Row},{resultFromEnum.Column}");
Console.WriteLine($"Result from blockCoordinate + Direction.East {resultFromEnum2.Row},{resultFromEnum2.Column}");


BlockOffset converstionResult = (BlockOffset)Direction.East;

Console.WriteLine($"Conversion result Direction East {converstionResult.RowOffset},{converstionResult.ColumnOffset}");

public enum Direction { North, East, South, West}
public record BlockOffset(int RowOffset, int ColumnOffset)
{
    public static implicit operator BlockOffset(Direction direction) => direction switch
    {
        Direction.North => new BlockOffset(-1, 0),
        Direction.South => new BlockOffset(1, 0),
        Direction.West => new BlockOffset(0, -1),
        Direction.East => new BlockOffset(0, 1)
    };
}

public record BlockCoordinate(int Row, int Column)
{
    public static BlockCoordinate operator +(BlockCoordinate blockCoordinate, BlockOffset blockOffset) =>
        new BlockCoordinate(blockCoordinate.Row + blockOffset.RowOffset, blockCoordinate.Column + blockOffset.ColumnOffset);

    public static BlockCoordinate operator +(BlockCoordinate blockCoordinate, Direction direction) => direction switch
    {
        Direction.North => new BlockCoordinate(blockCoordinate.Row -1, blockCoordinate.Column),
        Direction.South => new BlockCoordinate(blockCoordinate.Row +1, blockCoordinate.Column),
        Direction.West  => new BlockCoordinate(blockCoordinate.Row, blockCoordinate.Column -1),
        Direction.East  => new BlockCoordinate(blockCoordinate.Row, blockCoordinate.Column +1)
    };

    public int this[int number]
    {
        get
        {
            if (number == 0) return Row;
            else return Column;
        }
    }
}
