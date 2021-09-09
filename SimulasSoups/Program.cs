using System;

(FoodType type, Ingredient ingredient, Seasoning seasoning)[] meals = new( FoodType, Ingredient, Seasoning)[3];

for (int i= 0; i < 3; i++)
{
    meals[i] = GetMeal();
}

foreach (var meal in meals)
{
    Console.WriteLine($"{meal.seasoning} {meal.ingredient} {meal.type}");
}

(FoodType, Ingredient, Seasoning) GetMeal()
{
    FoodType   type       = GetFoodType();
    Ingredient ingreident = GetIngredient();
    Seasoning  seasoning  = GetSeasoning();
    return (type, ingreident, seasoning);
}

FoodType GetFoodType()
{
    Console.Write("Food type (soup, stew, or gumbo): ");
    string input = Console.ReadLine();
    return input switch
    {
        "soup"  => FoodType.Soup,
        "stew"  => FoodType.Stew,
        "gumbo" => FoodType.Gumbo
    };
}

Ingredient GetIngredient()
{
    Console.Write("What will be the main ingredient (Mushrooms, Chicken, Carrots, or potatoes): ");
    string input = Console.ReadLine();
    return input switch
    {
        "mushrooms" => Ingredient.Mushrooms,
        "chicken" => Ingredient.Chicken,
        "carrots" => Ingredient.Carrots,
        "potatoes" => Ingredient.Potatoes
    };
}

Seasoning GetSeasoning()
{
    Console.Write("What seasoning will be used (Spicy, Salty, or Sweet): ");
    string input = Console.ReadLine();
    return input switch
    {
        "spicy" => Seasoning.Spicy,
        "salty" => Seasoning.Salty,
        "sweet" => Seasoning.Sweet
    };
}

enum FoodType { Soup, Stew, Gumbo };

enum Ingredient { Mushrooms, Chicken, Carrots, Potatoes };

enum Seasoning { Spicy, Salty, Sweet };