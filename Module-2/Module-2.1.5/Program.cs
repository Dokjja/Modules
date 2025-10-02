using System;
class TemperatureSensor
{
    // Событие, которое будет вызываться при изменении температуры
    public event Action<double>? TemperatureChanged; 
    // Позволяет задать новую температуру
    public void SetTemperature(double temp)
    {
        // Если есть подписчик, событие вызывается с переданной температурой
        TemperatureChanged?.Invoke(temp); 
    }
}

class Thermostat 
{
    // Вызывается при смене температуры
    public void React(double temp)
    {
        Console.WriteLine(temp < 10 ? $"Включаем отопление ({temp} градусов)" :$"Выключаем отопление ({temp} градусов)");      
    }  
}
class Program
{
    static void Main(string[] args)
    {
        var sensor = new TemperatureSensor();
        var thermostat = new Thermostat();
        // thermostat.React подписсывается на событие
        sensor.TemperatureChanged += thermostat.React;

        sensor.SetTemperature(18);
        sensor.SetTemperature(5);
        Console.ReadKey();
    }
    
}