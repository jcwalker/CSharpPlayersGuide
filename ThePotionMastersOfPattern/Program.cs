using System;

bool makingPotion = true;
Potion myPotion = new Potion();


String[] ingredientList = Enum.GetNames(typeof(Ingredient));

while (makingPotion)
{
    Console.WriteLine($"Current potion: {myPotion.Type}");
    Console.WriteLine($"Pick an ingredient to add to your potion from the following list.");

    for (int i = 0; i < ingredientList.Length; i++)
    {
        Console.WriteLine($"{i + 1} {ingredientList[i]}");
    }

    var choice = Convert.ToInt32(Console.ReadLine());

    Ingredient response = choice switch
    {
        1 => Ingredient.Stardust,
        2 => Ingredient.SnakeVenom,
        3 => Ingredient.DragonBreath,
        4 => Ingredient.ShadowGlass,
        5 => Ingredient.EyeshineGem
    };

    Potions potionToBeCreated = myPotion.DeterminePotion(response);
    myPotion.Type = potionToBeCreated;

    Console.WriteLine($"You created a {myPotion.Type} potion.");
    Console.Write("Do you want to complete the potion? Y/N: ");
    string intent = Console.ReadLine().ToLower();

    if (intent == "y")
    {
        makingPotion = false;
    }

    if (myPotion.Type == Potions.Ruined)
    {
        myPotion.Type = Potions.Water;
    }
}

class Potion
{
    public Potions Type { get; set; } = Potions.Water;

    public Potions DeterminePotion (Ingredient ingredient)
    {
        return (this.Type, ingredient) switch
        {
             (Potions.Water, Ingredient.Stardust)           => Potions.Elixir,
             (Potions.Elixir, Ingredient.SnakeVenom)        => Potions.Poison,
             (Potions.Elixir, Ingredient.DragonBreath)      => Potions.Flying,
             (Potions.Elixir, Ingredient.ShadowGlass)       => Potions.Invisibility,
             (Potions.Elixir, Ingredient.EyeshineGem)       => Potions.NightSight,
             (Potions.NightSight, Ingredient.ShadowGlass)   => Potions.CloudyBrew,
             (Potions.Invisibility, Ingredient.EyeshineGem) => Potions.CloudyBrew,
             (Potions.CloudyBrew, Ingredient.Stardust)      => Potions.Wraith,
             _                                              => Potions.Ruined
        };
    }
}

enum Potions {Water, Elixir, Poison, Flying, Invisibility, NightSight, CloudyBrew, Wraith, Ruined};
enum Ingredient {Stardust, SnakeVenom, DragonBreath, ShadowGlass, EyeshineGem};
