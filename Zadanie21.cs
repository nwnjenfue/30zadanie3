using System;

namespace CS30Nasledovanie;

public static class Zadanie21
{
    abstract class Shape
    {
        public abstract double GetArea();
    }

    class Circle : Shape
    {
        private double Radius { get; }
        public Circle(double radius) => Radius = radius;
        public override double GetArea() => Math.PI * Radius * Radius;
    }

    class Rectangle : Shape
    {
        private double Width { get; }
        private double Height { get; }
        public Rectangle(double width, double height) { Width = width; Height = height; }
        public override double GetArea() => Width * Height;
    }

    class Triangle : Shape
    {
        private double BaseLength { get; }
        private double Height { get; }
        public Triangle(double baseLength, double height) { BaseLength = baseLength; Height = height; }
        public override double GetArea() => BaseLength * Height / 2;
    }

    class Square : Shape
    {
        private double Side { get; }
        public Square(double side) => Side = side;
        public override double GetArea() => Side * Side;
    }

    public static void Run()
    {
        Console.WriteLine("21. Абстрактные фигуры");
        Console.WriteLine("1 - Circle");
        Console.WriteLine("2 - Rectangle");
        Console.WriteLine("3 - Triangle");
        Console.WriteLine("4 - Square");

        int type = Input.ReadInt("Выберите фигуру: ");
        Shape? shape = null;

        switch (type)
        {
            case 1:
                shape = new Circle(Input.ReadDouble("Радиус: "));
                break;
            case 2:
                shape = new Rectangle(
                    Input.ReadDouble("Ширина: "),
                    Input.ReadDouble("Высота: "));
                break;
            case 3:
                shape = new Triangle(
                    Input.ReadDouble("Основание: "),
                    Input.ReadDouble("Высота: "));
                break;
            case 4:
                shape = new Square(Input.ReadDouble("Сторона: "));
                break;
            default:
                Console.WriteLine("Неверный выбор.");
                break;
        }

        if (shape != null)
            Console.WriteLine($"Площадь: {shape.GetArea():F2}");

        Input.Pause();
    }
}
