interface IProduct
{
    public string Name { get; set; }
    public int Quantity { get; set; }
    public double Price { get; set; }
    void ShowStock();
    public void GetPrice();
}

class Water : IProduct
{
    public string Name { get; set; } = "Вода";
    public int Quantity { get; set; }
    public double Price { get; set; }
    public void ShowStock() => Console.WriteLine($"{Name} - {Quantity} шт., {Price} р.");
    public void GetPrice() => Console.WriteLine($"Цена всего товара '{Name}' на складе: {Price * Quantity} р.");
}

class Eggs : IProduct
{
    public string Name { get; set; } = "Яйца";
    public int Quantity { get; set; }
    public double Price { get; set; }
    public void ShowStock() => Console.WriteLine($"{Name} - {Quantity} шт., {Price} р.");
    public void GetPrice() => Console.WriteLine($"Цена всего товара '{Name}' на складе: {Price * Quantity} р.");
}

class Program
{
    static void Main(string[] args)
    {
        var water = new Water{Quantity = 1000, Price = 9.79};
        var eggs = new Eggs{Quantity = 100, Price = 120.79};
        water.ShowStock();
        water.GetPrice();
        eggs.ShowStock();
        eggs.GetPrice();
        Console.ReadKey();
    }
}