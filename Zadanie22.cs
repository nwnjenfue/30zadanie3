using System;

namespace CS30Nasledovanie;

public static class Zadanie22
{
    class Product
    {
        public string Name { get; set; }
        public decimal Price { get; set; }

        public Product(string name, decimal price)
        {
            Name = name;
            Price = price;
        }

        public virtual decimal GetFinalPrice() => Price;
    }

    class Electronics : Product
    {
        public Electronics(string name, decimal price) : base(name, price) { }
        public override decimal GetFinalPrice() => Price * 1.15m;
    }

    class Clothing : Product
    {
        public Clothing(string name, decimal price) : base(name, price) { }
        public override decimal GetFinalPrice() => Price * 0.90m;
    }

    class Food : Product
    {
        public Food(string name, decimal price) : base(name, price) { }
        public override decimal GetFinalPrice() => Price * 1.05m;
    }

    public static void Run()
    {
        Console.WriteLine("22. Интернет-магазин");
        Console.WriteLine("1 - Electronics: цена + 15%");
        Console.WriteLine("2 - Clothing: скидка 10%");
        Console.WriteLine("3 - Food: цена + 5%");

        int type = Input.ReadInt("Категория: ");
        string name = Input.ReadString("Название товара: ");
        decimal price = Input.ReadDecimal("Базовая цена: ");

        Product? product = type switch
        {
            1 => new Electronics(name, price),
            2 => new Clothing(name, price),
            3 => new Food(name, price),
            _ => null
        };

        if (product == null)
        {
            Console.WriteLine("Неверная категория.");
        }
        else
        {
            Console.WriteLine($"Итоговая цена: {product.GetFinalPrice():F2}");
        }

        Input.Pause();
    }
}
