Console.Write("Введите количество элементов: ");
int K = Convert.ToInt32(Console.ReadLine());
int[] array =  new int[K];
var rand = new Random(); // Создание нового объекта класса Random
Console.Write("Введите значение A: ");
int A = Convert.ToInt32(Console.ReadLine());    
Console.Write("Введите значение B: ");
int B = Convert.ToInt32(Console.ReadLine());
// Цикл для заполнения массива
for (int i = 0; i <  K; i++)
{
    array[i] = rand.Next(A, B);
}
Console.WriteLine(string.Join(", ", array));
var minIndex = Array.IndexOf(array, array.Min()); // Индекс минимального элемента
var maxIndex = Array.IndexOf(array, array.Max()); // Индекс максимального элемента
Console.WriteLine($"Минимальное значение: {array.Min()}, его индекс: {minIndex}\n" +
                  $"Максимальное значение: {array.Max()}, его индекс: {maxIndex}");
var firstIndex = Math.Min(minIndex, maxIndex); // Первый индекс по счету
var secondIndex = Math.Max(minIndex, maxIndex); // второй индекс по счету
Console.Write("Значения в диапозоне: ");
for (int i = firstIndex; i <= secondIndex; i++)
{
    Console.Write(array[i] + " ");
}
Console.ReadKey();
