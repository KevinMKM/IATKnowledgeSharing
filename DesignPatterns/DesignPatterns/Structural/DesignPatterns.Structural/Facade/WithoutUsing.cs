namespace DesignPatterns.Structural.Facade;

using System;

// Subsystem components
class DvdPlayer
{
    public void On()
    {
        Console.WriteLine("DVD Player is on");
    }

    public void Play(string movie)
    {
        Console.WriteLine($"Playing movie: {movie}");
    }

    public void Off()
    {
        Console.WriteLine("DVD Player is off");
    }
}

class Projector
{
    public void On()
    {
        Console.WriteLine("Projector is on");
    }

    public void SetInput(DvdPlayer dvdPlayer)
    {
        Console.WriteLine("Projector input set to DVD Player");
    }

    public void Off()
    {
        Console.WriteLine("Projector is off");
    }
}

class SoundSystem
{
    public void On()
    {
        Console.WriteLine("Sound System is on");
    }

    public void SetVolume(int level)
    {
        Console.WriteLine($"Sound System volume set to {level}");
    }

    public void Off()
    {
        Console.WriteLine("Sound System is off");
    }
}

// Client code
class Program
{
    static void Main(string[] args)
    {
        // Create subsystem components
        DvdPlayer dvdPlayer = new DvdPlayer();
        Projector projector = new Projector();
        SoundSystem soundSystem = new SoundSystem();

        // Turn on the home theater system
        dvdPlayer.On();
        projector.On();
        projector.SetInput(dvdPlayer);
        soundSystem.On();
        soundSystem.SetVolume(10);

        // Play a movie
        dvdPlayer.Play("Inception");

        // Turn off the home theater system
        soundSystem.Off();
        projector.Off();
        dvdPlayer.Off();
    }
}