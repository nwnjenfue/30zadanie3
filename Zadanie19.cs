using System;

namespace CS30Nasledovanie;

public static class Zadanie19
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

        public virtual decimal GetBonus() => 0;
    }

    class Manager : Employee
    {
        public Manager(string n, decimal s) : base(n, s) { }
        public override decimal GetBonus() => Salary * 0.20m;
    }

    class Developer : Employee
    {
        public Developer(string n, decimal s) : base(n, s) { }
        public override decimal GetBonus() => Salary * 0.15m;
    }

    class SalesManager : Employee
    {
        public SalesManager(string n, decimal s) : base(n, s) { }
        public override decimal GetBonus() => Salary * 0.10m;
    }

    public static void Run()
    {
        Console.WriteLine("19. Сотрудники с бонусами");
        Console.WriteLine("1 - Manager (20%)");
        Console.WriteLine("2 - Developer (15%)");
        Console.WriteLine("3 - SalesManager (10%)");

        int type = Input.ReadInt("Тип: ");
        string name = Input.ReadString("Имя: ");
        decimal salary = Input.ReadDecimal("Зарплата: ");

        Employee? employee = type switch
        {
            1 => new Manager(name, salary),
            2 => new Developer(name, salary),
            3 => new SalesManager(name, salary),
            _ => null
        };

        if (employee == null)
        {
            Console.WriteLine("Неверный тип.");
        }
        else
        {
            decimal bonus = employee.GetBonus();
            Console.WriteLine($"Бонус: {bonus:F2}");
            Console.WriteLine($"Зарплата + бонус: {employee.Salary + bonus:F2}");
        }

        Input.Pause();
    }
}
