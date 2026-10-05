using System;

namespace CS30Nasledovanie;

public static class Zadanie24
{
    class MedicalWorker
    {
        public string Name { get; set; }

        public MedicalWorker(string name) => Name = name;

        public virtual void Work() => Console.WriteLine($"{Name} работает в больнице.");
    }

    class Doctor : MedicalWorker
    {
        public Doctor(string name) : base(name) { }
        public override void Work() => Console.WriteLine($"Доктор {Name}: осматривает пациента и ставит диагноз.");
    }

    class Nurse : MedicalWorker
    {
        public Nurse(string name) : base(name) { }
        public override void Work() => Console.WriteLine($"Медсестра {Name}: выполняет уход и процедуры.");
    }

    class Surgeon : MedicalWorker
    {
        public Surgeon(string name) : base(name) { }
        public override void Work() => Console.WriteLine($"Хирург {Name}: проводит операцию.");
    }

    public static void Run()
    {
        Console.WriteLine("24. Больница");
        Console.WriteLine("1 - Doctor");
        Console.WriteLine("2 - Nurse");
        Console.WriteLine("3 - Surgeon");

        int type = Input.ReadInt("Тип работника: ");
        string name = Input.ReadString("Имя: ");

        MedicalWorker? worker = type switch
        {
            1 => new Doctor(name),
            2 => new Nurse(name),
            3 => new Surgeon(name),
            _ => null
        };

        if (worker == null)
            Console.WriteLine("Неверный тип.");
        else
            worker.Work();

        Input.Pause();
    }
}
