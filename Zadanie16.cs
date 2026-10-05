using System;

namespace CS30Nasledovanie;

public static class Zadanie16
{
    class Character
    {
        public string Name { get; set; }
        public int Health { get; set; }
        public int Damage { get; set; }

        public Character(string name, int health, int damage)
        {
            Name = name;
            Health = health;
            Damage = damage;
        }

        public virtual void Attack() => Console.WriteLine($"{Name} атакует: {Damage} урона.");
    }

    class Warrior : Character
    {
        public Warrior(string n, int h, int d) : base(n, h, d) { }
        public override void Attack() => Console.WriteLine($"{Name}: удар мечом = {Damage + 10} урона.");
    }

    class Mage : Character
    {
        public Mage(string n, int h, int d) : base(n, h, d) { }
        public override void Attack() => Console.WriteLine($"{Name}: магическая атака = {Damage * 2} урона.");
    }

    class Archer : Character
    {
        public Archer(string n, int h, int d) : base(n, h, d) { }
        public override void Attack() => Console.WriteLine($"{Name}: выстрел = {Damage + 5} урона.");
    }

    public static void Run()
    {
        Console.WriteLine("16. Игровые персонажи");
        Console.WriteLine("1 - Warrior");
        Console.WriteLine("2 - Mage");
        Console.WriteLine("3 - Archer");

        int type = Input.ReadInt("Тип персонажа: ");
        string name = Input.ReadString("Имя: ");
        int health = Input.ReadInt("Health: ");
        int damage = Input.ReadInt("Damage: ");

        Character? character = type switch
        {
            1 => new Warrior(name, health, damage),
            2 => new Mage(name, health, damage),
            3 => new Archer(name, health, damage),
            _ => null
        };

        if (character == null)
            Console.WriteLine("Неверный тип.");
        else
        {
            Console.WriteLine($"Health: {character.Health}");
            character.Attack();
        }

        Input.Pause();
    }
}
