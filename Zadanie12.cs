using System;

namespace CS30Nasledovanie;

public static class Zadanie12
{
    class Transport
    {
        public double Distance { get; set; }

        public Transport(double distance) => Distance = distance;

        public virtual double CalculateCost() => 0;
    }

    class Car : Transport
    {
        public Car(double distance) : base(distance) { }
        public override double CalculateCost() => Distance * 30;
    }

    class Truck : Transport
    {
        public Truck(double distance) : base(distance) { }
        public override double CalculateCost() => Distance * 60;
    }

    class Bus : Transport
    {
        public Bus(double distance) : base(distance) { }
        public override double CalculateCost() => Distance * 45;
    }

    public static void Run()
    {
        Console.WriteLine("12. Транспортная компания");
        Console.WriteLine("Тарифы: Car=30, Truck=60, Bus=45 за км.");

        double distance = Input.ReadDouble("Введите расстояние (км): ");
        Console.WriteLine("1 - Car, 2 - Truck, 3 - Bus");
        int type = Input.ReadInt("Выберите транспорт: ");

        Transport? transport = type switch
        {
            1 => new Car(distance),
            2 => new Truck(distance),
            3 => new Bus(distance),
            _ => null
        };

        if (transport == null)
            Console.WriteLine("Неверный тип.");
        else
            Console.WriteLine($"Стоимость перевозки: {transport.CalculateCost():F2}");

        Input.Pause();
    }
}
