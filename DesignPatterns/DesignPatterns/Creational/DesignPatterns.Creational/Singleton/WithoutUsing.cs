namespace DesignPatterns.Creational.Singleton;
using System.Collections.Generic;

class Logger
{
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

// Client code
class Program
{
    static void Main(string[] args)
    {
        Logger logger1 = new Logger();
        Logger logger2 = new Logger();

        logger1.Log("Message 1 from logger1");
        logger2.Log("Message 1 from logger2");

        logger1.PrintLogs(); // Only shows logs from logger1
        logger2.PrintLogs(); // Only shows logs from logger2
    }
}