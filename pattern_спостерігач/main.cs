using System;
using System.Collections.Generic;

// Інтерфейс спостерігача
public interface IObserver
{
    void Update(double temperature, double humidity);
}

// Інтерфейс суб'єкта
public interface ISubject
{
    void Attach(IObserver observer);
    void Detach(IObserver observer);
    void Notify();
}

// Центральний хаб
public class ClimateHub : ISubject
{
    private List<IObserver> observers = new List<IObserver>();

    private double temperature;
    private double humidity;

    public void Attach(IObserver observer)
    {
        observers.Add(observer);
        Console.WriteLine("Пристрій підключено.");
    }

    public void Detach(IObserver observer)
    {
        observers.Remove(observer);
        Console.WriteLine("Пристрій відключено.");
    }

    public void Notify()
    {
        foreach (IObserver observer in observers)
        {
            observer.Update(temperature, humidity);
        }
    }

    public void SetClimate(double temperature, double humidity)
    {
        this.temperature = temperature;
        this.humidity = humidity;

        Console.WriteLine();
        Console.WriteLine(
            $"Хаб: температура = {temperature}°C, " +
            $"вологість = {humidity}%");

        Notify();
    }
}

// Розумне освітлення
public class SmartLight : IObserver
{
    public void Update(double temperature, double humidity)
    {
        Console.WriteLine(
            $"SmartLight: отримано дані " +
            $"(температура {temperature}°C, вологість {humidity}%).");
    }
}

// Термостат
public class Thermostat : IObserver
{
    public void Update(double temperature, double humidity)
    {
        if (temperature < 20)
        {
            Console.WriteLine("Thermostat: вмикаю опалення.");
        }
        else if (temperature > 25)
        {
            Console.WriteLine("Thermostat: вимикаю опалення.");
        }
        else
        {
            Console.WriteLine("Thermostat: температура нормальна.");
        }
    }
}

// Кондиціонер
public class AirConditioner : IObserver
{
    public void Update(double temperature, double humidity)
    {
        if (temperature > 27)
        {
            Console.WriteLine(
                "AirConditioner: вмикаю охолодження.");
        }
        else
        {
            Console.WriteLine(
                "AirConditioner: охолодження не потрібне.");
        }
    }
}

// Головна програма
class Program
{
    static void Main()
    {
        ClimateHub hub = new ClimateHub();

        SmartLight light = new SmartLight();
        Thermostat thermostat = new Thermostat();
        AirConditioner airConditioner = new AirConditioner();

        // Підключення пристроїв
        hub.Attach(light);
        hub.Attach(thermostat);
        hub.Attach(airConditioner);

        // Зміна клімату
        hub.SetClimate(18, 60);

        hub.SetClimate(28, 45);

        // Відключення кондиціонера
        hub.Detach(airConditioner);

        // Зміна клімату після відключення
        hub.SetClimate(22, 50);

        Console.ReadKey();
    }
}
