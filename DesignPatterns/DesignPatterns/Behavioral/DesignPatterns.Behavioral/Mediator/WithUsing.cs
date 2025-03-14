namespace DesignPatterns.Behavioral.Mediator;

using System;
using System.Collections.Generic;

// Mediator interface
interface IChatMediator
{
    void SendMessage(string message, User sender, User recipient);
}

// Concrete mediator
class ChatMediator : IChatMediator
{
    public void SendMessage(string message, User sender, User recipient)
    {
        Console.WriteLine($"{sender.Name} sends: {message}");
        recipient.ReceiveMessage(message, sender);
    }
}

// User class
class User
{
    public string Name { get; }
    private IChatMediator _mediator;

    public User(string name, IChatMediator mediator)
    {
        Name = name;
        _mediator = mediator;
    }

    public void SendMessage(string message, User recipient)
    {
        _mediator.SendMessage(message, this, recipient);
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
        // Create the mediator
        IChatMediator mediator = new ChatMediator();

        // Create users
        User alice = new User("Alice", mediator);
        User bob = new User("Bob", mediator);

        // Users communicate through the mediator
        alice.SendMessage("Hello Bob!", bob);
        bob.SendMessage("Hi Alice!", alice);
    }
}