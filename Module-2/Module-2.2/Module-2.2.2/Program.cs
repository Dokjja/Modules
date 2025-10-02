struct Student
{
    public string LastName;
    public string Initials;
    public string GroupNumber;
    public int[] Grades;
    // Конструктор
    public Student(string lastName, string initials, string groupNumber, int[] grades)
    {
        LastName = lastName;
        Initials = initials;
        GroupNumber = groupNumber;
        Grades = grades;
    }
    // Метод для нахождения среднего балла
    public int AvgGrade()
    {
        double sum = 0;
        foreach (var grade in Grades)
            sum += grade;
        return (int)Math.Round(sum / Grades.Length);
    }
    // Методод для проверки оценок
    public bool HasOnlyFoursAndFives()
    {
        for (int i = 0; i < Grades.Length; i++)
        {
            if (Grades[i] != 4 && Grades[i] != 5)
                return false;
        }
        return true;
    }
    // Метод для вывода информации о студенте
    public void Print()
    {
        Console.WriteLine($"{LastName} {Initials}, группа: {GroupNumber}, средний балл: {AvgGrade():F2}");
    }
}

class Program
{
    static void Main(string[] args)
    {
        Student[] students =
        [
            new Student { LastName = "Иванов", Initials = "И.И.", GroupNumber = "101", Grades = new[] {5, 4, 4, 4, 5} },
            new Student { LastName = "Петров", Initials = "П.П.", GroupNumber = "102", Grades = new[] {3, 3, 4, 3, 4} },
            new Student { LastName = "Сидоров", Initials = "С.С.", GroupNumber = "103", Grades = new[] {5, 5, 5, 5, 5} }
        ];
        // Вывод всей информации о студентах
        foreach (var student in students)
            student.Print();
        // Вывод студентов с оценками 4 и 5
        Console.WriteLine("Студенты с оценками только 4 и 5:");
        for (int i = 0; i < students.Length; i++)
        {
            if (students[i].HasOnlyFoursAndFives())
                Console.WriteLine($"{students[i].LastName}, группа: {students[i].GroupNumber}");
        }
        // Вычисляет средний балл всех студентов
        for (int i = 0; i < students.Length; i++)
        {
            for (int j = 0; j < students[i].Grades.Length; j++)
            {
                students[i].Grades[j] = students[i].AvgGrade();
            }
        }
        // Сортирует студентов по среднему баллу
        for (int i = 0; i < students.Length - 1; i++)
        {
            for (int j = i + 1; j < students.Length; j++)
            {
                if (students[i].AvgGrade() > students[j].AvgGrade())
                    (students[i], students[j]) = (students[j], students[i]);
            }
        }
        // Вывод отсортированный массив структуры
        Console.WriteLine("Студенты по возрастанию среднего балла:");
        for (int i = 0; i < students.Length; i++)
            students[i].Print();
        
        Console.ReadKey();
    }
}