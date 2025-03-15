namespace DesignPatterns.Behavioral.State;

using System;

// State interface
interface IVendingMachineState
{
    void InsertCoin(VendingMachine vendingMachine);
    void EjectCoin(VendingMachine vendingMachine);
    void Dispense(VendingMachine vendingMachine);
}

// Concrete states
class NoCoinState : IVendingMachineState
{
    public void InsertCoin(VendingMachine vendingMachine)
    {
        Console.WriteLine("Coin inserted");
        vendingMachine.State = new HasCoinState();
    }

    public void EjectCoin(VendingMachine vendingMachine)
    {
        Console.WriteLine("No coin to eject");
    }

    public void Dispense(VendingMachine vendingMachine)
    {
        Console.WriteLine("Insert coin first");
    }
}

class HasCoinState : IVendingMachineState
{
    public void InsertCoin(VendingMachine vendingMachine)
    {
        Console.WriteLine("Coin already inserted");
    }

    public void EjectCoin(VendingMachine vendingMachine)
    {
        Console.WriteLine("Coin ejected");
        vendingMachine.State = new NoCoinState();
    }

    public void Dispense(VendingMachine vendingMachine)
    {
        if (vendingMachine.Count > 0)
        {
            Console.WriteLine("Drink dispensed");
            vendingMachine.Count--;
            vendingMachine.State = new NoCoinState();
        }
        else
        {
            Console.WriteLine("Out of drinks");
            vendingMachine.State = new SoldOutState();
        }
    }
}

class SoldOutState : IVendingMachineState
{
    public void InsertCoin(VendingMachine vendingMachine)
    {
        Console.WriteLine("Machine is sold out");
    }

    public void EjectCoin(VendingMachine vendingMachine)
    {
        Console.WriteLine("Cannot eject coin, machine is sold out");
    }

    public void Dispense(VendingMachine vendingMachine)
    {
        Console.WriteLine("Machine is sold out");
    }
}

// Context class
class VendingMachine
{
    public IVendingMachineState State { get; set; }
    public int Count { get; set; }

    public VendingMachine(int count)
    {
        Count = count;
        State = new NoCoinState();
    }

    public void InsertCoin()
    {
        State.InsertCoin(this);
    }

    public void EjectCoin()
    {
        State.EjectCoin(this);
    }

    public void Dispense()
    {
        State.Dispense(this);
    }
}

// Client code
class Program
{
    static void Main(string[] args)
    {
        VendingMachine vendingMachine = new VendingMachine(1);

        vendingMachine.InsertCoin();
        vendingMachine.Dispense();
        vendingMachine.EjectCoin();
    }
}