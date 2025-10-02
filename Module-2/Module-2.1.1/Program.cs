using System;

class Person
{
    public string Name { get; set; }
    public int Age { get; set; }
    public string Address { get; set; }
    // Конструктор класса Person
    public Person(string name = "Не введено!", int age = 0, string address = "Не введено!")
    {
        Name =  name;
        Age = age;
        Address = address;
    }
    public void Print() => Console.WriteLine($"Имя: {Name}, Возраст: {Age}, Адрес: {Address}");
}

class Program
{
    static void Main(string[] args)
    {
        Console.Write("Введите имя: ");
        var name = Console.ReadLine()!;
        Console.Write("Введите возраст: ");
        var  age = int.Parse(Console.ReadLine()!);
        Console.Write("Введите адрес: ");
        var address = Console.ReadLine()!;
        var person = new Person(name, age, address);
        person.Print();
        Console.ReadKey();
    }
}