interface IDrawing
{
    void DrawLine(int x1, int y1, int x2, int y2);
    void DrawRectangle(int x1, int y1, int x2, int y2);
    void DrawCircle(int centerX, int centerY, int radius);
}
class Draw : IDrawing
{
    public void DrawLine(int x1, int y1, int x2, int y2)
    {
        Console.WriteLine($"Нарисована линия из точки ({x1};{y1}) в точку ({x2};{y2})");    
    }

    public void DrawRectangle(int x1, int y1, int x2, int y2)
    {
        Console.WriteLine($"Нарисован прямоугольник из точки ({x1};{y1}) в точку ({x2};{y2})");    
    }

    public void DrawCircle(int centerX, int centerY, int radius)
    {
        Console.WriteLine($"Нарисован круг с центром в точке ({centerX};{centerY}) и радиусом {radius}");    
    }
    public bool TryParseCoords(string input, int expectedCount, out int[] result)
    {
        var parts = input.Split(' ', StringSplitOptions.RemoveEmptyEntries);
        result = new int[expectedCount];

        if (parts.Length < expectedCount) return false;

        for (int i = 0; i < expectedCount; i++)
        {
            if (!int.TryParse(parts[i], out result[i]))
                return false;
        }

        return true;
    }
}
class Program
{
    static void Main(string[] args)
    {
        var draw = new Draw();
        var exit = false;
        while (!exit)
        {
            Console.WriteLine($"1 - Нарисовать линию \n" +
                              $"2 - Нарисовать прямоугольник \n" +
                              $"3 - Нарисовать круг \n" +
                              $"4 - Выход");    
            var input = Console.ReadLine()!.Trim();
            Console.WriteLine();
            string[] coords;
            switch (input)
            {
                case "1":
                    Console.Write("Введите x1 y1 x2 y2: ");
                    if (draw.TryParseCoords(Console.ReadLine()!, 4, out int[] line))
                        draw.DrawLine(line[0], line[1], line[2], line[3]);
                    else
                        Console.WriteLine("Ошибка: нужно 4 целых числа.");
                    break;

                case "2":
                    Console.Write("Введите x1 y1 x2 y2: ");
                    if (draw.TryParseCoords(Console.ReadLine()!, 4, out int[] rect))
                        draw.DrawRectangle(rect[0], rect[1], rect[2], rect[3]);
                    else
                        Console.WriteLine("Ошибка: нужно 4 целых числа.");
                    break;

                case "3":
                    Console.Write("Введите centerX centerY radius: ");
                    if (draw.TryParseCoords(Console.ReadLine()!, 3, out int[] circle))
                        draw.DrawCircle(circle[0], circle[1], circle[2]);
                    else
                        Console.WriteLine("Ошибка: нужно 3 целых числа.");
                    break;

                case "4":
                    exit = true;
                    break;
            }
            Console.WriteLine();
        }
    }
}