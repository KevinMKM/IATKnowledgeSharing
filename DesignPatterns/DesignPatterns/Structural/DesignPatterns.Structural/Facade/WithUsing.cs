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

// Facade
class HomeTheaterFacade
{
    private DvdPlayer _dvdPlayer;
    private Projector _projector;
    private SoundSystem _soundSystem;

    public HomeTheaterFacade(DvdPlayer dvdPlayer, Projector projector, SoundSystem soundSystem)
    {
        _dvdPlayer = dvdPlayer;
        _projector = projector;
        _soundSystem = soundSystem;
    }

    public void WatchMovie(string movie)
    {
        Console.WriteLine("Get ready to watch a movie...");
        _dvdPlayer.On();
        _projector.On();
        _projector.SetInput(_dvdPlayer);
        _soundSystem.On();
        _soundSystem.SetVolume(10);
        _dvdPlayer.Play(movie);
    }

    public void EndMovie()
    {
        Console.WriteLine("Shutting down the home theater...");
        _soundSystem.Off();
        _projector.Off();
        _dvdPlayer.Off();
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

        // Create the facade
        HomeTheaterFacade homeTheater = new HomeTheaterFacade(dvdPlayer, projector, soundSystem);

        // Watch a movie using the facade
        homeTheater.WatchMovie("Inception");

        // End the movie using the facade
        homeTheater.EndMovie();
    }
}