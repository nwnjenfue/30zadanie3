using System;

namespace CS30Nasledovanie;

public static class Zadanie9
{
    class Book
    {
        public string Title { get; set; }
        public string Author { get; set; }

        public Book(string title, string author)
        {
            Title = title;
            Author = author;
        }
    }

    class PaperBook : Book
    {
        public int Pages { get; set; }

        public PaperBook(string title, string author, int pages)
            : base(title, author) { Pages = pages; }
    }

    class EBook : Book
    {
        public double FileSizeMb { get; set; }

        public EBook(string title, string author, double fileSizeMb)
            : base(title, author) { FileSizeMb = fileSizeMb; }
    }

    public static void Run()
    {
        Console.WriteLine("9. Книги");
        Console.WriteLine("1 - PaperBook");
        Console.WriteLine("2 - EBook");

        int type = Input.ReadInt("Тип: ");
        string title = Input.ReadString("Название: ");
        string author = Input.ReadString("Автор: ");

        if (type == 1)
        {
            int pages = Input.ReadInt("Количество страниц: ");
            var book = new PaperBook(title, author, pages);
            Console.WriteLine($"{book.Title} — {book.Author}, {book.Pages} страниц");
        }
        else if (type == 2)
        {
            double size = Input.ReadDouble("Размер файла (MB): ");
            var book = new EBook(title, author, size);
            Console.WriteLine($"{book.Title} — {book.Author}, {book.FileSizeMb:F2} MB");
        }
        else
        {
            Console.WriteLine("Неверный тип.");
        }

        Input.Pause();
    }
}
