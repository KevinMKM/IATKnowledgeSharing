namespace DesignPatterns.Structural.Decorator;

using System;

// Component interface
abstract class Coffee
{
    public abstract string GetDescription();
    public abstract decimal GetCost();
}

// Concrete component
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

// Decorator base class
abstract class CoffeeDecorator : Coffee
{
    protected Coffee _coffee;

    public CoffeeDecorator(Coffee coffee)
    {
        _coffee = coffee;
    }

    public override string GetDescription()
    {
        return _coffee.GetDescription();
    }

    public override decimal GetCost()
    {
        return _coffee.GetCost();
    }
}

// Concrete decorators
class MilkDecorator : CoffeeDecorator
{
    public MilkDecorator(Coffee coffee) : base(coffee) { }

    public override string GetDescription()
    {
        return $"{_coffee.GetDescription()} with Milk";
    }

    public override decimal GetCost()
    {
        return _coffee.GetCost() + 0.50m;
    }
}

class SugarDecorator : CoffeeDecorator
{
    public SugarDecorator(Coffee coffee) : base(coffee) { }

    public override string GetDescription()
    {
        return $"{_coffee.GetDescription()} with Sugar";
    }

    public override decimal GetCost()
    {
        return _coffee.GetCost() + 0.25m;
    }
}

// Client code
class Program
{
    static void Main(string[] args)
    {
        // Create a simple coffee
        Coffee coffee = new SimpleCoffee();
        Console.WriteLine($"{coffee.GetDescription()} costs {coffee.GetCost():C}");

        // Add milk to the coffee
        coffee = new MilkDecorator(coffee);
        Console.WriteLine($"{coffee.GetDescription()} costs {coffee.GetCost():C}");

        // Add sugar to the coffee
        coffee = new SugarDecorator(coffee);
        Console.WriteLine($"{coffee.GetDescription()} costs {coffee.GetCost():C}");
    }
}