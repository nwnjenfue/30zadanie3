using System;
using System.Collections.Generic;

namespace CS30Nasledovanie;

public static class Zadanie30
{
    abstract class Vehicle
    {
        public string Brand { get; set; }
        public double Speed { get; set; }
        public decimal Price { get; set; }

        protected Vehicle(string brand, double speed, decimal price)
        {
            Brand = brand;
            Speed = speed;
            Price = price;
        }

        public abstract double GetFuelConsumption();

        public virtual void ShowInfo()
        {
            Console.WriteLine(
                $"{GetType().Name}: {Brand} | Speed={Speed:F1} km/h | " +
                $"Price={Price:F2} | Fuel={GetFuelConsumption():F1} л/100 км");
        }
    }

    class Car : Vehicle
    {
        public int Doors { get; set; }

        public Car(string brand, double speed, decimal price, int doors)
            : base(brand, speed, price) { Doors = doors; }

        public override double GetFuelConsumption() => 8;

        public override void ShowInfo()
        {
            base.ShowInfo();
            Console.WriteLine($"  Дверей: {Doors}");
        }
    }

    class Truck : Vehicle
    {
        public double LoadCapacity { get; set; }

        public Truck(string brand, double speed, decimal price, double load)
            : base(brand, speed, price) { LoadCapacity = load; }

        public override double GetFuelConsumption() => 18;

        public override void ShowInfo()
        {
            base.ShowInfo();
            Console.WriteLine($"  Грузоподъёмность: {LoadCapacity:F1} т");
        }
    }

    class Bus : Vehicle
    {
        public int Seats { get; set; }

        public Bus(string brand, double speed, decimal price, int seats)
            : base(brand, speed, price) { Seats = seats; }

        public override double GetFuelConsumption() => 12;

        public override void ShowInfo()
        {
            base.ShowInfo();
            Console.WriteLine($"  Мест: {Seats}");
        }
    }

    class ElectricCar : Vehicle
    {
        public int BatteryCapacity { get; set; }

        public ElectricCar(string brand, double speed, decimal price, int battery)
            : base(brand, speed, price) { BatteryCapacity = battery; }

        public override double GetFuelConsumption() => 0;

        public override void ShowInfo()
        {
            base.ShowInfo();
            Console.WriteLine($"  Батарея: {BatteryCapacity} kWh");
        }
    }

    class Motorcycle : Vehicle
    {
        public int EngineVolume { get; set; }

        public Motorcycle(string brand, double speed, decimal price, int engine)
            : base(brand, speed, price) { EngineVolume = engine; }

        public override double GetFuelConsumption() => 4.5;

        public override void ShowInfo()
        {
            base.ShowInfo();
            Console.WriteLine($"  Двигатель: {EngineVolume} cm3");
        }
    }

    public static void Run()
    {
        Console.WriteLine("30. Итоговое задание — система автопарка");

        int count = Input.ReadInt("Сколько транспорта добавить в автопарк: ");
        if (count < 1)
        {
            Console.WriteLine("Количество должно быть больше 0.");
            Input.Pause();
            return;
        }

        List<Vehicle> fleet = new();

        for (int i = 1; i <= count; i++)
        {
            Console.WriteLine($"\nТранспорт #{i}");
            AddVehicle(fleet);
        }

        while (true)
        {
            Console.WriteLine("\n========== АВТОПАРК ==========");
            Console.WriteLine("1. Показать весь транспорт");
            Console.WriteLine("2. Добавить транспорт");
            Console.WriteLine("3. Удалить транспорт");
            Console.WriteLine("4. Найти по марке");
            Console.WriteLine("5. Найти самый быстрый");
            Console.WriteLine("6. Найти самый дорогой");
            Console.WriteLine("7. Показать расход топлива");
            Console.WriteLine("0. Выход");

            int choice = Input.ReadInt("Действие: ");

            switch (choice)
            {
                case 1:
                    ShowAll(fleet);
                    break;

                case 2:
                    AddVehicle(fleet);
                    Console.WriteLine("Транспорт добавлен.");
                    break;

                case 3:
                    DeleteVehicle(fleet);
                    break;

                case 4:
                    Search(fleet);
                    break;

                case 5:
                    ShowFastest(fleet);
                    break;

                case 6:
                    ShowMostExpensive(fleet);
                    break;

                case 7:
                    ShowFuel(fleet);
                    break;

                case 0:
                    return;

                default:
                    Console.WriteLine("Неверный пункт.");
                    break;
            }
        }
    }

