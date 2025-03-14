namespace DesignPatterns.Behavioral.Command;

using System;

// Command interface
interface ICommand
{
    void Execute();
}

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

// Concrete commands
class LightOnCommand : ICommand
{
    private Light _light;

    public LightOnCommand(Light light)
    {
        _light = light;
    }

    public void Execute()
    {
        _light.On();
    }
}

class LightOffCommand : ICommand
{
    private Light _light;

    public LightOffCommand(Light light)
    {
        _light = light;
    }

    public void Execute()
    {
        _light.Off();
    }
}

// Invoker
class RemoteControl
{
    private ICommand _command;

    public void SetCommand(ICommand command)
    {
        _command = command;
    }

    public void PressButton()
    {
        _command.Execute();
    }
}

// Client code
class Program
{
    static void Main(string[] args)
    {
        // Create the receiver
        Light light = new Light();

        // Create the commands
        ICommand lightOn = new LightOnCommand(light);
        ICommand lightOff = new LightOffCommand(light);

        // Create the invoker
        RemoteControl remote = new RemoteControl();

        // Set and execute the commands
        remote.SetCommand(lightOn);
        remote.PressButton();

        remote.SetCommand(lightOff);
        remote.PressButton();
    }
}