using System;

namespace CS30Nasledovanie;

public static class Zadanie23
{
    abstract class Transport
    {
        public string Name { get; set; }

        protected Transport(string name) => Name = name;

        public abstract void Move();
        public abstract double GetFuelConsumption();
    }

    class Car : Transport
    {
        public Car(string name) : base(name) { }
        public override void Move() => Console.WriteLine($"{Name}: едет по дороге.");
        public override double GetFuelConsumption() => 8;
    }

    class Truck : Transport
    {
        public Truck(string name) : base(name) { }
        public override void Move() => Console.WriteLine($"{Name}: перевозит груз.");
        public override double GetFuelConsumption() => 18;
    }

    class Bus : Transport
    {
        public Bus(string name) : base(name) { }
        public override void Move() => Console.WriteLine($"{Name}: перевозит пассажиров.");
        public override double GetFuelConsumption() => 12;
    }

    class Motorcycle : Transport
    {
        public Motorcycle(string name) : base(name) { }
        public override void Move() => Console.WriteLine($"{Name}: движется на двух колёсах.");
        public override double GetFuelConsumption() => 4;
    }

    public static void Run()
    {
        Console.WriteLine("23. Система транспорта");
        Console.WriteLine("1 - Car");
        Console.WriteLine("2 - Truck");
        Console.WriteLine("3 - Bus");
        Console.WriteLine("4 - Motorcycle");

        int type = Input.ReadInt("Тип: ");
        string name = Input.ReadString("Название/марка: ");

        Transport? transport = type switch
        {
            1 => new Car(name),
            2 => new Truck(name),
            3 => new Bus(name),
            4 => new Motorcycle(name),
            _ => null
        };

        if (transport == null)
        {
            Console.WriteLine("Неверный тип.");
        }
        else
        {
            transport.Move();
            Console.WriteLine($"Расход топлива: {transport.GetFuelConsumption():F1} л/100 км");
        }

        Input.Pause();
    }
}
