using System;

Tree tree = new Tree();
Harvester harvester = new Harvester(tree);
Announcer annoucer = new Announcer(tree);

while (true)
    tree.TryGrow();


public class Tree
{
    private Random _random = new Random();
    public bool Ripe { get; set; }
    public event Action TreeRipened;
   

    public void TryGrow()
    {
        if(_random.NextDouble() < 0.00000001 && !Ripe)
        {
            Ripe = true;
            // Console.WriteLine("The tree is ripe."); // this needs to go to Annoucer class

            TreeRipened();
        }
    }
}

public class Announcer
{
    private void OnRipen() => AnnouceTreeIsRipe();

    public void AnnouceTreeIsRipe()
    {
        Console.WriteLine("The tree is ripe");
    }

    public Announcer(Tree tree)
    {
        tree.TreeRipened += OnRipen;
    }
}

public class Harvester
{
    public int HarvestCounter { get; set; } = 0;
    private Tree _tree;
    private void OnRipen() => HarvestTree();

    public void HarvestTree()
    {
        _tree.Ripe = false;
        HarvestCounter++;
        Console.WriteLine($"The tree has been harvested {HarvestCounter} times.");
    }

    public Harvester(Tree tree)
    {
        _tree.TreeRipened += OnRipen;
        _tree = tree;
        
    }
}