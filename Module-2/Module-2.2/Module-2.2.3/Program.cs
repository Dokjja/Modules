// Абстрактный класс фигур
abstract class Shape
{
    public abstract double Area(); // Метод для нахождения площади
    public abstract void Print(); // Метод для вывода информации о фигуре
}
// Класс Круг
class Circle : Shape
{
    public double Radius { get; set; } // Радиус
    
    public override double Area() => Math.PI * 2 *  Radius;   
    public override void Print() => Console.WriteLine($"Круг с радиусом {Radius} и площадью {Area():F2}");
}
// Класс Прямоугольник
class Rectangle : Shape
{
    public double Width { get; set; } // Ширина
    public double Height { get; set; } // Высота
    public override double Area() => Width * Height;
    public override void Print() => Console.WriteLine($"Прямоугольник с шириной {Width}, и высотой {Height}, и площадью {Area()}");
}

class Triangle : Shape
{
    public double Height { get; set; } // Высота
    public double Base { get; set; } // Основание
    public override double Area() => (Height * Base) / 2;
    public override void Print() =>  Console.WriteLine($"Треугольник с высотой {Height}, и основанием {Base}, площадью {Area()}");
}
class Program
{
    static void Main()
    {
        var circle = new Circle{Radius = 2};
        var rectangle = new Rectangle{Height = 2, Width = 3};
        var triangle = new Triangle{Base = 4, Height = 6};
        circle.Print();
        rectangle.Print();
        triangle.Print();
        Console.ReadKey();
    }
}