using System;

namespace CS30Nasledovanie;

public static class Zadanie7
{
    class Worker
    {
        public string Name { get; set; }
        public string Position { get; set; }

        public Worker(string name, string position)
        {
            Name = name;
            Position = position;
        }

        public virtual void ShowInfo()
        {
            Console.WriteLine($"{Name} — {Position}");
        }
    }

    class Cashier : Worker
    {
        public decimal CashHandled { get; set; }

        public Cashier(string name, decimal cashHandled)
            : base(name, "Кассир")
        {
            CashHandled = cashHandled;
        }

        public override void ShowInfo()
        {
            Console.WriteLine($"{Name} — {Position}");
            Console.WriteLine($"Обработано денег: {CashHandled:F2}");
        }
    }

    class Seller : Worker
    {
        public int SalesCount { get; set; }

        public Seller(string name, int salesCount)
            : base(name, "Продавец")
        {
            SalesCount = salesCount;
        }

        public override void ShowInfo()
        {
            Console.WriteLine($"{Name} — {Position}");
            Console.WriteLine($"Количество продаж: {SalesCount}");
        }
    }

    public static void Run()
    {
        Console.WriteLine("7. Работник магазина");
        Console.WriteLine("1 - Cashier");
        Console.WriteLine("2 - Seller");

        int choice = Input.ReadInt("Ваш выбор: ");
        string name = Input.ReadString("Имя: ");

        if (choice == 1)
        {
            decimal cash = Input.ReadDecimal("Сумма обработанных денег: ");
            new Cashier(name, cash).ShowInfo();
        }
        else if (choice == 2)
        {
            int sales = Input.ReadInt("Количество продаж: ");
            new Seller(name, sales).ShowInfo();
        }
        else
        {
            Console.WriteLine("Неверный выбор.");
        }

        Input.Pause();
    }
}
