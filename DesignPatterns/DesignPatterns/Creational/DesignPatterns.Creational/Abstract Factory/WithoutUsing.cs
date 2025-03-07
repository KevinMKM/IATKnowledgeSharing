namespace DesignPatterns.Creational.Abstract_Factory;

// Concrete products
class WindowsButton
{
    public void Render()
    {
        Console.WriteLine("Rendering a Windows button");
    }
}

class WindowsTextBox
{
    public void Render()
    {
        Console.WriteLine("Rendering a Windows text box");
    }
}

class MacOSButton
{
    public void Render()
    {
        Console.WriteLine("Rendering a macOS button");
    }
}

class MacOSTextBox
{
    public void Render()
    {
        Console.WriteLine("Rendering a macOS text box");
    }
}

// Client code
class Program
{
    static void Main(string[] args)
    {
        string theme = "windows"; // Can be "windows" or "macos"

        if (theme == "windows")
        {
            WindowsButton button = new WindowsButton();
            WindowsTextBox textBox = new WindowsTextBox();

            button.Render();
            textBox.Render();
        }
        else if (theme == "macos")
        {
            MacOSButton button = new MacOSButton();
            MacOSTextBox textBox = new MacOSTextBox();

            button.Render();
            textBox.Render();
        }
        else
        {
            throw new ArgumentException("Unknown theme");
        }
    }
}