using System;

namespace CS30Nasledovanie;

public static class Zadanie18
{
    class Payment
    {
        public virtual void Pay(double amount)
            => Console.WriteLine($"Оплата: {amount:F2}");
    }

    class CashPayment : Payment
    {
        public override void Pay(double amount)
            => Console.WriteLine($"Оплата наличными: {amount:F2}");
    }

    class CardPayment : Payment
    {
        public override void Pay(double amount)
            => Console.WriteLine($"Оплата картой: {amount:F2}");
    }

    class OnlinePayment : Payment
    {
        public override void Pay(double amount)
            => Console.WriteLine($"Онлайн-оплата: {amount:F2}");
    }

    public static void Run()
    {
        Console.WriteLine("18. Платежи");
        Console.WriteLine("1 - CashPayment");
        Console.WriteLine("2 - CardPayment");
        Console.WriteLine("3 - OnlinePayment");

        int type = Input.ReadInt("Способ оплаты: ");
        double amount = Input.ReadDouble("Введите сумму: ");

        Payment? payment = type switch
        {
            1 => new CashPayment(),
            2 => new CardPayment(),
            3 => new OnlinePayment(),
            _ => null
        };

        if (payment == null)
            Console.WriteLine("Неверный способ оплаты.");
        else
            payment.Pay(amount);

        Input.Pause();
    }
}
