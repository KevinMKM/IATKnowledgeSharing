namespace DesignPatterns.Structural.Composite;

using System;
using System.Collections.Generic;

// Component interface
interface IFileSystemComponent
{
    void Display();
}

// Leaf class (File)
class File : IFileSystemComponent
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

// Composite class (Folder)
class Folder : IFileSystemComponent
{
    public string Name { get; }
    private List<IFileSystemComponent> _components = new List<IFileSystemComponent>();

    public Folder(string name)
    {
        Name = name;
    }

    public void AddComponent(IFileSystemComponent component)
    {
        _components.Add(component);
    }

    public void Display()
    {
        Console.WriteLine($"Folder: {Name}");
        foreach (var component in _components)
        {
            component.Display();
        }
    }
}

// Client code
class Program
{
    static void Main(string[] args)
    {
        // Create files
        IFileSystemComponent file1 = new File("file1.txt");
        IFileSystemComponent file2 = new File("file2.txt");

        // Create folders
        Folder folder1 = new Folder("Folder1");
        folder1.AddComponent(file1);
        folder1.AddComponent(file2);

        Folder folder2 = new Folder("Folder2");
        folder2.AddComponent(new File("file3.txt"));
        folder2.AddComponent(folder1); // Add a folder inside another folder

        // Display the file system structure
        folder2.Display();
    }
}