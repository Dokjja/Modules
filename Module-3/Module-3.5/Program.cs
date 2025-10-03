public delegate void SortMethod(int[] array);
// Класс с сортировками
class SortAlgorithms
{
    // Пузырьковая сортировка
    public void BubbleSort(int[] array)
    {
        for (int i = 0; i < array.Length - 1; i++)
        {
            for (int j = 0; j < array.Length - 1 - i; j++)
            {
                if (array[j] > array[j + 1])
                    (array[j], array[j + 1]) = (array[j + 1], array[j]);
            }
        }
    }

    // Быстрая сортировка
    public void QuickSort(int[] array) => QuickSortRecursive(array, 0, array.Length - 1);

    private void QuickSortRecursive(int[] array, int left, int right)
    {
        if (left >= right) return;

        int middle = array[(left + right) / 2];
        int index = Partition(array, left, right, middle);
        QuickSortRecursive(array, left, index - 1);
        QuickSortRecursive(array, index, right);
    }

    // Для разделения на лево и право
    private int Partition(int[] array, int left, int right, int middle)
    {
        //  Пока левый указатель не пересёк правый 
        while (left <= right)
        {
            // Левый указатель двигается вправо, пока элемент меньше опорного (среднего)
            while (array[left] < middle) left++;
            // Правый указатель двигается влево, пока элемент больше опорного (среднего)
            while (array[right] > middle) right--;
            // Если левый указатель меньше или равен правому - элемент с левой части меняется с элементов в правой части
            if (left <= right)
            {
                (array[left], array[right]) = (array[right], array[left]);
                left++;
                right--;
            }
        }
        return left;
    }
}

class Program
{
    static void Main(string[] args)
    {
        // Создание объекта класса
        var sorter = new SortAlgorithms();
        // Ввод значений
        Console.WriteLine("Введите числа через пробел:");
        string input = Console.ReadLine()!;
        // Разделяет строку на элементы массива по пробелам, удаляя лишние пропуски
        string[] parts = input.Split(' ', StringSplitOptions.RemoveEmptyEntries);
        // Преобразовывает массив строк в массив целых чисел
        int[] numbers = Array.ConvertAll(parts, int.Parse); // ConvertAll применяет int.Parse ко всем элементам

        

       
        SortMethod? method = null; // Создание переменной делегата
        var exit = false;
        while (!exit)
        {
            Console.WriteLine("Выберите метод сортировки:");
            Console.WriteLine("1 — Сортировка пузырьком");
            Console.WriteLine("2 — Быстрая сортировка");
            string choice = Console.ReadLine()!;
            switch (choice)
            {
                case "1":
                    method = sorter.BubbleSort; // Присваивание делегату ссылки на метод BubbleSort
                    method?.Invoke(numbers); // Вызов сортировки (если не null)
                    Console.WriteLine("Отсортированные данные:");
                    Console.WriteLine(string.Join(" ", numbers));
                    break;
                case "2":
                    method = sorter.QuickSort; // Присваивание делегату ссылки на метод QuickSort
                    method?.Invoke(numbers); // Вызов сортировки (если не null)
                    Console.WriteLine("Отсортированные данные:");
                    Console.WriteLine(string.Join(" ", numbers));
                    break;
                default:
                    Console.WriteLine("Неверный выбор. Используется пузырьковая сортировка.");
                    method = sorter.BubbleSort; // Присваивание делегату ссылки на метод BubbleSort
                    method?.Invoke(numbers); // Вызов сортировки (если не null)
                    Console.WriteLine("Отсортированные данные:");
                    Console.WriteLine(string.Join(" ", numbers));
                    exit = true;
                    break;
            }    
        }
        Console.ReadKey();
    }    
    
}