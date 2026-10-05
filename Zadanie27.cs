using System;

namespace CS30Nasledovanie;

public static class Zadanie27
{
    class FileBase
    {
        public string Name { get; set; }
        public double SizeMb { get; set; }

        public FileBase(string name, double sizeMb)
        {
            Name = name;
            SizeMb = sizeMb;
        }

        public virtual void Open()
            => Console.WriteLine($"Файл {Name}, размер {SizeMb:F2} MB.");
    }

    class TextFile : FileBase
    {
        public TextFile(string name, double size) : base(name, size) { }
        public override void Open()
            => Console.WriteLine($"Текстовый файл {Name} открыт в текстовом редакторе.");
    }

    class ImageFile : FileBase
    {
        public ImageFile(string name, double size) : base(name, size) { }
        public override void Open()
            => Console.WriteLine($"Изображение {Name} открыто в просмотрщике.");
    }

    class VideoFile : FileBase
    {
        public VideoFile(string name, double size) : base(name, size) { }
        public override void Open()
            => Console.WriteLine($"Видео {Name} открыто в видеоплеере.");
    }

    public static void Run()
    {
        Console.WriteLine("27. Файлы");
        Console.WriteLine("1 - TextFile");
        Console.WriteLine("2 - ImageFile");
        Console.WriteLine("3 - VideoFile");

        int type = Input.ReadInt("Тип файла: ");
        string name = Input.ReadString("Название файла: ");
        double size = Input.ReadDouble("Размер (MB): ");

        FileBase? file = type switch
        {
            1 => new TextFile(name, size),
            2 => new ImageFile(name, size),
            3 => new VideoFile(name, size),
            _ => null
        };

        if (file == null)
            Console.WriteLine("Неверный тип.");
        else
            file.Open();

        Input.Pause();
    }
}
