using System;
using System.Collections.Generic;
using System.Linq;

Game myGame = new Game();

WorldHelper.SetWallSize(myGame);
WorldHelper.SetLandmarks(myGame);
Player playerOne = new Player(myGame.EntranceRow, myGame.EntranceColumn);
DateTime gameStartTime = DateTime.Now;

Console.WriteLine("You enter the Cavern of object, a maze of rooms filled with dangerous pits in the search of the Fountain of Objects.");
Console.WriteLine("Light is visible only in the entrace, and no other light is seen anywhere in the caverns.");
Console.WriteLine("You must navigate the Caverns with your other senses.");
Console.WriteLine("Look out for pits.  You will feel a breeze if a pit is in an adjacent room.");
Console.WriteLine("Find the Fountain of Object, activate it, and return to the entrace.");


while (true)
{
    myGame.DisplayStatusMessage(playerOne);
    myGame.GetPlayerAction(playerOne);
    myGame.Action(playerOne);
}


public class Game
{
    public bool FountainEnabled { get; set; } = false;
    public PlayerAction Command { get; set; }

    public WorldSize WorldSize { get; set; }

    public int WallSize { get; set; }

    public int FountainRow { get; set; }
    public int FountainColumn { get; set; }

    public int EntranceRow { get; set; }
    public int EntranceColumn { get; set; }

    public int[][] PitLocation { get; set; } = new int[3][];

    public readonly DateTime GameStartTime = DateTime.Now;

    private string FountainOffMessage = "You hear water dripping in this room.  The Fountain of Objects is here!";
    private string FountainOnMessage = "You hear the rushing waters from the Founntain of Objects.  It has been activated!";
    private string WinMessage = "The fountain of Objects has bee reactivated, and you have escaped with your life!";
    private string GetPlayerActionMessage = "What do you want to do? ";
    private string[] ValidCommandList = { "move east", "move west", "move north", "move south", "enable fountain", "disable fountain"};

    public void DisplayStatusMessage(Player player)
    {
        Console.WriteLine("-----------------------------------------------------------");
        Console.WriteLine($"You are in the room at (Row={player.Row}, Column={player.Column}).");

        if (player.Row == EntranceRow && player.Column == EntranceColumn && !FountainEnabled)// at the entrace
        {
            Console.WriteLine("You see the light coming from the cavern entrance.");
        }
        else if (player.Row == FountainRow && player.Column == FountainColumn && !FountainEnabled)
        {
            Console.WriteLine(FountainOffMessage);
        }
        else if (player.Row == FountainRow && player.Column == FountainColumn && FountainEnabled)
        {
            Console.WriteLine(FountainOnMessage);
        }
        else if (IsInPit(player))
        {
            Console.WriteLine("You feel into the pit and died!");
            WorldHelper.GetTimeInCavern(this);
            Environment.Exit(0);
        }
        else if (IsNearPit(player))
        {
            Console.WriteLine("You feel a draft.  There is a pit in a nearby room.");
        }
        else if (player.Row == EntranceRow && player.Column == EntranceColumn && FountainEnabled)// at the entrace
        {
            Console.WriteLine(WinMessage);
            Console.WriteLine("You win!");
            WorldHelper.GetTimeInCavern(this);
            Environment.Exit(0);
        }
    }

    public bool IsNearPit(Player player)
    {
        List<int[]> possibleNeighbors = new List<int[]>();

        IEnumerable<int> rows = new int[3];
        IEnumerable<int> columns = new int[3];

        foreach (int[] location in PitLocation)
        {
            if (!(location == null))
            {
                int rowRangeStart = location[0] - 1;
                int rowRangeEnd = location[0] + 1;

                int columnRangeStart = location[1] - 1;
                int columnRangeEnd = location[1] + 1;

                rows    = Enumerable.Range(rowRangeStart, 3).ToArray();
                columns = Enumerable.Range(columnRangeStart, 3).ToArray();

                foreach (int r in rows)
                {
                    foreach (int c in columns)
                    {
                        int[] neighbor = new[] { r, c };

                        possibleNeighbors.Add(neighbor);
                    }
                }
            }
        }

        //if player location is is possibleNeighbors
        if (rows.Contains(player.Row) && columns.Contains(player.Column))
        {
            return true;
        }

        return false;
    }

    public bool IsInPit(Player player)
    {
        IEnumerable<int> rows = new int[3];
        IEnumerable<int> columns = new int[3];

        foreach (int[] location in PitLocation)
        {
            if (!(location == null))
            {
                if (player.Row == location[0] && player.Column == location[1])
                {
                    return true;
                }
            }
        }

        return false;
    }

