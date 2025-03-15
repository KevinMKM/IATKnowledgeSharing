namespace DesignPatterns.Behavioral.Observer;

using System;
using System.Collections.Generic;

// Subject interface
interface ISubject
{
    void RegisterObserver(IObserver observer);
    void RemoveObserver(IObserver observer);
    void NotifyObservers();
}

// Concrete subject
class WeatherData : ISubject
{
    private List<IObserver> _observers = new List<IObserver>();
    private float _temperature;
    private float _humidity;
    private float _pressure;

    public void RegisterObserver(IObserver observer)
    {
        _observers.Add(observer);
    }

    public void RemoveObserver(IObserver observer)
    {
        _observers.Remove(observer);
    }

    public void NotifyObservers()
    {
        foreach (var observer in _observers)
        {
            observer.Update(_temperature, _humidity, _pressure);
        }
    }

    public void SetMeasurements(float temperature, float humidity, float pressure)
    {
        _temperature = temperature;
        _humidity = humidity;
        _pressure = pressure;
        MeasurementsChanged();
    }

    private void MeasurementsChanged()
    {
        NotifyObservers();
    }
}

// Observer interface
interface IObserver
{
    void Update(float temperature, float humidity, float pressure);
}

// Concrete observers
class CurrentConditionsDisplay : IObserver
{
    public void Update(float temperature, float humidity, float pressure)
    {
        Console.WriteLine($"Current conditions: {temperature}F, {humidity}% humidity, {pressure} pressure");
    }
}

class StatisticsDisplay : IObserver
{
    public void Update(float temperature, float humidity, float pressure)
    {
        Console.WriteLine($"Statistics: Avg/Max/Min temperature = {temperature}/{temperature}/{temperature}");
    }
}

// Client code
class Program
{
    static void Main(string[] args)
    {
        WeatherData weatherData = new WeatherData();

        CurrentConditionsDisplay currentConditionsDisplay = new CurrentConditionsDisplay();
        StatisticsDisplay statisticsDisplay = new StatisticsDisplay();

        // Register observers
        weatherData.RegisterObserver(currentConditionsDisplay);
        weatherData.RegisterObserver(statisticsDisplay);

        // Update weather data
        weatherData.SetMeasurements(75.0f, 60.0f, 29.9f);
    }
}