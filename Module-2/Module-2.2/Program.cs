using System;

class Shape
{
    public virtual double Area() => 0;
    public virtual double Perimeter() => 0;
    public void Print() => Console.WriteLine($"Площадь: {Area()}, Периметр: {Perimeter()}");
}

class Circle(double radius): Shape
{
    public double Radius { get; set; } =  radius;
    public override double Area() => Math.PI * Math.Pow(Radius, 2);
    public override double Perimeter() => Math.PI * Radius * 2;
}

class Rectangle(double width, double height) : Shape
{
    public double Width { get; set; } = width;
    public double Height { get; set; } = height;
    public override double Area() => Width * Height;
    public override double Perimeter() => (2 * Width) + (2 * Height);
}
class Program
{
    static void Main(string[] args)
    {
        Console.Write("Введите радиус для круга: ");
        double radius = double.Parse(Console.ReadLine()!);
        var circle = new Circle(radius);
        circle.Print();
        Console.Write("Введите ширину прямоугольника: ");
        var width = double.Parse(Console.ReadLine()!);
        Console.Write("Введите высоту прямоугольника: ");
        var height = double.Parse(Console.ReadLine()!);
        var rectangle = new Rectangle(width, height);
        rectangle.Print();
        Console.ReadKey();
    }
}