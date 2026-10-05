using System;
using System.Globalization;

namespace CS30Nasledovanie;

public static class Input
{
    public static string ReadString(string prompt)
    {
        Console.Write(prompt);
        return Console.ReadLine()?.Trim() ?? "";
    }

    public static int ReadInt(string prompt)
    {
        while (true)
        {
            Console.Write(prompt);
            if (int.TryParse(Console.ReadLine(), out int value))
                return value;
            Console.WriteLine("Ошибка. Введите целое число.");
        }
    }

    public static double ReadDouble(string prompt)
    {
        while (true)
        {
            Console.Write(prompt);
            string value = Console.ReadLine()?.Trim() ?? "";
            if (double.TryParse(value, NumberStyles.Float, CultureInfo.InvariantCulture, out double result) ||
                double.TryParse(value, out result))
                return result;

            Console.WriteLine("Ошибка. Введите число.");
        }
    }

    public static decimal ReadDecimal(string prompt)
    {
        while (true)
        {
            Console.Write(prompt);
            string value = Console.ReadLine()?.Trim() ?? "";
            if (decimal.TryParse(value, NumberStyles.Number, CultureInfo.InvariantCulture, out decimal result) ||
                decimal.TryParse(value, out result))
                return result;

            Console.WriteLine("Ошибка. Введите число.");
        }
    }

    public static bool ReadBool(string prompt)
    {
        while (true)
        {
            string value = ReadString(prompt + " (1 = да, 0 = нет): ");
            if (value == "1") return true;
            if (value == "0") return false;
            Console.WriteLine("Введите 1 или 0.");
        }
    }

    public static void Pause()
    {
        Console.WriteLine("\nНажмите Enter, чтобы вернуться в главное меню...");
        Console.ReadLine();
    }
}

public static class Program
{
    public static void Main()
    {
        while (true)
        {
            Console.Clear();
            Console.WriteLine("================================================");
            Console.WriteLine("        30 ЗАДАНИЙ ПО НАСЛЕДОВАНИЮ C#");
            Console.WriteLine("================================================");

            for (int i = 1; i <= 30; i++)
                Console.WriteLine($"{i,2}. Задание {i}");

            Console.WriteLine(" 0. Выход");
            int choice = Input.ReadInt("\nВыберите задание: ");

            if (choice == 0)
                break;

            Console.Clear();

            try
            {
                switch (choice)
                {
                    case 1: Zadanie1.Run(); break;
                    case 2: Zadanie2.Run(); break;
                    case 3: Zadanie3.Run(); break;
                    case 4: Zadanie4.Run(); break;
                    case 5: Zadanie5.Run(); break;
                    case 6: Zadanie6.Run(); break;
                    case 7: Zadanie7.Run(); break;
                    case 8: Zadanie8.Run(); break;
                    case 9: Zadanie9.Run(); break;
                    case 10: Zadanie10.Run(); break;
                    case 11: Zadanie11.Run(); break;
                    case 12: Zadanie12.Run(); break;
                    case 13: Zadanie13.Run(); break;
                    case 14: Zadanie14.Run(); break;
                    case 15: Zadanie15.Run(); break;
                    case 16: Zadanie16.Run(); break;
                    case 17: Zadanie17.Run(); break;
                    case 18: Zadanie18.Run(); break;
                    case 19: Zadanie19.Run(); break;
                    case 20: Zadanie20.Run(); break;
                    case 21: Zadanie21.Run(); break;
                    case 22: Zadanie22.Run(); break;
                    case 23: Zadanie23.Run(); break;
                    case 24: Zadanie24.Run(); break;
                    case 25: Zadanie25.Run(); break;
                    case 26: Zadanie26.Run(); break;
                    case 27: Zadanie27.Run(); break;
                    case 28: Zadanie28.Run(); break;
                    case 29: Zadanie29.Run(); break;
                    case 30: Zadanie30.Run(); break;
                    default:
                        Console.WriteLine("Такого задания нет.");
                        Input.Pause();
                        break;
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine($"\nОшибка выполнения: {ex.Message}");
                Input.Pause();
            }
        }
    }
}