    static void AddVehicle(List<Vehicle> fleet)
    {
        Console.WriteLine("1 - Car");
        Console.WriteLine("2 - Truck");
        Console.WriteLine("3 - Bus");
        Console.WriteLine("4 - ElectricCar");
        Console.WriteLine("5 - Motorcycle");

        int type = Input.ReadInt("Тип: ");
        string brand = Input.ReadString("Марка: ");
        double speed = Input.ReadDouble("Максимальная скорость (км/ч): ");
        decimal price = Input.ReadDecimal("Цена: ");

        Vehicle? vehicle = null;

        switch (type)
        {
            case 1:
                vehicle = new Car(
                    brand, speed, price,
                    Input.ReadInt("Количество дверей: "));
                break;

            case 2:
                vehicle = new Truck(
                    brand, speed, price,
                    Input.ReadDouble("Грузоподъёмность (т): "));
                break;

            case 3:
                vehicle = new Bus(
                    brand, speed, price,
                    Input.ReadInt("Количество мест: "));
                break;

            case 4:
                vehicle = new ElectricCar(
                    brand, speed, price,
                    Input.ReadInt("Ёмкость батареи (kWh): "));
                break;

            case 5:
                vehicle = new Motorcycle(
                    brand, speed, price,
                    Input.ReadInt("Объём двигателя (cm3): "));
                break;

            default:
                Console.WriteLine("Неверный тип.");
                break;
        }

        if (vehicle != null)
            fleet.Add(vehicle);
    }

    static void ShowAll(List<Vehicle> fleet)
    {
        if (fleet.Count == 0)
        {
            Console.WriteLine("Автопарк пуст.");
            return;
        }

        for (int i = 0; i < fleet.Count; i++)
        {
            Console.WriteLine($"\n[{i}]");
            fleet[i].ShowInfo();
        }
    }

    static void DeleteVehicle(List<Vehicle> fleet)
    {
        if (fleet.Count == 0)
        {
            Console.WriteLine("Автопарк пуст.");
            return;
        }

        ShowAll(fleet);
        int index = Input.ReadInt("Введите индекс для удаления: ");

        if (index >= 0 && index < fleet.Count)
        {
            Console.WriteLine($"Удалён: {fleet[index].Brand}");
            fleet.RemoveAt(index);
        }
        else
        {
            Console.WriteLine("Неверный индекс.");
        }
    }

    static void Search(List<Vehicle> fleet)
    {
        string query = Input.ReadString("Введите марку для поиска: ");
        bool found = false;

        foreach (Vehicle vehicle in fleet)
        {
            if (vehicle.Brand.Contains(query, StringComparison.OrdinalIgnoreCase))
            {
                vehicle.ShowInfo();
                found = true;
            }
        }

        if (!found)
            Console.WriteLine("Транспорт не найден.");
    }

    static void ShowFastest(List<Vehicle> fleet)
    {
        if (fleet.Count == 0)
        {
            Console.WriteLine("Автопарк пуст.");
            return;
        }

        Vehicle fastest = fleet[0];

        foreach (Vehicle vehicle in fleet)
        {
            if (vehicle.Speed > fastest.Speed)
                fastest = vehicle;
        }

        Console.WriteLine("Самый быстрый транспорт:");
        fastest.ShowInfo();
    }

    static void ShowMostExpensive(List<Vehicle> fleet)
    {
        if (fleet.Count == 0)
        {
            Console.WriteLine("Автопарк пуст.");
            return;
        }

        Vehicle expensive = fleet[0];

        foreach (Vehicle vehicle in fleet)
        {
            if (vehicle.Price > expensive.Price)
                expensive = vehicle;
        }

        Console.WriteLine("Самый дорогой транспорт:");
        expensive.ShowInfo();
    }

    static void ShowFuel(List<Vehicle> fleet)
    {
        if (fleet.Count == 0)
        {
            Console.WriteLine("Автопарк пуст.");
            return;
        }

        foreach (Vehicle vehicle in fleet)
        {
            Console.WriteLine(
                $"{vehicle.Brand}: {vehicle.GetFuelConsumption():F1} л/100 км");
        }
    }
}
