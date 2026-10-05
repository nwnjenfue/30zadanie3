using System;

namespace CS30Nasledovanie;

public static class Zadanie13
{
    class Employee
    {
        public string Name { get; set; }
        public decimal BaseSalary { get; set; }

        public Employee(string name, decimal baseSalary)
        {
            Name = name;
            BaseSalary = baseSalary;
        }

        public virtual decimal GetSalary() => BaseSalary;
    }

    class Programmer : Employee
    {
        public int Projects { get; set; }

        public Programmer(string name, decimal baseSalary, int projects)
            : base(name, baseSalary) { Projects = projects; }

        public override decimal GetSalary() => BaseSalary + Projects * 50000;
    }

    class Designer : Employee
    {
        public int Designs { get; set; }

        public Designer(string name, decimal baseSalary, int designs)
            : base(name, baseSalary) { Designs = designs; }

        public override decimal GetSalary() => BaseSalary + Designs * 30000;
    }

    class Manager : Employee
    {
        public int TeamSize { get; set; }

        public Manager(string name, decimal baseSalary, int teamSize)
            : base(name, baseSalary) { TeamSize = teamSize; }

        public override decimal GetSalary() => BaseSalary + TeamSize * 20000;
    }

    public static void Run()
    {
        Console.WriteLine("13. Работники компании");
        Console.WriteLine("1 - Programmer");
        Console.WriteLine("2 - Designer");
        Console.WriteLine("3 - Manager");

        int type = Input.ReadInt("Тип: ");
        string name = Input.ReadString("Имя: ");
        decimal salary = Input.ReadDecimal("Базовая зарплата: ");

        Employee? employee = null;

        if (type == 1)
        {
            int projects = Input.ReadInt("Количество проектов: ");
            employee = new Programmer(name, salary, projects);
        }
        else if (type == 2)
        {
            int designs = Input.ReadInt("Количество дизайнов: ");
            employee = new Designer(name, salary, designs);
        }
        else if (type == 3)
        {
            int team = Input.ReadInt("Размер команды: ");
            employee = new Manager(name, salary, team);
        }

        if (employee == null)
        {
            Console.WriteLine("Неверный тип.");
        }
        else
        {
            Console.WriteLine($"Итоговая зарплата: {employee.GetSalary():F2}");
        }

        Input.Pause();
    }
}
