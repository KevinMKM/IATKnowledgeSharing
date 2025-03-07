namespace DesignPatterns.Creational.Builder;

// Product
class House
{
    public string Walls { get; set; }
    public string Roof { get; set; }
    public int Windows { get; set; }
    public int Doors { get; set; }
    public bool HasGarage { get; set; }
    public bool HasSwimmingPool { get; set; }

    public void Display()
    {
        Console.WriteLine($"House with {Walls} walls, {Roof} roof, {Windows} windows, {Doors} doors, " +
                          $"{(HasGarage ? "with garage" : "no garage")}, " +
                          $"{(HasSwimmingPool ? "with swimming pool" : "no swimming pool")}");
    }
}

// Builder interface
interface IHouseBuilder
{
    void BuildWalls(string walls);
    void BuildRoof(string roof);
    void BuildWindows(int windows);
    void BuildDoors(int doors);
    void BuildGarage(bool hasGarage);
    void BuildSwimmingPool(bool hasSwimmingPool);
    House GetHouse();
}

// Concrete builder
class HouseBuilder : IHouseBuilder
{
    private House _house = new House();

    public void BuildWalls(string walls)
    {
        _house.Walls = walls;
    }

    public void BuildRoof(string roof)
    {
        _house.Roof = roof;
    }

    public void BuildWindows(int windows)
    {
        _house.Windows = windows;
    }

    public void BuildDoors(int doors)
    {
        _house.Doors = doors;
    }

    public void BuildGarage(bool hasGarage)
    {
        _house.HasGarage = hasGarage;
    }

    public void BuildSwimmingPool(bool hasSwimmingPool)
    {
        _house.HasSwimmingPool = hasSwimmingPool;
    }

    public House GetHouse()
    {
        return _house;
    }
}

// Director (optional)
class HouseDirector
{
    private IHouseBuilder _builder;

    public HouseDirector(IHouseBuilder builder)
    {
        _builder = builder;
    }

    public void Construct()
    {
        _builder.BuildWalls("brick");
        _builder.BuildRoof("tile");
        _builder.BuildWindows(4);
        _builder.BuildDoors(2);
        _builder.BuildGarage(true);
        _builder.BuildSwimmingPool(false);
    }
}

// Client code
class Program
{
    static void Main(string[] args)
    {
        HouseBuilder builder = new HouseBuilder();
        HouseDirector director = new HouseDirector(builder);

        director.Construct(); // Construct the house step-by-step
        House house = builder.GetHouse();

        house.Display();
    }
}