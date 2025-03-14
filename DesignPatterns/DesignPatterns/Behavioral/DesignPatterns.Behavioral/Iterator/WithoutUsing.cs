namespace DesignPatterns.Behavioral.Iterator;

using System;
using System.Collections.Generic;

class Program
{
    static void Main(string[] args)
    {
        List<string> names = new List<string> { "Alice", "Bob", "Charlie" };

        // Directly access the list using a for loop
        for (int i = 0; i < names.Count; i++)
        {
            Console.WriteLine(names[i]);
        }
    }
}