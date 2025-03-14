namespace DesignPatterns.Structural.Flyweight;

using System;
using System.Collections.Generic;

// Flyweight class
class CharacterFlyweight
{
    public char Symbol { get; }

    public CharacterFlyweight(char symbol)
    {
        Symbol = symbol;
    }

    public void Display(string font, int size)
    {
        Console.WriteLine($"Character: {Symbol}, Font: {font}, Size: {size}");
    }
}

// Flyweight factory
class CharacterFlyweightFactory
{
    private Dictionary<char, CharacterFlyweight> _flyweights = new Dictionary<char, CharacterFlyweight>();

    public CharacterFlyweight GetFlyweight(char symbol)
    {
        if (!_flyweights.ContainsKey(symbol))
        {
            _flyweights[symbol] = new CharacterFlyweight(symbol);
        }
        return _flyweights[symbol];
    }
}

// Client code
class Program
{
    static void Main(string[] args)
    {
        CharacterFlyweightFactory factory = new CharacterFlyweightFactory();
        List<CharacterFlyweight> characters = new List<CharacterFlyweight>();

        // Create a large number of characters
        for (int i = 0; i < 1000; i++)
        {
            characters.Add(factory.GetFlyweight('A'));
        }

        // Display characters
        foreach (var character in characters)
        {
            character.Display("Arial", 12);
        }
    }
}