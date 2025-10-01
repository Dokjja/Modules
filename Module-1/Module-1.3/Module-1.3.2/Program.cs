using System;

class Program
{
    static void Main()
    {
        Console.Write("Введите значение максимальной суммы: ");
        int maxSum = Convert.ToInt32(Console.ReadLine());
        int sum = 0;
        var array = new int[1];
        var temp = new int[maxSum];
        var count = 0;
        var rand = new Random();
        while (sum < maxSum)
        {
            int value = rand.Next(1, 10);
            if (sum + value > maxSum) break;
            temp[count++] = value;
            sum += value;
        }
        // Создание итогового массива нужной длины
        var result = new int[count];
        Array.Copy(temp, result, count);    
        
        Console.WriteLine("Сформированный массив: " + string.Join(" ", result) + "\nСумма элементов: " + sum);
        Console.ReadKey();
    }
}