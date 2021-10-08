using System;
using System.Collections.Generic;
using System.Threading;
using System.Linq;

Console.Write("Enter the name of the True Programmer: ");
var playerNameArg = Console.ReadLine();

Character player1 = new TheTrueProgrammer(playerNameArg);
Character player2 = new Skeleton();


Party heroes = new Party();
heroes.Player = new ComputerPlayer();
heroes.Characters.Add(player1);

Party monsters = new Party();
monsters.Player = new ComputerPlayer();
monsters.Characters.Add(player2);

Game game = new Game(heroes, monsters);
game.Run();



public class Game
{
    public Party Heroes { get; }
    public Party Monsters { get; }

    public Game(Party heroParty, Party monsterParty)
    {
        Heroes = heroParty;
        Monsters = monsterParty;
    }

    public void Run()
    {
        while (true)
        {
            foreach (Party party in new[] { Heroes, Monsters })
            {
                foreach (Character character in party.Characters)
                {
                    Console.WriteLine();
                    Console.WriteLine($"It is {character.Name}'s turn...");
                    party.Player.ChooseAction(this, character).Run(this, character);
                }
            }
        }
    }

    public Party GetPartyForCharacter(Character character) => Heroes.Characters.Contains(character) ? Heroes : Monsters;
    public Party GetPartyForEnemyCharacter(Character character) => Heroes.Characters.Contains(character) ? Monsters : Heroes;
}

public class AttackAction : IAction
{
    private readonly IAttack attack;
    private readonly Character target;

    public AttackAction(IAttack attack, Character target)
    {
        this.attack = attack;
        this.target = target;
    }

    public void Run(Game game, Character character)
    {
        Console.WriteLine($"{character.Name} used {this.attack.Name} on {this.target.Name}");
    }
}

public class Party
{
    public List<Character> Characters { get; } = new List<Character>();
    public IPlayer Player { get; set; }
}

public interface IAttack
{
    string Name { get; }
}
public abstract class Character
{
    public abstract string Name { get; }
    public abstract IAttack StandardAttack { get; }
    public int HP { get; set; } = 0;

}

public class Skeleton : Character
{
    public override string Name => "Skeleton";
    public override IAttack StandardAttack { get; } = new BoneCrunch();
}

public class TheTrueProgrammer : Character
{
    public override string Name { get; }
    public TheTrueProgrammer(string name) => Name = name;
    public override IAttack StandardAttack { get; } = new Punch();
}

public interface IAction
{
    void Run(Game game, Character character);
}

public class DoNothing : IAction
{
    public void Run(Game game, Character character)
    {
        Console.WriteLine($"The {character.Name} did NOTHING!!");
    }
}

public class Punch : IAttack
{
    public string Name => "PUNCH";

}

public class BoneCrunch : IAttack
{
    public string Name => "Bone Crush";
}


public interface IPlayer
{
    IAction ChooseAction(Game game, Character character);
}

public class ComputerPlayer : IPlayer
{
    public IAction ChooseAction(Game game, Character character)
    {
        Thread.Sleep(500);
        return new AttackAction(character.StandardAttack, game.GetPartyForEnemyCharacter(character).Characters[0]);
    }
}
