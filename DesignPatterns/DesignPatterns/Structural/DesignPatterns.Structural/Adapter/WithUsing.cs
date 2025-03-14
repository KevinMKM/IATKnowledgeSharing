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
interface IPaymentProcessor
{
    void Pay(string cardNumber, decimal amount);
}

// Adapter class
class PaymentGatewayAdapter : IPaymentProcessor
{
    private ThirdPartyPaymentGateway _gateway;

    public PaymentGatewayAdapter(ThirdPartyPaymentGateway gateway)
    {
        _gateway = gateway;
    }

    public void Pay(string cardNumber, decimal amount)
    {
        // Convert the card number to a merchant ID (dummy logic)
        string merchantId = $"MERCHANT-{cardNumber.Substring(0, 4)}";

        // Call the third-party gateway's method
        _gateway.ProcessPayment(merchantId, amount);
    }
}

// Your system's payment processor (concrete implementation)
class PaymentProcessor : IPaymentProcessor
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
        IPaymentProcessor processor = new PaymentProcessor();
        processor.Pay("1234-5678-9012-3456", 100.00m);

        // Using the third-party payment gateway via the adapter
        ThirdPartyPaymentGateway gateway = new ThirdPartyPaymentGateway();
        IPaymentProcessor adapter = new PaymentGatewayAdapter(gateway);
        adapter.Pay("9876-5432-1098-7654", 200.00m);
    }
}