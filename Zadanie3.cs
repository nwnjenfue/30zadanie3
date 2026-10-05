using System;

namespace CS30Nasledovanie;

public static class Zadanie3
{
    class Person
    {
        public string Name { get; set; }
        public int Age { get; set; }

        public Person(string name, int age)
        {
            Name = name;
            Age = age;
        }
    }

    class Student : Person
    {
        public string Specialty { get; set; }
        public int Course { get; set; }

        public Student(string name, int age, string specialty, int course)
            : base(name, age)
        {
            Specialty = specialty;
            Course = course;
        }
    }

    public static void Run()
    {
        Console.WriteLine("3. Человек и студент");
        string name = Input.ReadString("Имя: ");
        int age = Input.ReadInt("Возраст: ");
        string specialty = Input.ReadString("Специальность: ");
        int course = Input.ReadInt("Курс: ");

        var student = new Student(name, age, specialty, course);

        Console.WriteLine("\nИнформация:");
        Console.WriteLine($"Имя: {student.Name}");
        Console.WriteLine($"Возраст: {student.Age}");
        Console.WriteLine($"Специальность: {student.Specialty}");
        Console.WriteLine($"Курс: {student.Course}");

        Input.Pause();
    }
}
