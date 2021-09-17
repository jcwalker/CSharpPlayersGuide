using System;
using System.Collections.Generic;

Robot myRobot = new Robot();
List<RobotCommand> commands = new List<RobotCommand>();
bool doneWithCommands = false;

Console.WriteLine("Enter commands (as many as you want) for the robot, On, Off, North, South, East, Or West. ");
Console.WriteLine("When you are done type stop");


while (!doneWithCommands)
{
    Console.Write("Command: ");
    var command = Console.ReadLine().ToLower();

    if (command == "stop")
    {
        doneWithCommands = true;
    }
    else
    {
        RobotCommand commandToAdd = command switch
        {
            "on" => new OnCommand(),
            "off" => new OffCommand(),
            "north" => new NorthCommand(),
            "south" => new SouthCommand(),
            "east" => new EastCommand(),
            "west" => new WestCommond()
        };

        myRobot.Commands.Add(commandToAdd);
    }
 }


myRobot.Run();

public class Robot
{
    public int X { get; set; }
    public int Y { get; set; }
    public bool IsPowered { get; set; }
    public List<RobotCommand> Commands { get; } = new List<RobotCommand>();

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