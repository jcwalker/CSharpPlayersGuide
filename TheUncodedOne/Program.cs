using System;
using System.Collections.Generic;
using System.Threading;
using System.Linq;

Console.Write("Enter the name of the True Programmer: ");
var playerNameArg = Console.ReadLine();

Character player1 = new TheTrueProgrammer(playerNameArg);
Character skeleton1 = new Skeleton();
Character skeleton2 = new Skeleton();
Character skeleton3 = new Skeleton();
Character uncodedOne = new TheUncodedOne();

Party heroes = new Party();
heroes.Player = new ComputerPlayer();
heroes.Characters.Add(player1);


Party monster1 = new Party();
monster1.Player = new ComputerPlayer();
monster1.Characters.Add(skeleton1);

Party monster2 = new Party();
monster2.Player = new ComputerPlayer();
monster2.Characters.Add(skeleton2);
monster2.Characters.Add(skeleton3);

Party monster3 = new Party();
monster3.Player = new ComputerPlayer();
monster3.Characters.Add(uncodedOne);

Party[] monsterParties = new Party[] { monster1, monster2, monster3 };

for (int round = 0; round < monsterParties.Length; round++)
{
    Game game = new Game(heroes, monsterParties[round]);
    game.Run();

    if (heroes.Characters.Count == 0) break;
}

if (heroes.Characters.Count > 0) Console.WriteLine("You have defeated the Uncoded One's forces!  You are the best there ever was!");
else Console.WriteLine("You have been defeated.  The Uncoded One won.");


public class Game
{
    public Party Heroes { get; }
    public Party Monsters { get; }

    public Game(Party heroParty, Party monsterParty)
    {
        Heroes = heroParty;
        Monsters = monsterParty;
    }

    public void AssertCharacterHealth(Character character)
    {
        if (character.HP == 0)
        {
            Console.WriteLine($"{character.Name} has been defeated!");
            Party party = GetPartyForCharacter(character);
            party.Characters.Remove(character);
            AssertLivePlayers(party);
        }
    }

    public bool AssertLivePlayers(Party party)
    {
        if (party.Characters.Count == 0)
        {
            if (this.Monsters == party)
            {
                Console.WriteLine("The HEROES WON!  The Uncoded One has been defeated!!");

            }
            else
            {
                Console.WriteLine("The Heroes lost and th3e Uncoded One's forces have revailed!");
            }

            return true;
        }

        return false;
    }

    public void Run()
    {
        while (!IsOver)
        {
            foreach (Party party in new[] { Heroes, Monsters })
            {
                foreach (Character character in party.Characters)
                {
                    Console.WriteLine();
                    Console.WriteLine($"It is {character.Name}'s turn...");
                    party.Player.ChooseAction(this, character).Run(this, character);

                    if (IsOver) break;
                }

                if (IsOver) break;
            }
        }
    }

    public Party GetPartyForCharacter(Character character) => Heroes.Characters.Contains(character) ? Heroes : Monsters;
    public Party GetPartyForEnemyCharacter(Character character) => Heroes.Characters.Contains(character) ? Monsters : Heroes;
    public bool IsOver => Heroes.Characters.Count == 0 || Monsters.Characters.Count == 0;
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
        Console.WriteLine($"{this.attack.Name} dealt {this.attack.HP} damage to {this.target.Name}.");
        Console.WriteLine($"{this.target.Name} is now at {this.target.HP}/{this.target.StartingHP} HP.");

        if (this.target.HP == 0)
        {
            game.GetPartyForCharacter(this.target).Characters.Remove(this.target);
            Console.WriteLine($"{this.target.Name} was defeated!");
        }
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
    public override int StartingHP => 25;

    public TheTrueProgrammer(string name)
    {
        Name = name;
        HP = 25;
    }
}

public class TheUncodedOne : Character
{
    public override string Name => "The Uncoded One";
    public override IAttack StandardAttack { get; } = new Unraveling();
    public override int StartingHP => 15;

    public TheUncodedOne()
    {
        HP = 15;
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

public class Unraveling : IAttack
{
    public string Name => "Unraveling Attack";
    public int HP => new Random().Next(0, 3);
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
        List<Character> potentialTargets = game.GetPartyForEnemyCharacter(character).Characters;
        if (potentialTargets.Count > 0) return new AttackAction(character.StandardAttack, game.GetPartyForEnemyCharacter(character).Characters[0]);
        return new DoNothing();
    }
}


