using System;

namespace CS30Nasledovanie;

public static class Zadanie14
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

        public virtual void ShowInfo()
        {
            Console.WriteLine($"Имя: {Name}");
            Console.WriteLine($"Возраст: {Age}");
        }
    }

    class Student : Person
    {
        public string University { get; set; }

        public Student(string name, int age, string university)
            : base(name, age) { University = university; }

        public override void ShowInfo()
        {
            base.ShowInfo();
            Console.WriteLine($"Университет: {University}");
        }
    }

    class GraduateStudent : Student
    {
        public string ThesisTopic { get; set; }

        public GraduateStudent(string name, int age, string university, string thesis)
            : base(name, age, university) { ThesisTopic = thesis; }

        public override void ShowInfo()
        {
            base.ShowInfo();
            Console.WriteLine($"Тема исследования: {ThesisTopic}");
        }
    }

    public static void Run()
    {
        Console.WriteLine("14. Система образования");
        string name = Input.ReadString("Имя: ");
        int age = Input.ReadInt("Возраст: ");
        string university = Input.ReadString("Университет: ");
        string thesis = Input.ReadString("Тема диплома/исследования: ");

        var student = new GraduateStudent(name, age, university, thesis);

        Console.WriteLine("\nПолная информация:");
        student.ShowInfo();

        Input.Pause();
    }
}
