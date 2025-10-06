interface IShape
{
    void Area();
    void Perimeter();
}

class Circle : IShape
{
    public double Radius { get; set; }
    public void Area() => Console.WriteLine($"Площадь круга с радиусом {Radius}: {Math.PI * Math.Pow(Radius, 2):F2}");
    public void Perimeter() => Console.WriteLine($"Периметр круга с радиусом {Radius}: {Math.PI * 2 * Radius:F2}");
}

class Rectangle : IShape
{
    public double Width { get; set; }
    public double Height { get; set; }
    public void Area() => Console.WriteLine($"Площадь прямоугольника с шириной {Width} и высотой {Height}: {Width * Height}");
    public void Perimeter() => Console.WriteLine($"Периметр прямоугольника с шириной {Width} и высотой {Height}: {(Width * 2) +  (Height * 2)}");
}

class Triangle : IShape
{
    public double SideA { get; set; }
    public double SideB { get; set; }
    public double SideC { get; set; }

    private double P => (SideA + SideB + SideC) / 2; // Полупериметр
    public void Area() => Console.WriteLine($"Площадь треугольника со сторонами {SideA}, {SideB}, {SideC}: {Math.Sqrt(P * (P - SideA) * (P - SideB) * (P - SideC))}");
    public void Perimeter() => Console.WriteLine($"Периметр треугольника со сторонами {SideA}, {SideB}, {SideC}: {SideA + SideB + SideC}");
}

class Program
{
    static void Main(string[] args)
    {
        var circle = new Circle{Radius = 2};
        var rectangle = new Rectangle {Width = 5, Height = 4};
        var triangle = new Triangle {SideA = 5, SideB = 3, SideC = 4};
        circle.Area();
        circle.Perimeter();
        rectangle.Area();
        rectangle.Perimeter();
        triangle.Area();
        triangle.Perimeter();
        Console.ReadKey();
    }
}