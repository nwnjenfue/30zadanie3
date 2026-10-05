using System;

namespace CS30Nasledovanie;

public static class Zadanie4
{
    class Employee
    {
        public string Name { get; set; }
        public decimal Salary { get; set; }

        public Employee(string name, decimal salary)
        {
            Name = name;
            Salary = salary;
        }
    }

    class Manager : Employee
    {
        public int TeamSize { get; set; }

        public Manager(string name, decimal salary, int teamSize)
            : base(name, salary) { TeamSize = teamSize; }
    }

    class Developer : Employee
    {
        public string ProgrammingLanguage { get; set; }

        public Developer(string name, decimal salary, string language)
            : base(name, salary) { ProgrammingLanguage = language; }
    }

    public static void Run()
    {
        Console.WriteLine("4. Сотрудники");
        Console.WriteLine("1 - Manager");
        Console.WriteLine("2 - Developer");
        int type = Input.ReadInt("Тип сотрудника: ");

        string name = Input.ReadString("Имя: ");
        decimal salary = Input.ReadDecimal("Зарплата: ");

        if (type == 1)
        {
            int team = Input.ReadInt("Количество сотрудников в команде: ");
            var manager = new Manager(name, salary, team);
            Console.WriteLine($"\n{manager.Name}, зарплата: {manager.Salary:F2}, команда: {manager.TeamSize}");
        }
        else if (type == 2)
        {
            string language = Input.ReadString("Язык программирования: ");
            var developer = new Developer(name, salary, language);
            Console.WriteLine($"\n{developer.Name}, зарплата: {developer.Salary:F2}, язык: {developer.ProgrammingLanguage}");
        }
        else
        {
            Console.WriteLine("Неверный тип.");
        }

        Input.Pause();
    }
}
