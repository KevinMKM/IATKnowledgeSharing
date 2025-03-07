namespace DesignPatterns.Creational.Singleton;
using System.Collections.Generic;

#region Using Lock


class Logger
{
    private static Logger _instance;
    private static readonly object _lock = new object();

    private Logger() { }

    public static Logger Instance
    {
        get
        {
            lock (_lock)
            {
                if (_instance == null)
                {
                    _instance = new Logger();
                }
                return _instance;
            }
        }
    }

    private List<string> logs = new List<string>();

    public void Log(string message)
    {
        logs.Add(message);
        Console.WriteLine($"Log: {message}");
    }

    public void PrintLogs()
    {
        Console.WriteLine("Logs:");
        foreach (var log in logs)
        {
            Console.WriteLine(log);
        }
    }
}

#endregion

#region Using Lazy<T>

class Logger
{
    private static readonly Lazy<Logger> _lazyInstance = new Lazy<Logger>(() => new Logger());

    private Logger() { }

    public static Logger Instance => _lazyInstance.Value;

    private List<string> logs = new List<string>();

    public void Log(string message)
    {
        logs.Add(message);
        Console.WriteLine($"Log: {message}");
    }

    public void PrintLogs()
    {
        Console.WriteLine("Logs:");
        foreach (var log in logs)
        {
            Console.WriteLine(log);
        }
    }
}

#endregion