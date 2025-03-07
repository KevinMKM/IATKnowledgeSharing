namespace DesignPatterns.Creational.Builder;
class House
{
    public string Walls { get; set; }
    public string Roof { get; set; }
    public int Windows { get; set; }
    public int Doors { get; set; }
    public bool HasGarage { get; set; }
    public bool HasSwimmingPool { get; set; }

    public House(string walls, string roof, int windows, int doors, bool hasGarage, bool hasSwimmingPool)
    {
        Walls = walls;
        Roof = roof;
        Windows = windows;
        Doors = doors;
        HasGarage = hasGarage;
        HasSwimmingPool = hasSwimmingPool;
    }

    public void Display()
    {
        Console.WriteLine($"House with {Walls} walls, {Roof} roof, {Windows} windows, {Doors} doors, " +
                          $"{(HasGarage ? "with garage" : "no garage")}, " +
                          $"{(HasSwimmingPool ? "with swimming pool" : "no swimming pool")}");
    }
}

// Client code
class Program
{
    static void Main(string[] args)
    {
        House house = new House("brick", "tile", 4, 2, true, false);
        house.Display();
    }
}