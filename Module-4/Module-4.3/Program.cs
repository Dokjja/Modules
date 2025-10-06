interface IStudent
{
    string Name { get; set; }
    string Group { get; set; }
    int [] Grades { get; set; }
    void AvgGrades();
    void ShowGrades();
    void ShowGroup();
}

class FirstYear : IStudent
{
    public string Name  { get; set; }
    public string Group { get; set; } = "1 курс";
    public int [] Grades {get; set;}
    public void AvgGrades()
    {
        var sum = 0;
        foreach (var grade in Grades)
            sum += grade;    
        Console.WriteLine($"Средний балл студента '{Name}': {sum /  Grades.Length}");
    }

    public void ShowGrades() => Console.WriteLine($"Отметки студента '{Name}': " + string.Join(", ", Grades));
    public void ShowGroup() => Console.WriteLine($"Студент '{Name}' - {Group}");
}

class SecondYear : IStudent
{
    public string Name  { get; set; }
    public string Group { get; set; } = "2 курс";
    public int [] Grades {get; set;}
    public void AvgGrades()
    {
        var sum = 0;
        foreach (var grade in Grades)
            sum += grade;    
        Console.WriteLine($"Средний балл студента '{Name}': {sum /  Grades.Length}");
    }

    public void ShowGrades() => Console.WriteLine($"Отметки студента '{Name}': " + string.Join(", ", Grades));
    public void ShowGroup() => Console.WriteLine($"Студент '{Name}' - {Group}");
}

class Program
{
    static void Main(string[] args)
    {
        List<IStudent> students = new List<IStudent>
        {
            new FirstYear { Name = "Антон А.А.", Grades = [5, 4, 5, 3, 2, 1] },
            new SecondYear { Name = "Сергей С.С.", Grades = [2, 2, 3, 1, 5, 3] }
        };

        foreach (var student in students)
        {
            student.ShowGroup();
            student.ShowGrades();
            student.AvgGrades();
            Console.WriteLine();
        }
        Console.ReadKey();
    }
}