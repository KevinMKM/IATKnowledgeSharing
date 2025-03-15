namespace DesignPatterns.Behavioral.Strategy;

using System;

// Strategy interface
interface IPaymentStrategy
{
    void ProcessPayment(double amount);
}

// Concrete strategies
class CreditCardPayment : IPaymentStrategy
{
    public void ProcessPayment(double amount)
    {
        Console.WriteLine($"Processing credit card payment of {amount}");
    }
}

class PayPalPayment : IPaymentStrategy
{
    public void ProcessPayment(double amount)
    {
        Console.WriteLine($"Processing PayPal payment of {amount}");
    }
}

class BitcoinPayment : IPaymentStrategy
{
    public void ProcessPayment(double amount)
    {
        Console.WriteLine($"Processing Bitcoin payment of {amount}");
    }
}

// Context class
class PaymentProcessor
{
    private IPaymentStrategy _paymentStrategy;

    public void SetPaymentStrategy(IPaymentStrategy paymentStrategy)
    {
        _paymentStrategy = paymentStrategy;
    }

    public void ProcessPayment(double amount)
    {
        _paymentStrategy.ProcessPayment(amount);
    }
}

// Client code
class Program
{
    static void Main(string[] args)
    {
        PaymentProcessor processor = new PaymentProcessor();

        // Use CreditCard payment
        processor.SetPaymentStrategy(new CreditCardPayment());
        processor.ProcessPayment(100.0);

        // Use PayPal payment
        processor.SetPaymentStrategy(new PayPalPayment());
        processor.ProcessPayment(50.0);

        // Use Bitcoin payment
        processor.SetPaymentStrategy(new BitcoinPayment());
        processor.ProcessPayment(25.0);
    }
}