namespace DesignPatterns.Behavioral.ChainOfResponsibility;

using System;

class Logger
{
    public void Log(string message, string severity)
    {
        if (severity == "Info")
        {
            Console.WriteLine($"Info: {message}");
        }
        else if (severity == "Warning")
        {
            Console.WriteLine($"Warning: {message}");
        }
        else if (severity == "Error")
        {
            Console.WriteLine($"Error: {message}");
        }
        else
        {
            Console.WriteLine($"Unknown severity: {message}");
        }
    }
}

// Client code
class Program
{
    static void Main(string[] args)
    {
        Logger logger = new Logger();

        logger.Log("This is an info message", "Info");
        logger.Log("This is a warning message", "Warning");
        logger.Log("This is an error message", "Error");
    }
}