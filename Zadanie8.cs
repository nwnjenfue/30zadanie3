using System;

namespace CS30Nasledovanie;

public static class Zadanie8
{
    class Computer
    {
        public string Processor { get; set; }
        public int RAM { get; set; }

        public Computer(string processor, int ram)
        {
            Processor = processor;
            RAM = ram;
        }
    }

    class Laptop : Computer
    {
        public double ScreenSize { get; set; }

        public Laptop(string processor, int ram, double screenSize)
            : base(processor, ram)
        {
            ScreenSize = screenSize;
        }
    }

    class Desktop : Computer
    {
        public bool HasDedicatedGpu { get; set; }

        public Desktop(string processor, int ram, bool gpu)
            : base(processor, ram)
        {
            HasDedicatedGpu = gpu;
        }
    }

    public static void Run()
    {
        Console.WriteLine("8. Компьютеры");
        Console.WriteLine("1 - Laptop");
        Console.WriteLine("2 - Desktop");

        int type = Input.ReadInt("Тип: ");
        string processor = Input.ReadString("Процессор: ");
        int ram = Input.ReadInt("RAM (GB): ");

        if (type == 1)
        {
            double screen = Input.ReadDouble("Диагональ экрана: ");
            var laptop = new Laptop(processor, ram, screen);
            Console.WriteLine($"Processor: {laptop.Processor}");
            Console.WriteLine($"RAM: {laptop.RAM} GB");
            Console.WriteLine($"Screen: {laptop.ScreenSize}\"");
        }
        else if (type == 2)
        {
            bool gpu = Input.ReadBool("Есть дискретная видеокарта");
            var desktop = new Desktop(processor, ram, gpu);
            Console.WriteLine($"Processor: {desktop.Processor}");
            Console.WriteLine($"RAM: {desktop.RAM} GB");
            Console.WriteLine($"Dedicated GPU: {(desktop.HasDedicatedGpu ? "да" : "нет")}");
        }
        else
        {
            Console.WriteLine("Неверный тип.");
        }

        Input.Pause();
    }
}