    public void GetPlayerAction(Player player)
    {
        bool validCommandReceived = false;

        while (!validCommandReceived)
        {
            Console.Write(GetPlayerActionMessage);
            var playerInput = Console.ReadLine().ToLower();
            // assert the command is valid
            if (ValidCommandList.Contains(playerInput))
            {
                PlayerAction actionToAdd = playerInput switch
                {
                    "move east"        => new EastCommand(),
                    "move west"        => new WestCommand(),
                    "move north"       => new NorthCommand(),
                    "move south"       => new SouthCommand(),
                    "enable fountain"  => new EnableFountain(),
                    "disable fountain" => new DisableFountain()
                };

                this.Command = actionToAdd;
                validCommandReceived = true;
            }
            else
            {
                Console.WriteLine($"Please enter a valid command: {String.Join(", ", ValidCommandList)}");
            }
        }
    }

    public void Action(Player player)
    {
        Command.Action(player, this);
    }
}

public class Player
{
    public int Row { get; set; }
    public int Column { get; set; }

    public Player(int row, int column)
    {
        Row = row;
        Column = column;
    }
}

public abstract class PlayerAction
{
    private protected const string IllegalMoveMessage = "You can't move off the matrix!";
    public abstract void Action(Player player, Game game);
}

public class NorthCommand : PlayerAction
{
    public override void Action(Player player, Game game)
    {
        if (player.Row != 0)
        {
            player.Row--;
        }
        else
        {
            Console.WriteLine(IllegalMoveMessage);
        }
    }
}

public class SouthCommand : PlayerAction
{
    public override void Action(Player player, Game game)
    {
        int wallLimit = (int)game.WorldSize - 1;

        if (player.Row != wallLimit)
        {
            player.Row++;
        }
        else
        {
            Console.WriteLine(IllegalMoveMessage);
        }
    }
}

public class EastCommand : PlayerAction
{
    public override void Action(Player player, Game game)
    {
        int wallLimit = (int)game.WorldSize - 1;

        if (player.Column != wallLimit)
        {
            player.Column++;
        }
        else
        {
            Console.WriteLine(IllegalMoveMessage);
        }
    }
}

public class WestCommand : PlayerAction
{
    public override void Action(Player player, Game game)
    {
        if (player.Column != 0)
        {
            player.Column--;
        }
        else
        {
            Console.WriteLine(IllegalMoveMessage);
        }
    }
}

public class EnableFountain : PlayerAction
{
    public override void Action(Player player, Game game)
    {
        if (game.FountainEnabled)
        {
            Console.WriteLine("Fountain is already enabled");
        }
        else
        {
            game.FountainEnabled = true;
        }
    }
}

public class DisableFountain : PlayerAction
{
    public override void Action(Player player, Game game)
    {
        if (!game.FountainEnabled)
        {
            Console.WriteLine("Fountain is already disabled");
        }
        else
        {
            game.FountainEnabled = false;
        }
    }
}


public class WorldHelper
{
    public static void SetWallSize(Game game)
    {
        string[] validWorldList = { "small", "medium", "large" };
        bool assertValidSize = false;

        while (!assertValidSize)
        {
            Console.Write("Do you want to play in a small, medium, or large world? ");

            var worldSizeAsk = Console.ReadLine().ToLower();

            if (validWorldList.Contains(worldSizeAsk))
            {
                WorldSize worldSize = worldSizeAsk switch
                {
                    "small"  => WorldSize.small,
                    "medium" => WorldSize.medium,
                    "large"  => WorldSize.large
                };

                game.WorldSize = worldSize;
                assertValidSize = true;
            }
        }
    }

    public static void SetLandmarks(Game game)
    {
        if (game.WorldSize == WorldSize.small)
        {
            game.FountainRow = 0;
            game.FountainColumn = 2;

            game.EntranceRow = 0;
            game.EntranceColumn = 0;

            game.PitLocation[0] = new int[] { 2, 3 };
        }
        else if (game.WorldSize == WorldSize.medium)
        {
            game.FountainRow = 3;
            game.FountainColumn = 3;

            game.EntranceRow = 4;
            game.EntranceColumn = 4;

            game.PitLocation[0] = new int[] { 1, 3 };
            game.PitLocation[1] = new int[] { 5, 5 };
        }
        else if (game.WorldSize == WorldSize.large)
        {
            game.FountainRow = 7;
            game.FountainColumn = 2;

            game.EntranceRow = 0;
            game.EntranceColumn = 8;

            game.PitLocation[0] = new int[] { 2, 3 };
            game.PitLocation[1] = new int[] { 5, 5 };
            game.PitLocation[2] = new int[] { 6, 5 };

        }
    }

    public static void GetTimeInCavern(Game game)
    {
        TimeSpan gameInterval = DateTime.Now -game.GameStartTime;
        Console.WriteLine($"Time spent in the cavern {gameInterval.Hours} hours {gameInterval.Minutes} minutes and {gameInterval.Seconds} seconds");
    }
}

public enum WorldSize
{
    small  = 4,
    medium = 6,
    large  = 8
}

