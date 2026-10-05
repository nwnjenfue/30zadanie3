using System;

namespace CS30Nasledovanie;

public static class Zadanie2
{
    class Vehicle
    {
        public string Brand { get; set; }
        public double Speed { get; set; }

        public Vehicle(string brand, double speed)
        {
            Brand = brand;
            Speed = speed;
        }
    }

    class Car : Vehicle
    {
        public int Doors { get; set; }

        public Car(string brand, double speed, int doors)
            : base(brand, speed) { Doors = doors; }
    }

    class Motorcycle : Vehicle
    {
        public bool HasSidecar { get; set; }

        public Motorcycle(string brand, double speed, bool hasSidecar)
            : base(brand, speed) { HasSidecar = hasSidecar; }
    }

    public static void Run()
    {
        Console.WriteLine("2. Транспорт");
        Console.WriteLine("1 - Car");
        Console.WriteLine("2 - Motorcycle");
        int type = Input.ReadInt("Выберите тип: ");

        string brand = Input.ReadString("Введите марку: ");
        double speed = Input.ReadDouble("Введите скорость (км/ч): ");

        if (type == 1)
        {
            int doors = Input.ReadInt("Введите количество дверей: ");
            var car = new Car(brand, speed, doors);
            Console.WriteLine($"Brand: {car.Brand}");
            Console.WriteLine($"Speed: {car.Speed:F1} км/ч");
            Console.WriteLine($"Doors: {car.Doors}");
        }
        else if (type == 2)
        {
            bool sidecar = Input.ReadBool("Есть коляска");
            var motorcycle = new Motorcycle(brand, speed, sidecar);
            Console.WriteLine($"Brand: {motorcycle.Brand}");
            Console.WriteLine($"Speed: {motorcycle.Speed:F1} км/ч");
            Console.WriteLine($"Sidecar: {(motorcycle.HasSidecar ? "да" : "нет")}");
        }
        else
        {
            Console.WriteLine("Неверный тип.");
        }

        Input.Pause();
    }
}
