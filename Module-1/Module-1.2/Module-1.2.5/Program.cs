Console.Write("Введите количество элементов массива: ");
var K = Convert.ToInt32(Console.ReadLine());

char[] alphabet = "АБВГДЕЁЖЗИЙКЛМНОПРСТУФХЦЧШЩЪЫЬЭЮЯ".ToCharArray(); // Массив всех букв
char[] vowels = "АЕЁИОУЫЭЮЯ".ToCharArray(); // Массив гласных

Random rand = new Random(); // Создание объекта класса Random
var array = new char[K]; // Массив для случайных букв
// Цикл для заполнения массива случайными буквами
for (int i = 0; i < K; i++)
    array[i] = alphabet[rand.Next(0, alphabet.Length)]; // Добавление случайной буквы

List<char> constants = new List<char>(K); // Лист для согласных (чтобы меньше кода было)
// Поиск согласных
foreach (var letter in array)
{
    if(!vowels.Contains(letter))
        constants.Add(letter);
}
Console.WriteLine("Массив случайных букв: " + string.Join(' ', array)); // Вывод массива со случайными буквами
Console.WriteLine("Лист согласных из массива случайных букв" + string.Join(' ', constants)); // Вывод массива с согласными
Console.ReadKey();                            