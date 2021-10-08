using System;
using System.Collections.Generic;
using System.Threading;

Character player1 = new Character("Player1", Game.CharacterType.Skeleton);
player1.Actions.Add(new DoNothing());

Character player2 = new Character("Player2", Game.CharacterType.Skeleton);
player2.Actions.Add(new DoNothing());

Character[] hereoCharacterList = new Character[] { player1 };
Character[] monsterCharacterList = new Character[] { player2 };

Party heroes   = new Party(hereoCharacterList, Game.PartyType.Hereos);
Party monsters = new Party(monsterCharacterList, Game.PartyType.Monsters);

Game game = new Game(heroes, monsters);
game.Run();



public class Game
{
    public Party Heroes { get; }
    public Party Monsters { get; }

    public Game (Party heroParty, Party monsterParty)
    {
        Heroes = heroParty;
        Monsters = monsterParty;
    }

    public void Run()
    {
        while (true)
        {
            Console.WriteLine($"It is {Heroes.Characters[0].Name}'s turn...");
            Heroes.Characters[0].Run();
            Console.WriteLine();

            Console.WriteLine($"It is {Monsters.Characters[0].Name}'s turn...");
            Monsters.Characters[0].Run();
            Console.WriteLine();
        }
    }

    public enum PartyType { Hereos, Monsters }
    public enum CharacterType { Skeleton }
}

public class Party
{
    public Character[] Characters;
    public Game.PartyType Type;

    public Party(Character[] characters, Game.PartyType type)
    {
        this.Characters = characters;
        this.Type = type;
    }
}

public class Character
{
    public string Name { get; }
    public Game.CharacterType Type { get; }
    public int HP { get; set; } = 0;
    public List<CharacterAction> Actions { get; } = new List<CharacterAction>();

    public Character(string name, Game.CharacterType type)
    {
        this.Name = name;
        this.Type = type;
    }

    public void Run()
    {
        foreach (CharacterAction action in Actions)
        {
            action.Run(this);
            Thread.Sleep(500);
        }
    }
}

public abstract class CharacterAction
{
    public abstract void Run(Character character);
}

public class DoNothing : CharacterAction
{
    public override void Run(Character character)
    {
        Console.WriteLine($"The {character.Type} did NOTHING!!");
    }
}
