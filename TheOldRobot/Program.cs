using System;
using System.Collections.Generic;

Robot myRobot = new Robot();

Console.WriteLine("Enter 3 commands for the robot, On, Off, North, South, East, Or West: ");

RobotCommand[] commands = new RobotCommand[3];

for (int i = 0; i <= 2; i++)
{
    Console.Write($"Command {i +1} ");
    var command = Console.ReadLine().ToLower();

    RobotCommand commandToAdd = command switch
    {
        "on"    => new OnCommand(),
        "off"   => new OffCommand(),
        "north" => new NorthCommand(),
        "south" => new SouthCommand(),
        "east"  => new EastCommand(),
        "west"  => new WestCommond()
    };

    myRobot.Commands[i] = commandToAdd;
 }


myRobot.Run();

public class Robot
{
    public int X { get; set; }
    public int Y { get; set; }
    public bool IsPowered { get; set; }
    public RobotCommand[] Commands { get; } = new RobotCommand[3];

    public void Run()
    {
        foreach (RobotCommand command in Commands)
        {
            command.Run(this);
            Console.WriteLine($"[{X} {Y} {IsPowered}]");
        }
    }
}

public abstract class RobotCommand
{
    public abstract void Run(Robot robot);
}

public class OnCommand : RobotCommand
{
    public override void Run(Robot robot)
    {
        robot.IsPowered = true;
    }
}

public class OffCommand : RobotCommand
{
    public override void Run(Robot robot)
    {
        robot.IsPowered = false;
    }
}

public class NorthCommand : RobotCommand
{
    public override void Run(Robot robot)
    {
        if (robot.IsPowered)
        {
            robot.Y++;
        }
    }
}

public class SouthCommand : RobotCommand
{
    public override void Run(Robot robot)
    {
        if (robot.IsPowered)
        {
            robot.Y--;
        }
    }
}

public class WestCommond : RobotCommand
{
    public override void Run(Robot robot)
    {
        if (robot.IsPowered)
        {
            robot.X--;
        }
    }
}

public class EastCommand : RobotCommand
{
    public override void Run(Robot robot)
    {
        if (robot.IsPowered)
        {
            robot.X++;
        }
    }
}