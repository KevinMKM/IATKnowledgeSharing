namespace DesignPatterns.Structural.Adapter;

using System;

// Third-party payment gateway (incompatible interface)
class ThirdPartyPaymentGateway
{
    public void ProcessPayment(string merchantId, decimal amount)
    {
        Console.WriteLine($"Processing payment of {amount} for merchant {merchantId}");
    }
}

// Your system's payment processor (expected interface)
class PaymentProcessor
{
    public void Pay(string cardNumber, decimal amount)
    {
        Console.WriteLine($"Paying {amount} using card {cardNumber}");
    }
}

// Client code
class Program
{
    static void Main(string[] args)
    {
        // Your system's payment processor
        PaymentProcessor processor = new PaymentProcessor();
        processor.Pay("1234-5678-9012-3456", 100.00m);

        // Third-party payment gateway (incompatible)
        ThirdPartyPaymentGateway gateway = new ThirdPartyPaymentGateway();
        gateway.ProcessPayment("MERCHANT123", 100.00m);
    }
}