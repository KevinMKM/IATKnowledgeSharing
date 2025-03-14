namespace DesignPatterns.Structural.Proxy;

using System;
using System.Collections.Generic;

// Character class
class Character
{
    public char Symbol { get; }
    public string Font { get; }
    public int Size { get; }

    public Character(char symbol, string font, int size)
    {
        Symbol = symbol;
        Font = font;
        Size = size;
    }

    public void Display()
    {
        Console.WriteLine($"Character: {Symbol}, Font: {Font}, Size: {Size}");
    }
}

// Client code
class Program
{
    static void Main(string[] args)
    {
        List<Character> characters = new List<Character>();

        // Create a large number of characters
        for (int i = 0; i < 1000; i++)
        {
            characters.Add(new Character('A', "Arial", 12));
        }

        // Display characters
        foreach (var character in characters)
        {
            character.Display();
        }
    }
}