Console.Write("Введите число: ");
int a = Convert.ToInt32(Console.ReadLine());

if (a % 2 == 0)
{
    Console.WriteLine($"{a} - четное");
}
else
{
    Console.WriteLine($"{a} - нечетное");
}
Console.WriteLine("Нажмите любую клавишу для выхода...");
Console.ReadKey(); 
