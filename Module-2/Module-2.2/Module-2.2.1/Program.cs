class Car
{
    public string Brand {get; set;}
    public string Model { get; set; }
    public int Year { get; set; }
    public double Price { get; set; }

    public Car(string brand, string model, int year, double price)
    {
        Brand = brand;
        Model = model;
        Year = year;
        Price = price;
    }

    public double GetPriceWithDiscount(double discount)
    {
        return Price * (1 - discount / 100);
    }

    public double GetPriceWithTax(double tax)
    {
        return Price * (1 + tax / 100);
    }

    public double GetFinalPrice(double discount, double tax)
    {
        double discounted = GetPriceWithDiscount(discount);
        return discounted * (1 + tax / 100);
    }
    public void PrintInfo()
    {
        Console.WriteLine($"Автомобиль: {Brand} {Model}, {Year} г., Цена: {Price} руб.");
    }
}
class Program
{
    static void Main(string[] args)
    {
        Car car = new Car("Toyota", "Camry", 2020, 30000);

        car.PrintInfo();

        double discount = 10; // 10%
        double tax = 20;      // 20%

        Console.WriteLine($"Цена со скидкой: {car.GetPriceWithDiscount(discount)} руб.");
        Console.WriteLine($"Цена с НДС: {car.GetPriceWithTax(tax)} руб.");
        Console.WriteLine($"Итоговая цена (скидка + НДС): {car.GetFinalPrice(discount, tax)} руб.");    
        Console.ReadKey();
    }
}