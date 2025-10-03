using System.Collections.Generic;
// Делегат для фильтрации с параметром типа TaskItem
public delegate bool DataFilter(TaskItem item);
// Класс задачи
public class TaskItem(string title, DateTime dueDate)
{
    public string Title { get; set; } = title;
    public DateTime DueDate { get; set; } = dueDate;

    public override string ToString()
    {
        return $"{Title} (до {DueDate:dd.MM.yyyy})";
    }
}
class Program
{
    private static void Print(List<TaskItem> tasks, DataFilter filter)
    {
        Console.WriteLine("Отфильтрованные задачи:");
        foreach (var task in tasks)
        {
            if (filter(task))
                Console.WriteLine(task);
        }    
    }
    static void Main()
    {
        // Исходные данные
        var tasks = new List<TaskItem>
        {
            new TaskItem("Сдать отчёт", new DateTime(2025, 10, 5)),
            new TaskItem("Позвонить клиенту", new DateTime(2025, 10, 3)),
            new TaskItem("Обновить сайт", new DateTime(2025, 10, 10)),
            new TaskItem("Отправить письмо", new DateTime(2025, 10, 3))
        };
        foreach (var task in tasks)
        {
            Console.WriteLine(task);
        }
        DataFilter? filter = null;
        var exit = false;
        while (!exit)
        {
            Console.WriteLine("Выберите фильтр:");
            Console.WriteLine("1 — По дате (только задачи на сегодня)");
            Console.WriteLine("2 — По ключевому слову (например, 'письмо')");
            Console.WriteLine("3 - Выход");

            string choice = Console.ReadLine()!;
            switch (choice)
            {
                case "1":
                    DateTime today = DateTime.Today;
                    // Присваивает делегату ИСТИНА, если дата задачи совпадает с сегодняшней
                    filter = item => item.DueDate.Date == today;
                    Print(tasks, filter);
                    break;
                case "2":
                    Console.WriteLine("Введите ключевое слово:");
                    string keyword = Console.ReadLine()!.ToLower();
                    // Присваивает делегату ИСТИНА, если в названии встречается ключевое слово
                    filter = item => item.Title.ToLower().Contains(keyword);
                    Print(tasks, filter);
                    break;
                case "3":
                    filter = item => true;
                    exit = true;
                    break;
                default:
                    Console.WriteLine("Неверный выбор. Показываются все задачи.");
                    filter = item => true;
                    break;
            }    
        }
        Console.ReadKey();
    }
}