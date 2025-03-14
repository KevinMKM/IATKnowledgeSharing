namespace DesignPatterns.Behavioral.Mediator;

using System;
using System.Collections.Generic;

class User
{
    public string Name { get; }

    public User(string name)
    {
        Name = name;
    }

    public void SendMessage(string message, User recipient)
    {
        Console.WriteLine($"{Name} sends: {message}");
        recipient.ReceiveMessage(message, this);
    }

    public void ReceiveMessage(string message, User sender)
    {
        Console.WriteLine($"{Name} receives: {message} from {sender.Name}");
    }
}

// Client code
class Program
{
    static void Main(string[] args)
    {
        User alice = new User("Alice");
        User bob = new User("Bob");

        // Users communicate directly
        alice.SendMessage("Hello Bob!", bob);
        bob.SendMessage("Hi Alice!", alice);
    }
}