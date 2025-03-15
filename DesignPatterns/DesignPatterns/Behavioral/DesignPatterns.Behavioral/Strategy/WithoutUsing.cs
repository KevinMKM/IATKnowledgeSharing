namespace DesignPatterns.Behavioral.Strategy;

using System;

class PaymentProcessor
{
    public void ProcessPayment(string paymentMethod, double amount)
    {
        if (paymentMethod == "CreditCard")
        {
            Console.WriteLine($"Processing credit card payment of {amount}");
        }
        else if (paymentMethod == "PayPal")
        {
            Console.WriteLine($"Processing PayPal payment of {amount}");
        }
        else if (paymentMethod == "Bitcoin")
        {
            Console.WriteLine($"Processing Bitcoin payment of {amount}");
        }
        else
        {
            throw new ArgumentException("Invalid payment method");
        }
    }
}

// Client code
class Program
{
    static void Main(string[] args)
    {
        PaymentProcessor processor = new PaymentProcessor();

        processor.ProcessPayment("CreditCard", 100.0);
        processor.ProcessPayment("PayPal", 50.0);
        processor.ProcessPayment("Bitcoin", 25.0);
    }
}