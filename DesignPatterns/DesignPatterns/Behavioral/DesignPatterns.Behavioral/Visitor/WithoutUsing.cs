namespace DesignPatterns.Behavioral.Visitor;

using System;

// Element classes
class TextElement
{
    public string Content { get; set; }

    public void ExportToHtml()
    {
        Console.WriteLine($"Exporting text to HTML: {Content}");
    }

    public void ExportToPlainText()
    {
        Console.WriteLine($"Exporting text to plain text: {Content}");
    }
}

class ImageElement
{
    public string Source { get; set; }

    public void ExportToHtml()
    {
        Console.WriteLine($"Exporting image to HTML: {Source}");
    }

    public void ExportToPlainText()
    {
        Console.WriteLine($"Exporting image to plain text: {Source}");
    }
}

// Client code
class Program
{
    static void Main(string[] args)
    {
        TextElement text = new TextElement { Content = "Hello, World!" };
        ImageElement image = new ImageElement { Source = "image.png" };

        text.ExportToHtml();
        text.ExportToPlainText();

        image.ExportToHtml();
        image.ExportToPlainText();
    }
}