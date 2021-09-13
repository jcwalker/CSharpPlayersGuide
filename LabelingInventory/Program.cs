using System;

Pack pack = new Pack(10, 20, 30);

while (true)
{
    Console.WriteLine($"There are currently {pack.Items} out of {pack.MaximumItems} items, volume is at {pack.Volume} out of {pack.MaximumVolume}, and current weight is at {pack.Weight} out of {pack.MaximumWeight}");
    Console.WriteLine("Enter the inventory item you wish to add to you pack");
    Console.Write("Arrow, Bow, Rope, Water, Food Ration, or Sword: ");
    var itemToAdd = Console.ReadLine();

    InventoryItem itemAdded = itemToAdd switch
    {
        "Arrow" => new Arrow(),
        "Bow" => new Bow(),
        "Rope" => new Rope(),
        "Water" => new Water(),
        "Food Ration" => new FoodRation(),
        "Sword" => new Sword()
    };

    if (!pack.Add(itemAdded))
    {
        Console.WriteLine("Pack is too full");
    }

    Console.WriteLine($"{pack}"); // this is an interesting way to do this ie. not using ToString()
}

public class InventoryItem
{
    public float Weight { get; set; }
    public float Volume { get; set; }

    public InventoryItem(float weight, float volume)
    {
        this.Weight = weight;
        this.Volume = volume;
    }

    public InventoryItem() { }
}

public class Pack
{
    public float MaximumItems;
    public float MaximumWeight;
    public float MaximumVolume;
    public int Items;
    public float Weight;
    public float Volume;
    public InventoryItem[] InventoryItems;
 
    public Pack(int items, float weight, float volume)
    {
        this.MaximumItems = items;
        this.MaximumWeight = weight;
        this.MaximumVolume = volume;
        this.InventoryItems = new InventoryItem[items];
    }

    public override string ToString()
    {
        string packItems = string.Empty;

        foreach (InventoryItem item in this.InventoryItems)
        {
            if (!(item == null))
            {
                packItems = $"{packItems} {item.ToString()}";
            }
        }

        return $"Pack containing{packItems}";
    }

    public bool Add(InventoryItem item)
    {
        bool CanAddWeight = item.Weight + this.Weight < this.MaximumWeight ? true : false;
        bool CanAddVolume = item.Volume + this.Volume < this.MaximumVolume ? true : false;
        bool CanAddItem = 1 + this.Items < this.MaximumItems ? true : false;

        if (CanAddItem && CanAddVolume && CanAddWeight)
        {
            this.Items += 1;
            this.Weight += item.Weight;
            this.Volume += item.Volume;
            this.InventoryItems[this.Items] = item;

            return true;
        }

        return false;
    }
}

// arrow class
public class Arrow : InventoryItem
{
    public Arrow() : base(0.1f, 0.05f) { }

    public override string ToString()
    {
        return "Arrow";
    }
}
// bow class
public class Bow : InventoryItem
{
    public Bow() : base(1, 4) { }

    public override string ToString()
    {
        return "Bow";
    }
}
    // rope class
public class Rope : InventoryItem
{
    public Rope()
    {
        this.Weight = 1;
        this.Volume = 1.5f;
    }
}
// water class
public class Water : InventoryItem
{
    public Water()
    {
        this.Weight = 2;
        this.Volume = 3f;
    }
}
// food rations class
public class FoodRation : InventoryItem
{
    public FoodRation()
    {
        this.Weight = 1;
        this.Volume = 0.5f;
    }
}
// sword
public class Sword : InventoryItem
{
    public Sword()
    {
        this.Weight = 5;
        this.Volume = 3;
    }
}
