namespace DesignPatterns.Behavioral.Interpreter;

using System;

class Calculator
{
    public int Evaluate(string expression)
    {
        // Simple parsing logic (only supports addition and subtraction)
        string[] parts = expression.Split(' ');
        int result = int.Parse(parts[0]);

        for (int i = 1; i < parts.Length; i += 2)
        {
            string op = parts[i];
            int number = int.Parse(parts[i + 1]);

            if (op == "+")
            {
                result += number;
            }
            else if (op == "-")
            {
                result -= number;
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
        Calculator calculator = new Calculator();
        int result = calculator.Evaluate("1 + 2 - 3");
        Console.WriteLine($"Result: {result}");
    }
}