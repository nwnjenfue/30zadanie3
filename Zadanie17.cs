using System;

namespace CS30Nasledovanie;

public static class Zadanie17
{
    class Device
    {
        public virtual void TurnOn() => Console.WriteLine("Устройство включено.");
        public virtual void TurnOff() => Console.WriteLine("Устройство выключено.");
    }

    class Phone : Device
    {
        public override void TurnOn() => Console.WriteLine("Телефон включён.");
        public override void TurnOff() => Console.WriteLine("Телефон выключен.");
    }

    class Computer : Device
    {
        public override void TurnOn() => Console.WriteLine("Компьютер включён.");
        public override void TurnOff() => Console.WriteLine("Компьютер выключен.");
    }

    class Television : Device
    {
        public override void TurnOn() => Console.WriteLine("Телевизор включён.");
        public override void TurnOff() => Console.WriteLine("Телевизор выключен.");
    }

    public static void Run()
    {
        Console.WriteLine("17. Электронные устройства");
        Console.WriteLine("1 - Phone");
        Console.WriteLine("2 - Computer");
        Console.WriteLine("3 - Television");

        int type = Input.ReadInt("Тип: ");
        Device? device = type switch
        {
            1 => new Phone(),
            2 => new Computer(),
            3 => new Television(),
            _ => null
        };

        if (device == null)
        {
            Console.WriteLine("Неверный тип.");
        }
        else
        {
            Console.WriteLine("1 - TurnOn");
            Console.WriteLine("2 - TurnOff");
            int action = Input.ReadInt("Действие: ");

            if (action == 1) device.TurnOn();
            else if (action == 2) device.TurnOff();
            else Console.WriteLine("Неверное действие.");
        }

        Input.Pause();
    }
}
