namespace DesignPatterns.Structural.Composite;

using System;
using System.Collections.Generic;

// File class
class File
{
    public string Name { get; }

    public File(string name)
    {
        Name = name;
    }

    public void Display()
    {
        Console.WriteLine($"File: {Name}");
    }
}

// Folder class
class Folder
{
    public string Name { get; }
    private List<File> _files = new List<File>();

    public Folder(string name)
    {
        Name = name;
    }

    public void AddFile(File file)
    {
        _files.Add(file);
    }

    public void Display()
    {
        Console.WriteLine($"Folder: {Name}");
        foreach (var file in _files)
        {
            file.Display();
        }
    }
}

// Client code
class Program
{
    static void Main(string[] args)
    {
        // Create files
        File file1 = new File("file1.txt");
        File file2 = new File("file2.txt");

        // Create a folder and add files to it
        Folder folder = new Folder("Folder1");
        folder.AddFile(file1);
        folder.AddFile(file2);

        // Display files and folders
        file1.Display();
        file2.Display();
        folder.Display();
    }
}