using System;

namespace CS30Nasledovanie;

public static class Zadanie26
{
    abstract class Character
    {
        public string Name { get; set; }

        protected Character(string name) => Name = name;

        public abstract void Attack();
        public abstract void Defend();
        public abstract void SpecialAttack();
    }

    class Warrior : Character
    {
        public Warrior(string name) : base(name) { }
        public override void Attack() => Console.WriteLine($"{Name}: атакует мечом.");
        public override void Defend() => Console.WriteLine($"{Name}: защищается щитом.");
        public override void SpecialAttack() => Console.WriteLine($"{Name}: выполняет яростный удар.");
    }

    class Mage : Character
    {
        public Mage(string name) : base(name) { }
        public override void Attack() => Console.WriteLine($"{Name}: атакует магией.");
        public override void Defend() => Console.WriteLine($"{Name}: создаёт магический щит.");
        public override void SpecialAttack() => Console.WriteLine($"{Name}: использует молнию.");
    }

    class Archer : Character
    {
        public Archer(string name) : base(name) { }
        public override void Attack() => Console.WriteLine($"{Name}: стреляет из лука.");
        public override void Defend() => Console.WriteLine($"{Name}: уклоняется.");
        public override void SpecialAttack() => Console.WriteLine($"{Name}: выпускает град стрел.");
    }

    public static void Run()
    {
        Console.WriteLine("26. Игра: персонажи");
        Console.WriteLine("1 - Warrior");
        Console.WriteLine("2 - Mage");
        Console.WriteLine("3 - Archer");

        int type = Input.ReadInt("Тип персонажа: ");
        string name = Input.ReadString("Имя персонажа: ");

        Character? character = type switch
        {
            1 => new Warrior(name),
            2 => new Mage(name),
            3 => new Archer(name),
            _ => null
        };

        if (character == null)
        {
            Console.WriteLine("Неверный тип.");
        }
        else
        {
            character.Attack();
            character.Defend();
            character.SpecialAttack();
        }

        Input.Pause();
    }
}
