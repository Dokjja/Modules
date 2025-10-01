using System;

class Program
{
    static int NOD(int a, int b)
    {
        // Алгоритм Евклида
        while (a != 0 && b != 0)
        {
            if (a > b)
                a %= b;
                
            else b %= a;
        }
        return a + b;
    }
    static void Main(string[] args)
    {
        Console.Write("Введите неотрицательный числитель: ");
        int a = int.Parse(Console.ReadLine()!);
        Console.Write("Введите положительный знаменатель: ");
        int b = int.Parse(Console.ReadLine()!);
        
        int nod = NOD(a, b);
        Console.WriteLine("Наибольший общий делитель: " + nod);
        Console.WriteLine($"Сокращенная дробь: {a/nod} / {b/nod}");
        Console.ReadKey();
    }
}