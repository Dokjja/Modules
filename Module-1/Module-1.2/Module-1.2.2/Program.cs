const int count = 10;
var array = new int[count];
// Цикл для ввода значений элементов
for (int i = 0; i < count; i++)
{
    Console.Write($"Введите {i} элемент: ");
    array[i] = Convert.ToInt32(Console.ReadLine()); // Ввод значения элемента массива
}
Console.Write("Введите число для замены: ");
var number = Convert.ToInt32(Console.ReadLine()); // Ввод числа для замены
var maxIndex = Array.IndexOf(array, array.Max()); // Поиск индекса максимального элемента
array[maxIndex] = number; // Замена числа

Console.WriteLine("Массив с замененным числом: " + string.Join(", ", array)); // Вывод массива
Console.ReadKey();



