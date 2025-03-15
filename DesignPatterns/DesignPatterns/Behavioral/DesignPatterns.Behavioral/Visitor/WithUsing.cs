namespace DesignPatterns.Behavioral.Visitor;

using System;

// Visitor interface
interface IExportVisitor
{
    void VisitText(TextElement text);
    void VisitImage(ImageElement image);
}

// Concrete visitors
class HtmlExportVisitor : IExportVisitor
{
    public void VisitText(TextElement text)
    {
        Console.WriteLine($"Exporting text to HTML: {text.Content}");
    }

    public void VisitImage(ImageElement image)
    {
        Console.WriteLine($"Exporting image to HTML: {image.Source}");
    }
}

class PlainTextExportVisitor : IExportVisitor
{
    public void VisitText(TextElement text)
    {
        Console.WriteLine($"Exporting text to plain text: {text.Content}");
    }

    public void VisitImage(ImageElement image)
    {
        Console.WriteLine($"Exporting image to plain text: {image.Source}");
    }
}

// Element interface
interface IDocumentElement
{
    void Accept(IExportVisitor visitor);
}

// Concrete elements
class TextElement : IDocumentElement
{
    public string Content { get; set; }

    public void Accept(IExportVisitor visitor)
    {
        visitor.VisitText(this);
    }
}

class ImageElement : IDocumentElement
{
    public string Source { get; set; }

    public void Accept(IExportVisitor visitor)
    {
        visitor.VisitImage(this);
    }
}

// Client code
class Program
{
    static void Main(string[] args)
    {
        TextElement text = new TextElement { Content = "Hello, World!" };
        ImageElement image = new ImageElement { Source = "image.png" };

        IExportVisitor htmlVisitor = new HtmlExportVisitor();
        IExportVisitor plainTextVisitor = new PlainTextExportVisitor();

        text.Accept(htmlVisitor);
        text.Accept(plainTextVisitor);

        image.Accept(htmlVisitor);
        image.Accept(plainTextVisitor);
    }
}