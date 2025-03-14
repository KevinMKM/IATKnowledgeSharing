namespace DesignPatterns.Behavioral.Command;

using System;

// Receiver
class Light
{
    public void On()
    {
        Console.WriteLine("Light is on");
    }

    public void Off()
    {
        Console.WriteLine("Light is off");
    }
}

// Client code
class Program
{
    static void Main(string[] args)
    {
        Light light = new Light();

        // Directly call the light's methods
        light.On();
        light.Off();
    }
}