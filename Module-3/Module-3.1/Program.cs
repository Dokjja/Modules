public delegate double AreaDelegate();
abstract class Shape
{
    public abstract double Area();
}

class Circle(double radius) : Shape
{
    public double Radius { get; set; } = radius;
    public override double Area() => Math.PI * 2 * Radius;
}

class Rectangle(double width, double height) : Shape
{
    public double Width { get; set; } = width;
    public double Height { get; set; } = height;
    public override double Area() => Width * Height;
}

class Triangle(double height, double @base) : Shape
{
    public double Height { get; set; } = height;
    public double Base { get; set; } = @base;
    public override double Area() => (Height * Base) / 2;
}

class Program
{
    static void Main(string[] args)
    {
        var circle = new Circle(5);
        var rectangle = new Rectangle(10, 20);
        var triangle = new Triangle(10, 20);
        Shape area;
        AreaDelegate areaCircle = circle.Area;
        AreaDelegate areaRectangle = rectangle.Area;
        AreaDelegate areaTriangle = triangle.Area;
        Console.WriteLine($"Площадь круга с радиусом {circle.Radius}: {areaCircle():F2}");
        Console.WriteLine($"Площадь прямоугольника с шириной {rectangle.Width} и высотой {rectangle.Height}: {areaRectangle():F2}");
        Console.WriteLine($"Площадь треугольника с высотой {triangle.Height} и основанием {triangle.Base}: {areaTriangle():F2}");

        Console.ReadKey();
    }
}