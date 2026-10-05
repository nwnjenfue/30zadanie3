using System;

namespace CS30Nasledovanie;

public static class Zadanie10
{
    class Pet
    {
        public virtual void Eat() => Console.WriteLine("Питомец ест.");
    }

    class Dog : Pet
    {
        public override void Eat() => Console.WriteLine("Собака ест корм.");
    }

    class Cat : Pet
    {
        public override void Eat() => Console.WriteLine("Кошка ест рыбу.");
    }

    class Parrot : Pet
    {
        public override void Eat() => Console.WriteLine("Попугай ест зерно.");
    }

    public static void Run()
    {
        Console.WriteLine("10. Домашние животные");
        Console.WriteLine("1 - Dog");
        Console.WriteLine("2 - Cat");
        Console.WriteLine("3 - Parrot");

        int choice = Input.ReadInt("Выберите: ");
        Pet? pet = choice switch
        {
            1 => new Dog(),
            2 => new Cat(),
            3 => new Parrot(),
            _ => null
        };

        if (pet == null)
            Console.WriteLine("Неверный выбор.");
        else
            pet.Eat();

        Input.Pause();
    }
}
