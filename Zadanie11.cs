using System;

namespace CS30Nasledovanie;

public static class Zadanie11
{
    class BankAccount
    {
        public decimal Balance { get; protected set; }

        public BankAccount(decimal balance)
        {
            Balance = Math.Max(0, balance);
        }

        public virtual void Deposit(decimal amount)
        {
            if (amount > 0) Balance += amount;
        }

        public virtual bool Withdraw(decimal amount)
        {
            if (amount > 0 && amount <= Balance)
            {
                Balance -= amount;
                return true;
            }

            return false;
        }
    }

    class SavingsAccount : BankAccount
    {
        public decimal InterestRate { get; set; }

        public SavingsAccount(decimal balance, decimal interestRate)
            : base(balance)
        {
            InterestRate = interestRate;
        }

        public void AddInterest()
        {
            Balance += Balance * InterestRate / 100;
        }
    }

    class CreditAccount : BankAccount
    {
        public decimal CreditLimit { get; set; }

        public CreditAccount(decimal balance, decimal creditLimit)
            : base(balance)
        {
            CreditLimit = creditLimit;
        }

        public override bool Withdraw(decimal amount)
        {
            if (amount > 0 && amount <= Balance + CreditLimit)
            {
                Balance -= amount;
                return true;
            }

            return false;
        }
    }

    public static void Run()
    {
        Console.WriteLine("11. Банковские счета");
        Console.WriteLine("1 - SavingsAccount");
        Console.WriteLine("2 - CreditAccount");

        int type = Input.ReadInt("Тип счёта: ");
        decimal balance = Input.ReadDecimal("Начальный баланс: ");

        if (type == 1)
        {
            decimal rate = Input.ReadDecimal("Процент годовых: ");
            decimal deposit = Input.ReadDecimal("Сумма пополнения: ");
            var account = new SavingsAccount(balance, rate);
            account.Deposit(deposit);
            account.AddInterest();

            Console.WriteLine($"Итоговый баланс после процентов: {account.Balance:F2}");
        }
        else if (type == 2)
        {
            decimal limit = Input.ReadDecimal("Кредитный лимит: ");
            decimal withdrawal = Input.ReadDecimal("Сумма снятия: ");
            var account = new CreditAccount(balance, limit);

            if (account.Withdraw(withdrawal))
                Console.WriteLine($"Операция выполнена. Баланс: {account.Balance:F2}");
            else
                Console.WriteLine("Операция отклонена.");
        }
        else
        {
            Console.WriteLine("Неверный тип.");
        }

        Input.Pause();
    }
}
