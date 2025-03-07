namespace DesignPatterns.Creational.Factory;

// Client code
class WithUsing
{
    static void Main(string[] args)
    {
        string vehicleType = "car"; // Can be dynamically determined (e.g., from config or user input)

        IVehicleFactory factory;

        if (vehicleType == "car")
        {
            factory = new CarFactory();
        }
        else if (vehicleType == "bike")
        {
            factory = new BikeFactory();
        }
        else
        {
            throw new ArgumentException("Unknown vehicle type");
        }

        IVehicle vehicle = factory.CreateVehicle();
        vehicle.Operate();
    }
}

// Product interface
interface IVehicle
{
    void Operate();
}

// Concrete products
class Car : IVehicle
{
    public void Operate()
    {
        Console.WriteLine("Driving a car");
    }
}

class Bike : IVehicle
{
    public void Operate()
    {
        Console.WriteLine("Riding a bike");
    }
}

// Creator (Factory) interface
interface IVehicleFactory
{
    IVehicle CreateVehicle();
}

// Concrete creators
class CarFactory : IVehicleFactory
{
    public IVehicle CreateVehicle()
    {
        return new Car();
    }
}

class BikeFactory : IVehicleFactory
{
    public IVehicle CreateVehicle()
    {
        return new Bike();
    }
}