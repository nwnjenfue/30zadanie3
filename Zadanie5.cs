using System;

namespace CS30Nasledovanie;

public static class Zadanie5
{
    class Shape
    {
        public virtual double GetArea() => 0;
    }

    class Rectangle : Shape
    {
        public double Width { get; set; }
        public double Height { get; set; }

        public Rectangle(double width, double height)
        {
            Width = width;
            Height = height;
        }

        public override double GetArea() => Width * Height;
    }

    class Circle : Shape
    {
        public double Radius { get; set; }

        public Circle(double radius) => Radius = radius;

        public override double GetArea() => Math.PI * Radius * Radius;
    }

    public static void Run()
    {
        Console.WriteLine("5. Фигуры");
        Console.WriteLine("1 - Rectangle");
        Console.WriteLine("2 - Circle");
        int type = Input.ReadInt("Выберите фигуру: ");

        Shape shape;

        if (type == 1)
        {
            double width = Input.ReadDouble("Ширина: ");
            double height = Input.ReadDouble("Высота: ");
            shape = new Rectangle(width, height);
        }
        else if (type == 2)
        {
            double radius = Input.ReadDouble("Радиус: ");
            shape = new Circle(radius);
        }
        else
        {
            Console.WriteLine("Неверный выбор.");
            Input.Pause();
            return;
        }

        Console.WriteLine($"Площадь: {shape.GetArea():F2}");
        Input.Pause();
    }
}
