using System;

Sword ogSword = new Sword(materialType.Iron, gemStoneType.None, 4, 3);
Sword emeraldSword = ogSword with { GemStone = gemStoneType.Emerald };
Sword motherOfAllSwords = ogSword with { Material = materialType.Binarium, GemStone = gemStoneType.Bitstone };

Console.WriteLine(ogSword);
Console.WriteLine(emeraldSword);
Console.WriteLine(motherOfAllSwords);

public record Sword(materialType Material, gemStoneType GemStone, float Length, float CrossGuard);

public enum materialType { Wood, Bronze, Iron, Steel, Binarium };

public enum gemStoneType { None, Emerald, Amber, Sapphire, Diamond, Bitstone };
