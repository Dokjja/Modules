class Author
{
    public string AuthorName { get; set; }
    public double AuthorAge { get; set; }

    public Author(string name, int age)
    {
        AuthorName = name;
        AuthorAge = age;
    }
    public void Print() => Console.WriteLine($"Автор: {AuthorName}, {AuthorAge}");
}

class Book
{
    public string Title { get; set; }
    public int Year { get; set; }
    Author Author { get; set; }

    public Book(string title, int year, Author author)
    {
        Title = title;
        Year = year;
        Author = author;
    }

    public void Print()
    {
        Console.Write($"Название: {Title}, {Year}. ");
        Author.Print();
    } 
}

class Program
{
    static void Main(string[] args)
    {
        Author author1 = new Author("Александр Дюма", 1802);
        Author author2 = new Author("Эмили Бронте", 1848);
            
        Book book1 = new Book("Граф Монте-Кристо", 2024, author1);    
        Book book2 = new Book("Грозовой перевал", 2004, author2);
        book1.Print();
        book2.Print();
        Console.ReadKey();
    }
}