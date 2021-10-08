using System;
using System.Collections.Generic;
using System.Threading;

List<Character> heroCharacterList = new();
List<Character> monsterCharacterList = new();

Console.Write("Enter the name of the True Programmer: ");
var playerNameArg = Console.ReadLine();

Character player1 = new Character(playerNameArg, Game.CharacterType.TOG);
player1.Actions.Add(new DoNothing());

Character player2 = new Character("Player2", Game.CharacterType.Skeleton);
player2.Actions.Add(new DoNothing());

heroCharacterList.Add(player1);
monsterCharacterList.Add(player2);

Party heroes = new Party(heroCharacterList, Game.PartyType.Hereos);
Party monsters = new Party(monsterCharacterList, Game.PartyType.Monsters);

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
                    character.Run();
                }
            }
        }
    }

    public enum PartyType { Hereos, Monsters }
    public enum CharacterType { Skeleton, TOG }

}

public class Party
{
    public List<Character> Characters { get; } = new List<Character>();
    public Game.PartyType Type;

    public Party(List<Character> characters, Game.PartyType type)
    {
        Characters = characters;
        Type = type;
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
        Name = name;
        Type = type;
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

