namespace DesignPatterns.Creational.Prototype;

class Enemy
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
        // Create enemies from scratch
        Enemy enemy1 = new Enemy("Goblin", 100, 10);
        Enemy enemy2 = new Enemy("Orc", 200, 20);
        Enemy enemy3 = new Enemy("Goblin", 100, 10); // Duplicate of enemy1

        enemy1.Display();
        enemy2.Display();
        enemy3.Display();
    }
}