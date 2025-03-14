namespace DesignPatterns.Structural.Decorator;

using System;

// Base coffee class
abstract class Coffee
{
    public abstract string GetDescription();
    public abstract decimal GetCost();
}

// Concrete coffee types
class SimpleCoffee : Coffee
{
    public override string GetDescription()
    {
        return "Simple Coffee";
    }

    public override decimal GetCost()
    {
        return 5.00m;
    }
}

// Subclasses for add-ons
class CoffeeWithMilk : Coffee
{
    public override string GetDescription()
    {
        return "Simple Coffee with Milk";
    }

    public override decimal GetCost()
    {
        return 5.50m;
    }
}

class CoffeeWithSugar : Coffee
{
    public override string GetDescription()
    {
        return "Simple Coffee with Sugar";
    }

    public override decimal GetCost()
    {
        return 5.25m;
    }
}

class CoffeeWithMilkAndSugar : Coffee
{
    public override string GetDescription()
    {
        return "Simple Coffee with Milk and Sugar";
    }

    public override decimal GetCost()
    {
        return 5.75m;
    }
}

// Client code
class Program
{
    static void Main(string[] args)
    {
        Coffee coffee = new CoffeeWithMilkAndSugar();
        Console.WriteLine($"{coffee.GetDescription()} costs {coffee.GetCost():C}");
    }
}