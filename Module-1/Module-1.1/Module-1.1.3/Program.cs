Console.Write("Введите имя и фамилию: ");
string[] str = Console.ReadLine()!.Split(' ');
Console.WriteLine($"Вывод в формате 'Фамилия, Имя': {str[1]}, {str[0]}");
Console.WriteLine("Нажмите любую клавишу для выхода...");
Console.ReadKey();