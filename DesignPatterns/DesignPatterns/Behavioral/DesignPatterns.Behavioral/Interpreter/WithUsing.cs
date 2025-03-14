namespace DesignPatterns.Behavioral.Interpreter;

using System;
using System.Collections.Generic;

// Abstract expression
interface IExpression
{
    int Interpret();
}

// Terminal expression
class Number : IExpression
{
    private int _value;

    public Number(int value)
    {
        _value = value;
    }

    public int Interpret()
    {
        return _value;
    }
}

// Non-terminal expression for addition
class Add : IExpression
{
    private IExpression _left;
    private IExpression _right;

    public Add(IExpression left, IExpression right)
    {
        _left = left;
        _right = right;
    }

    public int Interpret()
    {
        return _left.Interpret() + _right.Interpret();
    }
}

// Non-terminal expression for subtraction
class Subtract : IExpression
{
    private IExpression _left;
    private IExpression _right;

    public Subtract(IExpression left, IExpression right)
    {
        _left = left;
        _right = right;
    }

    public int Interpret()
    {
        return _left.Interpret() - _right.Interpret();
    }
}

// Context (optional)
class Context
{
    public IExpression Parse(string expression)
    {
        // Simple parsing logic (only supports addition and subtraction)
        string[] parts = expression.Split(' ');
        IExpression result = new Number(int.Parse(parts[0]));

        for (int i = 1; i < parts.Length; i += 2)
        {
            string op = parts[i];
            IExpression number = new Number(int.Parse(parts[i + 1]));

            if (op == "+")
            {
                result = new Add(result, number);
            }
            else if (op == "-")
            {
                result = new Subtract(result, number);
            }
            else
            {
                throw new ArgumentException($"Unknown operator: {op}");
            }
        }

        return result;
    }
}

// Client code
class Program
{
    static void Main(string[] args)
    {
        Context context = new Context();
        IExpression expression = context.Parse("1 + 2 - 3");
        int result = expression.Interpret();
        Console.WriteLine($"Result: {result}");
    }
}