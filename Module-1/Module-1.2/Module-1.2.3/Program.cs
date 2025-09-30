Console.Write("Введите К: ");
int K =  Convert.ToInt32(Console.ReadLine());
int count = 0, num = 2;
// Цикл для поиска простых чисел
while (count < K)
{
    bool prime = true;
    // i * i потому что проверяем только до корня от num
    for (int i = 2; i * i <= num; i++)
        if (num % i == 0)
        {
            prime = false; // Делится на что-то кроме 1 и себя - не простое
        }
    if (prime)
    {
        Console.Write($"{num, 5}"); // Вывод с шириной 5
        count++;
        if (count % 10 == 0) Console.WriteLine();
    }
    num++;
}
Console.ReadKey();