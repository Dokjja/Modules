class Notification
{
    // События для разных типов уведомлений
    public event Action<string>? OnMessageSent;
    public event Action<string>? OnCallMade;
    public event Action<string>? OnEmailSent;
    // Методы для генерации событий
    public void SendMessage(string message)
    {
        Console.WriteLine("Отправка сообщения...");
        OnMessageSent?.Invoke(message);
    }
    public void MakeCall(string number)
    {
        Console.WriteLine("Набор номера...");
        OnCallMade?.Invoke(number);
    }
    public void SendEmail(string email)
    {
        Console.WriteLine("Отправка письма...");
        OnEmailSent?.Invoke(email);
    }
}

class NotificationHandlers
{
    public void HandleMessage(string message)
    {
        Console.WriteLine($"[Сообщение:]  {message}");
    }

    public void HandleCallMade(string number)
    {
        Console.WriteLine($"Звонок совершен на номер:  {number}");
    }

    public void HandleEmail(string email)
    {
        Console.WriteLine($"Письмо отправлено на адрес:  {email}");
    }
}
class Program
{
    static void Main(string[] args)
    {
        var notifier = new Notification();
        var handlers = new NotificationHandlers();
        // Регистрация обработчиков событий
        notifier.OnMessageSent += handlers.HandleMessage;
        notifier.OnCallMade += handlers.HandleCallMade;
        notifier.OnEmailSent += handlers.HandleEmail;
        // Тестирование событий
        handlers.HandleMessage("Текст сообщения");
        handlers.HandleCallMade("+375336593341");
        handlers.HandleEmail("shevanx21@gmail.com");
        
        Console.ReadKey();
    }
}