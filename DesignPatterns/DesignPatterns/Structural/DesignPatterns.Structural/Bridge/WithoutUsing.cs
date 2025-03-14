namespace DesignPatterns.Structural.Bridge;

using System;

// Base class for shapes
abstract class Shape
{
    public abstract void Draw();
}

// Concrete shapes for vector rendering
class VectorCircle : Shape
{
    public override void Draw()
    {
        Console.WriteLine("Drawing a circle in vector format");
    }
}

class VectorSquare : Shape
{
    public override void Draw()
    {
        Console.WriteLine("Drawing a square in vector format");
    }
}

// Concrete shapes for raster rendering
class RasterCircle : Shape
{
    public override void Draw()
    {
        Console.WriteLine("Drawing a circle in raster format");
    }
}

class RasterSquare : Shape
{
    public override void Draw()
    {
        Console.WriteLine("Drawing a square in raster format");
    }
}

// Client code
class Program
{
    static void Main(string[] args)
    {
        Shape vectorCircle = new VectorCircle();
        Shape rasterSquare = new RasterSquare();

        vectorCircle.Draw();
        rasterSquare.Draw();
    }
}