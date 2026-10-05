using System;
using System.Collections.Generic;

namespace CS30Nasledovanie;

public static class Zadanie28
{
    abstract class Employee
    {
        public string Name { get; set; }

        protected Employee(string name) => Name = name;

        public abstract decimal CalculateSalary();
    }

    class HourlyEmployee : Employee
    {
        public decimal HourRate { get; set; }
        public int Hours { get; set; }

        public HourlyEmployee(string name, decimal rate, int hours)
            : base(name)
        {
            HourRate = rate;
            Hours = hours;
        }

        public override decimal CalculateSalary() => HourRate * Hours;
    }

    class SalariedEmployee : Employee
    {
        public decimal MonthlySalary { get; set; }

        public SalariedEmployee(string name, decimal salary)
            : base(name)
        {
            MonthlySalary = salary;
        }

        public override decimal CalculateSalary() => MonthlySalary;
    }

    class CommissionEmployee : Employee
    {
        public decimal BaseSalary { get; set; }
        public decimal Sales { get; set; }
        public decimal CommissionRate { get; set; }

        public CommissionEmployee(string name, decimal baseSalary, decimal sales, decimal rate)
            : base(name)
        {
            BaseSalary = baseSalary;
            Sales = sales;
            CommissionRate = rate;
        }

        public override decimal CalculateSalary()
            => BaseSalary + Sales * CommissionRate;
    }

    public static void Run()
    {
        Console.WriteLine("28. Система оплаты зарплаты");

        int count = Input.ReadInt("Количество сотрудников: ");
        if (count < 1)
        {
            Console.WriteLine("Количество должно быть больше 0.");
            Input.Pause();
            return;
        }

        List<Employee> employees = new();
        decimal total = 0;

        for (int i = 1; i <= count; i++)
        {
            Console.WriteLine($"\nСотрудник #{i}");
            Console.WriteLine("1 - HourlyEmployee");
            Console.WriteLine("2 - SalariedEmployee");
            Console.WriteLine("3 - CommissionEmployee");

            int type = Input.ReadInt("Тип: ");
            string name = Input.ReadString("Имя: ");

            Employee? employee = null;

            if (type == 1)
            {
                decimal rate = Input.ReadDecimal("Ставка за час: ");
                int hours = Input.ReadInt("Количество часов: ");
                employee = new HourlyEmployee(name, rate, hours);
            }
            else if (type == 2)
            {
                decimal salary = Input.ReadDecimal("Месячная зарплата: ");
                employee = new SalariedEmployee(name, salary);
            }
            else if (type == 3)
            {
                decimal baseSalary = Input.ReadDecimal("Базовая зарплата: ");
                decimal sales = Input.ReadDecimal("Сумма продаж: ");
                decimal rate = Input.ReadDecimal("Комиссия в процентах: ");
                employee = new CommissionEmployee(
                    name, baseSalary, sales, rate / 100m);
            }

            if (employee == null)
            {
                Console.WriteLine("Неверный тип. Сотрудник пропущен.");
                continue;
            }

            decimal salaryResult = employee.CalculateSalary();
            total += salaryResult;
            employees.Add(employee);

            Console.WriteLine($"Зарплата: {salaryResult:F2}");
        }

        Console.WriteLine($"\nОбщий фонд зарплаты: {total:F2}");
        Input.Pause();
    }
}
