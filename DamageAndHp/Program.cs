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
        this.target.TakeDamage(this.attack.HP);
        Console.WriteLine($"{character.Name} used {this.attack.Name} on {this.target.Name}");
        Console.WriteLine($"{this.attack.Name} dealt {this.attack.HP} dome to {this.target.Name}.");
        Console.WriteLine($"{this.target.Name} is now at {this.target.HP}/{this.target.StartingHP} HP.");
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
    int HP { get; }
}
public abstract class Character
{
    public abstract string Name { get; }
    public abstract IAttack StandardAttack { get; }
    public abstract int StartingHP { get; }
    public int HP { get; set; }
    public void TakeDamage(int damage)
    {
        if (HP > 0)
        {
            HP -= damage;
        }
    }
}

public class Skeleton : Character
{
    public override string Name => "Skeleton";
    public override IAttack StandardAttack { get; } = new BoneCrunch();
    public override int StartingHP => 5;
    public Skeleton()
    {
        HP = 5;
    }
}

public class TheTrueProgrammer : Character
{
    public override string Name { get; }
    //public TheTrueProgrammer(string name) => Name = name;
    public override IAttack StandardAttack { get; } = new Punch();
    public override int StartingHP  => 25;

    public TheTrueProgrammer(string name)
    {
        Name = name;
        HP = 25;
    }

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
    public int HP => 1;

}

public class BoneCrunch : IAttack
{
    
    public string Name => "Bone Crush";
    public int HP => new Random().Next(0, 2);
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

