namespace DesignPatterns.Creational.Abstract_Factory;

// Abstract products
interface IButton
{
    void Render();
}

interface ITextBox
{
    void Render();
}

// Concrete products for Windows
class WindowsButton : IButton
{
    public void Render()
    {
        Console.WriteLine("Rendering a Windows button");
    }
}

class WindowsTextBox : ITextBox
{
    public void Render()
    {
        Console.WriteLine("Rendering a Windows text box");
    }
}

// Concrete products for macOS
class MacOSButton : IButton
{
    public void Render()
    {
        Console.WriteLine("Rendering a macOS button");
    }
}

class MacOSTextBox : ITextBox
{
    public void Render()
    {
        Console.WriteLine("Rendering a macOS text box");
    }
}

// Abstract factory
interface IUIFactory
{
    IButton CreateButton();
    ITextBox CreateTextBox();
}

// Concrete factories
class WindowsUIFactory : IUIFactory
{
    public IButton CreateButton()
    {
        return new WindowsButton();
    }

    public ITextBox CreateTextBox()
    {
        return new WindowsTextBox();
    }
}

class MacOSUIFactory : IUIFactory
{
    public IButton CreateButton()
    {
        return new MacOSButton();
    }

    public ITextBox CreateTextBox()
    {
        return new MacOSTextBox();
    }
}

// Client code
class Program
{
    static void Main(string[] args)
    {
        string theme = "windows"; // Can be "windows" or "macos"

        IUIFactory factory;

        if (theme == "windows")
        {
            factory = new WindowsUIFactory();
        }
        else if (theme == "macos")
        {
            factory = new MacOSUIFactory();
        }
        else
        {
            throw new ArgumentException("Unknown theme");
        }

        IButton button = factory.CreateButton();
        ITextBox textBox = factory.CreateTextBox();

        button.Render();
        textBox.Render();
    }
}