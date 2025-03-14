namespace DesignPatterns.Behavioral.Iterator;

using System;
using System.Collections;
using System.Collections.Generic;

// Aggregate interface
interface IAggregate
{
    IIterator CreateIterator();
}

// Concrete aggregate
class NameCollection : IAggregate
{
    private List<string> _names = new List<string>();

    public void AddName(string name)
    {
        _names.Add(name);
    }

    public IIterator CreateIterator()
    {
        return new NameIterator(_names);
    }
}

// Iterator interface
interface IIterator
{
    bool HasNext();
    string Next();
}

// Concrete iterator
class NameIterator : IIterator
{
    private List<string> _names;
    private int _position = 0;

    public NameIterator(List<string> names)
    {
        _names = names;
    }

    public bool HasNext()
    {
        return _position < _names.Count;
    }

    public string Next()
    {
        if (HasNext())
        {
            return _names[_position++];
        }
        throw new InvalidOperationException("No more elements");
    }
}

// Client code
class Program
{
    static void Main(string[] args)
    {
        // Create the aggregate
        NameCollection names = new NameCollection();
        names.AddName("Alice");
        names.AddName("Bob");
        names.AddName("Charlie");

        // Create the iterator
        IIterator iterator = names.CreateIterator();

        // Traverse the collection using the iterator
        while (iterator.HasNext())
        {
            Console.WriteLine(iterator.Next());
        }
    }
}