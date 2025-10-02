// Интерфейс
interface IDrawable
{
    // Метод по умолчанию
    void Draw() => Console.WriteLine("Это фигура");
}

class Circle(float radius): IDrawable
{
    public void Draw() => Console.WriteLine($"Это круг с радиусом {radius}");
}

class Rectangle(float width, float height) : IDrawable
{
    public void Draw()  => Console.WriteLine($"Это квадрат с высотой {height} и шириной {width}");
}

class Triangle(float sideA, float sideB, float sideC) : IDrawable
{
    public void Draw() => Console.WriteLine($"Это треугольник со сторонами {sideA}, {sideB}, {sideC}");
}
class Program
{
    static void Main(string[] args)
    {
        // Массив фигур
        var shapes = new IDrawable[]
        {
            new Circle(10),
            new Rectangle(10, 20),
            new Triangle(15, 20, 25)
        };
        foreach (var shape in shapes)
        {
            shape.Draw(); // Вызов метода для предоставления информации о фигуре
        }
        Console.ReadKey(); // Чтобы консоль не закрылась
    }
}