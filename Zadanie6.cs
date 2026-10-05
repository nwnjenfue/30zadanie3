using System;

namespace CS30Nasledovanie;

public static class Zadanie6
{
    class Vehicle
    {
        public virtual void Move() => Console.WriteLine("Транспорт движется.");
    }

    class Car : Vehicle
    {
        public override void Move() => Console.WriteLine("Car: автомобиль едет по дороге.");
    }

    class Bus : Vehicle
    {
        public override void Move() => Console.WriteLine("Bus: автобус перевозит пассажиров.");
    }

    class Train : Vehicle
    {
        public override void Move() => Console.WriteLine("Train: поезд движется по рельсам.");
    }

    public static void Run()
    {
        Console.WriteLine("6. Транспорт с методом движения");
        Console.WriteLine("1 - Car");
        Console.WriteLine("2 - Bus");
        Console.WriteLine("3 - Train");

        int choice = Input.ReadInt("Ваш выбор: ");

        Vehicle? vehicle = choice switch
        {
            1 => new Car(),
            2 => new Bus(),
            3 => new Train(),
            _ => null
        };

        if (vehicle == null)
            Console.WriteLine("Неверный выбор.");
        else
            vehicle.Move();

        Input.Pause();
    }
}
