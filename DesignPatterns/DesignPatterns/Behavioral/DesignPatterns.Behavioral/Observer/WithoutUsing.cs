namespace DesignPatterns.Behavioral.Observer;

using System;

class WeatherData
{
    private float _temperature;
    private float _humidity;
    private float _pressure;

    private CurrentConditionsDisplay _currentConditionsDisplay;
    private StatisticsDisplay _statisticsDisplay;

    public WeatherData(CurrentConditionsDisplay currentConditionsDisplay, StatisticsDisplay statisticsDisplay)
    {
        _currentConditionsDisplay = currentConditionsDisplay;
        _statisticsDisplay = statisticsDisplay;
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
        _currentConditionsDisplay.Update(_temperature, _humidity, _pressure);
        _statisticsDisplay.Update(_temperature, _humidity, _pressure);
    }
}

class CurrentConditionsDisplay
{
    public void Update(float temperature, float humidity, float pressure)
    {
        Console.WriteLine($"Current conditions: {temperature}F, {humidity}% humidity, {pressure} pressure");
    }
}

class StatisticsDisplay
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
        CurrentConditionsDisplay currentConditionsDisplay = new CurrentConditionsDisplay();
        StatisticsDisplay statisticsDisplay = new StatisticsDisplay();

        WeatherData weatherData = new WeatherData(currentConditionsDisplay, statisticsDisplay);

        // Update weather data
        weatherData.SetMeasurements(75.0f, 60.0f, 29.9f);
    }
}