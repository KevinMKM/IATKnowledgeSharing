namespace DesignPatterns.Behavioral.ChainOfResponsibility;

using System;

// Handler interface
abstract class Logger
{
    protected Logger _nextLogger;

    public void SetNextLogger(Logger nextLogger)
    {
        _nextLogger = nextLogger;
    }

    public void Log(string message, string severity)
    {
        if (CanHandle(severity))
        {
            WriteMessage(message);
        }
        else if (_nextLogger != null)
        {
            _nextLogger.Log(message, severity);
        }
        else
        {
            Console.WriteLine($"Unknown severity: {message}");
        }
    }

    protected abstract bool CanHandle(string severity);
    protected abstract void WriteMessage(string message);
}

// Concrete handlers
class InfoLogger : Logger
{
    protected override bool CanHandle(string severity)
    {
        return severity == "Info";
    }

    protected override void WriteMessage(string message)
    {
        Console.WriteLine($"Info: {message}");
    }
}

class WarningLogger : Logger
{
    protected override bool CanHandle(string severity)
    {
        return severity == "Warning";
    }

    protected override void WriteMessage(string message)
    {
        Console.WriteLine($"Warning: {message}");
    }
}

class ErrorLogger : Logger
{
    protected override bool CanHandle(string severity)
    {
        return severity == "Error";
    }

    protected override void WriteMessage(string message)
    {
        Console.WriteLine($"Error: {message}");
    }
}

// Client code
class Program
{
    static void Main(string[] args)
    {
        // Create the chain of loggers
        Logger infoLogger = new InfoLogger();
        Logger warningLogger = new WarningLogger();
        Logger errorLogger = new ErrorLogger();

        infoLogger.SetNextLogger(warningLogger);
        warningLogger.SetNextLogger(errorLogger);

        // Log messages
        infoLogger.Log("This is an info message", "Info");
        infoLogger.Log("This is a warning message", "Warning");
        infoLogger.Log("This is an error message", "Error");
    }
}