namespace DesignPatterns.Behavioral.Memento;

using System;
using System.Collections.Generic;

class TextEditor
{
    private string _text;
    private List<string> _history = new List<string>();

    public void SetText(string text)
    {
        _history.Add(_text); // Save current state
        _text = text;
    }

    public void Undo()
    {
        if (_history.Count > 0)
        {
            _text = _history[_history.Count - 1];
            _history.RemoveAt(_history.Count - 1);
        }
    }

    public void Display()
    {
        Console.WriteLine($"Current text: {_text}");
    }
}

// Client code
class Program
{
    static void Main(string[] args)
    {
        TextEditor editor = new TextEditor();

        editor.SetText("First draft");
        editor.Display();

        editor.SetText("Second draft");
        editor.Display();

        editor.Undo();
        editor.Display();
    }
}