const int size = 10;
var array = new float[size];
var indices = new int[size];
var rand = new Random();
// Цикл для заполнения случацными вещественными значениями
for (int i = 0; i < size; i++)
{
    array[i] = (float)rand.NextDouble() * 20 - 10; // [0,1) > [0,20) > [-10,10)
    indices[i] = i; // Начальная нумераия
}
// Цикл сортировки индексов по значениям массива
for (int i = 0; i < size - 1; i++)
{
    for (int j = i + 1; j < size; j++)
    {
        if (array[indices[i]] > array[indices[j]])
        {
            (indices[i], indices[j]) = (indices[j], indices[i]);
        }
    }
}
Console.WriteLine("Исходный массив: " + string.Join(" ", array.Select(n => n.ToString("F2"))));
Console.WriteLine("Массив индексов по возрастанию значений: " + string.Join(' ', indices));
Console.ReadKey();