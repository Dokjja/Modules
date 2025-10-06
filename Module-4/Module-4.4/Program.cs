interface IBook
{
    string Name { get; set; }
    string Author { get; set; }
    int Year { get; set; }
    int Quantity { get; set; }
    double Price { get; set; }
    bool IsAvailable();
    void GetBook();
}

class Neverwhere : IBook
{
    public string Name { get; set; } = "Никогде";
    public string Author { get; set; } = "Нил Гейман";
    public int Year { get; set; } = 1996;
    public int Quantity { get; set; } = 20;
    public double Price { get; set; } = 19.99;

    public bool IsAvailable()
    {
         bool isAvailable = (this.Quantity > 0) ? true : false;
         Console.WriteLine(isAvailable == true ? $"Книга '{Name}' доступна" : $"Книги '{Name}' нет в наличии");
         return isAvailable;
    }

    public void GetBook()
    {
        if (this.Quantity > 0)
        {
            this.Quantity--;
            Console.WriteLine($"Книга '{Name}' выдана! Остаток: " + this.Quantity);
            
        }
        else
        {
            Console.WriteLine($"Книги '{Name}' нет в наличии");
        } 
    }
}

class NorwegianWoods : IBook
{
    public string Name { get; set; } = "Норвежский лес";
    public string Author { get; set; } = "Харуки Мураками";
    public int Year { get; set; } = 2023;
    public int Quantity { get; set; } = 1;
    public double Price { get; set; } = 22.27;

    public bool IsAvailable()
    {
        bool isAvailable = (this.Quantity > 0) ? true : false;
        Console.WriteLine(isAvailable ? $"Книга '{Name}' доступна" : $"Книги '{Name}' нет в наличии");
        return isAvailable;    
    }

    public void GetBook()
    {
        if (this.Quantity > 0)
        {
            this.Quantity--;
            Console.WriteLine($"Книга '{Name}' выдана! Остаток: " + this.Quantity);
        }
        else
        {
            Console.WriteLine($"Книги '{Name}' нет в наличии");
        } 
    }
}

class Program
{
    static void Main(string[] args)
    {
        var library = new IBook[]
        {
            new Neverwhere(),
            new NorwegianWoods(),
        };
        foreach (var book in library)
        {
            book.IsAvailable();
            book.GetBook(); 
            book.GetBook();
            Console.WriteLine();
        }
        Console.ReadKey();
    }
}