using System.Collections.Generic;
// Делагат для обработки задачи
public delegate void TaskHandler(string taskDesc);
//Класс задачи
class Task(string desc, TaskHandler handler)
{
    public string Description { get; set; } = desc;
    public TaskHandler Handler { get; set; } = handler;
    // Вызывает делегат и передает строку с описанием
    public void Execute()
    {
        Handler(Description);
    }
}

class TaskActions
{
    public void SendNotification(string taskDesc)
    {
        Console.WriteLine($"Уведомление:  {taskDesc}");
    }

    public void WriteLog(string taskDesc)
    {
        Console.WriteLine($"Запись в журнал: {taskDesc}");
    }
}

class Program
{
    static void Main(string[] args)
    {
        var actions = new TaskActions();
        var tasks = new List<Task>();

        while (true)
        {
            Console.Write("Введите описание задачи или 'выход': ");
            string input = Console.ReadLine()!;
            if (input.ToLower() == "выход") break;
            Console.WriteLine("Выберите обработчик задачи:");
            Console.WriteLine("1 — Отправить уведомление");
            Console.WriteLine("2 — Записать в журнал");
            string choice = Console.ReadLine()!;
            TaskHandler handler;
            switch (choice)
            {
                case "1":
                    handler = actions.SendNotification;
                    break;
                case "2":
                    handler = actions.WriteLog;
                    break;
                default:
                    handler = actions.WriteLog; // обработчик по умолчанию
                    break;
            }
            tasks.Add(new Task(input, handler));
        }
        Console.WriteLine("Выполнение задач:");
        foreach (var task in tasks)
            task.Execute();

        Console.ReadKey();
    }
}