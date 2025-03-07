using System;

// Client code
class WithoutUsing
{
    static void Main(string[] args)
    {
        string vehicleType = "car";

        if (vehicleType == "car")
        {
            Car car = new Car();
            car.Drive();
        }
        else if (vehicleType == "bike")
        {
            Bike bike = new Bike();
            bike.Ride();
        }
        else
        {
            throw new ArgumentException("Unknown vehicle type");
        }
    }
}

// Concrete products
class Car
{
    public void Drive()
    {
        Console.WriteLine("Driving a car");
    }
}

class Bike
{
    public void Ride()
    {
        Console.WriteLine("Riding a bike");
    }
}