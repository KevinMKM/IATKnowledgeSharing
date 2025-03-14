namespace DesignPatterns.Structural.Bridge;

using System;

// Implementation interface
interface IRenderer
{
    void RenderCircle();
    void RenderSquare();
}

// Concrete implementations
class VectorRenderer : IRenderer
{
    public void RenderCircle()
    {
        Console.WriteLine("Drawing a circle in vector format");
    }

    public void RenderSquare()
    {
        Console.WriteLine("Drawing a square in vector format");
    }
}

class RasterRenderer : IRenderer
{
    public void RenderCircle()
    {
        Console.WriteLine("Drawing a circle in raster format");
    }

    public void RenderSquare()
    {
        Console.WriteLine("Drawing a square in raster format");
    }
}

// Abstraction
abstract class Shape
{
    protected IRenderer renderer;

    protected Shape(IRenderer renderer)
    {
        this.renderer = renderer;
    }

    public abstract void Draw();
}

// Refined abstractions
class Circle : Shape
{
    public Circle(IRenderer renderer) : base(renderer) { }

    public override void Draw()
    {
        renderer.RenderCircle();
    }
}

class Square : Shape
{
    public Square(IRenderer renderer) : base(renderer) { }

    public override void Draw()
    {
        renderer.RenderSquare();
    }
}

// Client code
class Program
{
    static void Main(string[] args)
    {
        IRenderer vectorRenderer = new VectorRenderer();
        IRenderer rasterRenderer = new RasterRenderer();

        Shape vectorCircle = new Circle(vectorRenderer);
        Shape rasterSquare = new Square(rasterRenderer);

        vectorCircle.Draw();
        rasterSquare.Draw();
    }
}