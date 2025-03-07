namespace DesignPatterns.Creational.Prototype;

// Prototype interface
interface IEnemyPrototype
{
    IEnemyPrototype Clone();
}

// Concrete prototype
class Enemy : IEnemyPrototype
{
    public string Type { get; set; }
    public int Health { get; set; }
    public int AttackPower { get; set; }

    public Enemy(string type, int health, int attackPower)
    {
        Type = type;
        Health = health;
        AttackPower = attackPower;
    }

    public IEnemyPrototype Clone()
    {
        return new Enemy(Type, Health, AttackPower);
    }

    public void Display()
    {
        Console.WriteLine($"Enemy: {Type}, Health: {Health}, Attack Power: {AttackPower}");
    }
}

// Client code
class Program
{
    static void Main(string[] args)
    {
        // Create prototype enemies
        Enemy goblinPrototype = new Enemy("Goblin", 100, 10);
        Enemy orcPrototype = new Enemy("Orc", 200, 20);

        // Clone prototypes to create new enemies
        Enemy enemy1 = (Enemy)goblinPrototype.Clone();
        Enemy enemy2 = (Enemy)orcPrototype.Clone();
        Enemy enemy3 = (Enemy)goblinPrototype.Clone(); // Clone of goblinPrototype

        // Modify cloned enemies if needed
        enemy3.Health = 120; // Customize health

        enemy1.Display();
        enemy2.Display();
        enemy3.Display();
    }
}