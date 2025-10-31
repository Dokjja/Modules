class Program
{
    static void Main(string[] args)
    {
        Console.Write("Введите полный путь к файлу со студентами: ");
        string? path = Console.ReadLine();
        StudentManager manager = new StudentManager(path); // 
        manager.LoadFromFile();
        while (true)
        {
            Console.WriteLine("\n--- Меню ---");
            Console.WriteLine("1. Добавить студента");
            Console.WriteLine("2. Удалить студента");
            Console.WriteLine("3. Редактировать студента");
            Console.WriteLine("4. Показать всех студентов");
            Console.WriteLine("5. Поиск по имени");
            Console.WriteLine("6. Сортировка по ID");
            Console.WriteLine("7. Сортировка по имени");
            Console.WriteLine("8. Сохранить и выйти");
            Console.Write("Выберите пункт: ");
            string? input = Console.ReadLine();
            Console.WriteLine();
            switch (input)
            {
                case "1": manager.AddStudent(); break;
                case "2": manager.DeleteStudent(); break;
                case "3": manager.EditStudent(); break;
                case "4": manager.ShowAll(); break;
                case "5": manager.SearchByName(); break;
                case "6": manager.SortById(); manager.ShowAll(); break;
                case "7": manager.SortByName(); manager.ShowAll(); break;
                case "8": manager.SaveToFile(); return;
                default: Console.WriteLine("Неверный выбор!"); break;
            }
        }
    }
}
class Student
{
    public int Id { get; set; }
    public string? Name { get; set; }
    public int Age {get; set;}
    public override string ToString() => $"{Id}. {Name}, {Age} лет";
}
class StudentManager(string? path)
{
    private readonly List<Student> _students = new List<Student>();

    public void AddStudent()
    {
        Student student = new Student();
        Console.Write("ID: "); student.Id = int.Parse(Console.ReadLine() ?? string.Empty);
        Console.Write("Имя: "); student.Name = Console.ReadLine() ?? string.Empty;
        Console.Write("Возраст: "); student.Age = int.Parse(Console.ReadLine() ?? string.Empty);
        _students.Add(student);
    }
    public void DeleteStudent()
    {
        Console.Write("Введите ID для удаления: ");
        int id = int.Parse(Console.ReadLine() ?? string.Empty);
        for (int i = 0; i < _students.Count; i++)
        {
            if (_students[i].Id == id)
            {
                _students.RemoveAt(i);
                Console.WriteLine("Удалено!");
                return;
            }
        }
        Console.WriteLine("Студент не найден!");    
    }    
    public void EditStudent()
    {
        Console.Write("Введите ID студента для редактирования: ");
        int id = int.Parse(Console.ReadLine() ?? string.Empty);
        foreach (var s in _students)
        {
            if (s.Id == id)
            {
                Console.Write("Новое имя: "); s.Name = Console.ReadLine();
                Console.Write("Новый возраст: "); s.Age = int.Parse(Console.ReadLine() ?? string.Empty);
                Console.WriteLine("Изменения сохранены!");
                return;
            }
        }
        Console.WriteLine("Студент не найден!");
    }
    public void ShowAll()
    {
        if (_students.Count == 0) Console.WriteLine("Список пуст.");
        foreach (var s in _students) Console.WriteLine(s);
    }
    public void SearchByName()
    {
        Console.Write("Введите имя для поиска: ");
        string name = Console.ReadLine().ToLower();
        bool found = false;
        foreach (var s in _students)
        {
            if (s.Name != null && s.Name.ToLower().Contains(name))
            {
                Console.WriteLine(s);
                found = true;
            }
        }
        if (!found) Console.WriteLine("Совпадений не найдено.");
    }
    public void SortById()
    {
        for (int i = 0; i < _students.Count - 1; i++)
        for (int j = 0; j < _students.Count - i - 1; j++)
            if (_students[j].Id > _students[j + 1].Id)
                (_students[j], _students[j + 1]) = (_students[j + 1], _students[j]);
        Console.WriteLine("Сортировка по ID выполнена.");
    }
    public void SortByName()
    {
        for (int i = 0; i < _students.Count - 1; i++)
        for (int j = 0; j < _students.Count - i - 1; j++)
            if (String.Compare(_students[j].Name, _students[j + 1].Name, StringComparison.OrdinalIgnoreCase) > 0)
                (_students[j], _students[j + 1]) = (_students[j + 1], _students[j]);
        Console.WriteLine("Сортировка по имени выполнена.");
    }
    public void SaveToFile()
    {
        using (StreamWriter sw = new StreamWriter(path))
            foreach (var s in _students)
                sw.WriteLine($"{s.Id};{s.Name};{s.Age}");
        Console.WriteLine("Список сохранён.");
    }
    public void LoadFromFile()
    {
        if (!File.Exists(path)) return;
        string[] lines = File.ReadAllLines(path);
        foreach (var line in lines)
        {
            var parts = line.Split(';');
            if (parts.Length == 3)
            {
                _students.Add(new Student
                {
                    Id = int.Parse(parts[0]),
                    Name = parts[1],
                    Age = int.Parse(parts[2])
                });
            }
        }
        Console.WriteLine($"Загружено студентов: {_students.Count}");
    }
}
