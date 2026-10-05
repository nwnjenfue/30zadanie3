using System;
using System.Collections.Generic;

namespace CS30Nasledovanie;

public static class Zadanie29
{
    class Animal
    {
        public string Name { get; set; }

        public Animal(string name) => Name = name;

        public virtual void MakeSound()
            => Console.WriteLine($"{Name}: обычный звук.");
    }

    class Dog : Animal
    {
        public Dog(string name) : base(name) { }
        public override void MakeSound() => Console.WriteLine($"{Name}: Гав-гав!");
    }

    class Cat : Animal
    {
        public Cat(string name) : base(name) { }
        public override void MakeSound() => Console.WriteLine($"{Name}: Мяу!");
    }

    class Cow : Animal
    {
        public Cow(string name) : base(name) { }
        public override void MakeSound() => Console.WriteLine($"{Name}: Му-у!");
    }

    class Horse : Animal
    {
        public Horse(string name) : base(name) { }
        public override void MakeSound() => Console.WriteLine($"{Name}: И-го-го!");
    }

    class Duck : Animal
    {
        public Duck(string name) : base(name) { }
        public override void MakeSound() => Console.WriteLine($"{Name}: Кря-кря!");
    }

    public static void Run()
    {
        Console.WriteLine("29. Полиморфизм + наследование");

        int count = Input.ReadInt("Сколько животных добавить (минимум 5): ");
        if (count < 5)
        {
            Console.WriteLine("По условию нужно минимум 5 животных.");
            Input.Pause();
            return;
        }

        List<Animal> animals = new();

        for (int i = 1; i <= count; i++)
        {
            Console.WriteLine($"\nЖивотное #{i}");
            Console.WriteLine("1 - Dog");
            Console.WriteLine("2 - Cat");
            Console.WriteLine("3 - Cow");
            Console.WriteLine("4 - Horse");
            Console.WriteLine("5 - Duck");

            int type = Input.ReadInt("Тип: ");
            string name = Input.ReadString("Имя: ");

            Animal? animal = type switch
            {
                1 => new Dog(name),
                2 => new Cat(name),
                3 => new Cow(name),
                4 => new Horse(name),
                5 => new Duck(name),
                _ => null
            };

            if (animal == null)
            {
                Console.WriteLine("Неверный тип.");
                i--;
            }
            else
            {
                animals.Add(animal);
            }
        }

        Console.WriteLine("\nЗвуки всех животных одним циклом:");
        foreach (Animal animal in animals)
            animal.MakeSound();

        Input.Pause();
    }
}
