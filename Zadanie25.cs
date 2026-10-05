using System;

namespace CS30Nasledovanie;

public static class Zadanie25
{
    class Person
    {
        public string Name { get; set; }
        public int Age { get; set; }

        public Person(string name, int age) { Name = name; Age = age; }

        public virtual void ShowInfo()
            => Console.WriteLine($"Name: {Name}, Age: {Age}");
    }

    class Employee : Person
    {
        public decimal Salary { get; set; }
        public string Department { get; set; }

        public Employee(string name, int age, decimal salary, string department)
            : base(name, age)
        {
            Salary = salary;
            Department = department;
        }

        public virtual void Work()
            => Console.WriteLine($"{Name} работает в отделе {Department}.");
    }

    class Manager : Employee
    {
        public int TeamSize { get; set; }
        public string Project { get; set; }

        public Manager(string name, int age, decimal salary, string department, int teamSize, string project)
            : base(name, age, salary, department)
        {
            TeamSize = teamSize;
            Project = project;
        }

        public override void Work()
            => Console.WriteLine($"Менеджер {Name} руководит проектом {Project}, команда: {TeamSize}.");
    }

    class Director : Manager
    {
        public string Company { get; set; }
        public decimal Budget { get; set; }

        public Director(string name, int age, decimal salary, string department,
                        int teamSize, string project, string company, decimal budget)
            : base(name, age, salary, department, teamSize, project)
        {
            Company = company;
            Budget = budget;
        }

        public void ManageCompany()
            => Console.WriteLine($"Директор {Name} управляет {Company}. Бюджет: {Budget:F2}");
    }

    public static void Run()
    {
        Console.WriteLine("25. Person -> Employee -> Manager -> Director");

        string name = Input.ReadString("Имя: ");
        int age = Input.ReadInt("Возраст: ");
        decimal salary = Input.ReadDecimal("Зарплата: ");
        string department = Input.ReadString("Отдел: ");
        int teamSize = Input.ReadInt("Размер команды: ");
        string project = Input.ReadString("Проект: ");
        string company = Input.ReadString("Компания: ");
        decimal budget = Input.ReadDecimal("Бюджет: ");

        var director = new Director(
            name, age, salary, department,
            teamSize, project, company, budget);

        Console.WriteLine("\nРезультат:");
        director.ShowInfo();
        Console.WriteLine($"Salary: {director.Salary:F2}");
        Console.WriteLine($"Department: {director.Department}");
        Console.WriteLine($"TeamSize: {director.TeamSize}");
        Console.WriteLine($"Project: {director.Project}");
        Console.WriteLine($"Company: {director.Company}");
        Console.WriteLine($"Budget: {director.Budget:F2}");
        director.Work();
        director.ManageCompany();

        Input.Pause();
    }
}
