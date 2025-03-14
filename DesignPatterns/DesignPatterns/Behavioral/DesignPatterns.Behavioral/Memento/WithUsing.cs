namespace DesignPatterns.Behavioral.Memento;

using System;
using System.Collections.Generic;

// Memento class
class TextMemento
{
    public string Text { get; }

    public TextMemento(string text)
    {
        Text = text;
    }
}

// Originator class
class TextEditor
{
    private string _text;

    public void SetText(string text)
    {
        _text = text;
    }

    public TextMemento Save()
    {
        return new TextMemento(_text);
    }

    public void Restore(TextMemento memento)
    {
        _text = memento.Text;
    }

    public void Display()
    {
        Console.WriteLine($"Current text: {_text}");
    }
}

// Caretaker class
class History
{
    private Stack<TextMemento> _mementos = new Stack<TextMemento>();

    public void SaveState(TextMemento memento)
    {
        _mementos.Push(memento);
    }

    public TextMemento Undo()
    {
        if (_mementos.Count > 0)
        {
            return _mementos.Pop();
        }
        throw new InvalidOperationException("No more states to undo");
    }
}

// Client code
class Program
{
    static void Main(string[] args)
    {
        TextEditor editor = new TextEditor();
        History history = new History();

        // Set and save the first state
        editor.SetText("First draft");
        history.SaveState(editor.Save());
        editor.Display();

        // Set and save the second state
        editor.SetText("Second draft");
        history.SaveState(editor.Save());
        editor.Display();

        // Undo to the first state
        editor.Restore(history.Undo());
        editor.Display();
    }
}