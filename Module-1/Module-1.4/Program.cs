const int size = 30;
int[] numbers = new int[size];
Random rand = new Random();
// Заполнение массива случайными значениями
for (int i = 0; i < size; i++)
    numbers[i] = rand.Next(0, 100); 
// Вывод массива
Console.WriteLine("Массив случайных чисел: " + string.Join(" ", numbers));

Array.Sort(numbers); // сортировка по возрастанию

int min = numbers[0];  // Первый элемент
int max = numbers[^1]; // Последний элемент

Console.WriteLine($"Минимум: {min}");
Console.WriteLine($"Максимум: {max}");

Console.WriteLine("Нажмите любую клавишу для выхода...");
Console.ReadKey(); 