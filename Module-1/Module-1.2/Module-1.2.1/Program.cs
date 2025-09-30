Console.Write("Введите количество элементов массива: ");
int count = Convert.ToInt32(Console.ReadLine()); // Ввод количества элементов в массива
var array =  new float[count];

for (int i = 0; i < count; i++)
{
    Console.Write($"Введите {i} элемент: ");
    array[i] = Convert.ToInt32(Console.ReadLine()); // Ввод значений массива
}
Console.Write("Массив: ");
Console.WriteLine(string.Join("    ", array)); // Вывод заполненного массива
var cpArr = new float[count];
Array.Copy(array, cpArr, count);
Array.Sort(cpArr); // Сортировка массива

var maxNum = cpArr[^1]; // Максимальный элемент

Console.WriteLine("Максимальный элемент: " + maxNum);

for (int i = 0; i < count; i++)
{
    array[i] = array[i] / maxNum;    
}
Console.Write("Нормированный массив: ");
Console.WriteLine(string.Join("   ", array));
Console.ReadKey();
