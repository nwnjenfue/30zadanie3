using System;

namespace CS30Nasledovanie;

public static class Zadanie20
{
    class Animal
    {
        public string Name { get; set; }

        public Animal(string name) => Name = name;

        public virtual void Eat() => Console.WriteLine($"{Name} ест.");
        public virtual void MakeSound() => Console.WriteLine($"{Name} издаёт звук.");
    }

    class Lion : Animal
    {
        public Lion(string name) : base(name) { }
        public override void Eat() => Console.WriteLine($"{Name} ест мясо.");
        public override void MakeSound() => Console.WriteLine($"{Name}: Р-р-р!");
    }

    class Elephant : Animal
    {
        public Elephant(string name) : base(name) { }
        public override void Eat() => Console.WriteLine($"{Name} ест траву.");
        public override void MakeSound() => Console.WriteLine($"{Name}: трубит.");
    }

    class Monkey : Animal
    {
        public Monkey(string name) : base(name) { }
        public override void Eat() => Console.WriteLine($"{Name} ест фрукты.");
        public override void MakeSound() => Console.WriteLine($"{Name}: У-а-а!");
    }

    class Penguin : Animal
    {
        public Penguin(string name) : base(name) { }
        public override void Eat() => Console.WriteLine($"{Name} ест рыбу.");
        public override void MakeSound() => Console.WriteLine($"{Name}: кря.");
    }

    class Giraffe : Animal
    {
        public Giraffe(string name) : base(name) { }
        public override void Eat() => Console.WriteLine($"{Name} ест листья.");
        public override void MakeSound() => Console.WriteLine($"{Name}: тихий звук.");
    }

    public static void Run()
    {
        Console.WriteLine("20. Животные зоопарка");
        string name = Input.ReadString("Введите имя животного: ");
        Console.WriteLine("1 - Lion");
        Console.WriteLine("2 - Elephant");
        Console.WriteLine("3 - Monkey");
        Console.WriteLine("4 - Penguin");
        Console.WriteLine("5 - Giraffe");

        int type = Input.ReadInt("Тип: ");

        Animal? animal = type switch
        {
            1 => new Lion(name),
            2 => new Elephant(name),
            3 => new Monkey(name),
            4 => new Penguin(name),
            5 => new Giraffe(name),
            _ => null
        };

        if (animal == null)
        {
            Console.WriteLine("Неверный тип.");
        }
        else
        {
            animal.Eat();
            animal.MakeSound();
        }

        Input.Pause();
    }
}
