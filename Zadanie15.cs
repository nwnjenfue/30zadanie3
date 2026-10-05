using System;

namespace CS30Nasledovanie;

public static class Zadanie15
{
    class MilitaryVehicle
    {
        public string Name { get; set; }

        public MilitaryVehicle(string name) => Name = name;

        public virtual void Attack() => Console.WriteLine($"{Name} атакует.");
    }

    class Tank : MilitaryVehicle
    {
        public Tank(string name) : base(name) { }
        public override void Attack() => Console.WriteLine($"{Name}: атака из пушки.");
    }

    class Helicopter : MilitaryVehicle
    {
        public Helicopter(string name) : base(name) { }
        public override void Attack() => Console.WriteLine($"{Name}: ракетная атака с воздуха.");
    }

    class ArmoredCar : MilitaryVehicle
    {
        public ArmoredCar(string name) : base(name) { }
        public override void Attack() => Console.WriteLine($"{Name}: атака из пулемёта.");
    }

    public static void Run()
    {
        Console.WriteLine("15. Военная техника");
        Console.WriteLine("1 - Tank");
        Console.WriteLine("2 - Helicopter");
        Console.WriteLine("3 - ArmoredCar");

        int type = Input.ReadInt("Тип: ");
        string name = Input.ReadString("Название техники: ");

        MilitaryVehicle? vehicle = type switch
        {
            1 => new Tank(name),
            2 => new Helicopter(name),
            3 => new ArmoredCar(name),
            _ => null
        };

        if (vehicle == null)
            Console.WriteLine("Неверный тип.");
        else
            vehicle.Attack();

        Input.Pause();
    }
}
