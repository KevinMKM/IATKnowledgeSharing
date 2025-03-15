namespace DesignPatterns.Behavioral.State;

using System;

class VendingMachine
{
    private enum State { NoCoin, HasCoin, Sold, SoldOut }

    private State _state = State.NoCoin;
    private int _count;

    public VendingMachine(int count)
    {
        _count = count;
    }

    public void InsertCoin()
    {
        if (_state == State.NoCoin)
        {
            Console.WriteLine("Coin inserted");
            _state = State.HasCoin;
        }
        else if (_state == State.HasCoin)
        {
            Console.WriteLine("Coin already inserted");
        }
        else if (_state == State.Sold)
        {
            Console.WriteLine("Please wait, dispensing drink");
        }
        else if (_state == State.SoldOut)
        {
            Console.WriteLine("Machine is sold out");
        }
    }

    public void EjectCoin()
    {
        if (_state == State.HasCoin)
        {
            Console.WriteLine("Coin ejected");
            _state = State.NoCoin;
        }
        else if (_state == State.NoCoin)
        {
            Console.WriteLine("No coin to eject");
        }
        else if (_state == State.Sold)
        {
            Console.WriteLine("Cannot eject coin, drink is being dispensed");
        }
        else if (_state == State.SoldOut)
        {
            Console.WriteLine("Cannot eject coin, machine is sold out");
        }
    }

    public void Dispense()
    {
        if (_state == State.HasCoin)
        {
            if (_count > 0)
            {
                Console.WriteLine("Drink dispensed");
                _count--;
                _state = State.NoCoin;
            }
            else
            {
                Console.WriteLine("Out of drinks");
                _state = State.SoldOut;
            }
        }
        else if (_state == State.NoCoin)
        {
            Console.WriteLine("Insert coin first");
        }
        else if (_state == State.Sold)
        {
            Console.WriteLine("Drink already dispensed");
        }
        else if (_state == State.SoldOut)
        {
            Console.WriteLine("Machine is sold out");
        }
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