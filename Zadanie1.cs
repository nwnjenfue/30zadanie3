using System;

namespace CS30Nasledovanie;

public static class Zadanie1
{
    class Animal
    {
        public virtual void Speak() => Console.WriteLine("Животное издаёт звук.");
    }

    class Dog : Animal
    {
        public override void Speak() => Console.WriteLine("Собака: Гав-гав!");
    }

    class Cat : Animal
    {
        public override void Speak() => Console.WriteLine("Кошка: Мяу!");
    }

    public static void Run()
    {
        Console.WriteLine("1. Животное");
        Console.WriteLine("Выберите животное: 1 - Dog, 2 - Cat");
        int choice = Input.ReadInt("Ваш выбор: ");

        Animal animal = choice == 1 ? new Dog() :
                         choice == 2 ? new Cat() :
                         null!;

        if (animal == null)
        {
            Console.WriteLine("Неверный выбор.");
        }
        else
        {
            animal.Speak();
        }

        Input.Pause();
    }
}
