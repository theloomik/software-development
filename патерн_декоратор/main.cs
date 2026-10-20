
using System;

interface IPizza
{
    string GetDescription();
    decimal GetPrice();
}

// Базова піца
class BasicPizza : IPizza
{
    public string GetDescription()
    {
        return "Коржик з томатним соусом";
    }

    public decimal GetPrice()
    {
        return 120;
    }
}

// Базовий декоратор
abstract class PizzaDecorator : IPizza
{
    protected IPizza pizza;

    public PizzaDecorator(IPizza pizza)
    {
        this.pizza = pizza;
    }

    public virtual string GetDescription()
    {
        return pizza.GetDescription();
    }

    public virtual decimal GetPrice()
    {
        return pizza.GetPrice();
    }
}

// Декоратор: сир
class Cheese : PizzaDecorator
{
    public Cheese(IPizza pizza) : base(pizza) { }

    public override string GetDescription()
    {
        return pizza.GetDescription() + ", сир";
    }

    public override decimal GetPrice()
    {
        return pizza.GetPrice() + 30;
    }
}

// Декоратор: ковбаса
class Sausage : PizzaDecorator
{
    public Sausage(IPizza pizza) : base(pizza) { }

    public override string GetDescription()
    {
        return pizza.GetDescription() + ", ковбаса";
    }

    public override decimal GetPrice()
    {
        return pizza.GetPrice() + 35;
    }
}

// Декоратор: овочі
class Vegetables : PizzaDecorator
{
    public Vegetables(IPizza pizza) : base(pizza) { }

    public override string GetDescription()
    {
        return pizza.GetDescription() + ", овочі";
    }

    public override decimal GetPrice()
    {
        return pizza.GetPrice() + 20;
    }
}

// Декоратор: додатковий соус
class ExtraSauce : PizzaDecorator
{
    public ExtraSauce(IPizza pizza) : base(pizza) { }

    public override string GetDescription()
    {
        return pizza.GetDescription() + ", додатковий соус";
    }

    public override decimal GetPrice()
    {
        return pizza.GetPrice() + 10;
    }
}

class Program
{
    static void Main()
    {
        IPizza pizza = new BasicPizza();

        Console.WriteLine("===");
        Console.WriteLine("Базова піца: 120 грн");
        Console.WriteLine();

        Console.WriteLine("інгредієнти:");
        Console.WriteLine("1 -- Сир (+30 грн)");
        Console.WriteLine("2 -- Ковбаса (+35 грн)");
        Console.WriteLine("3 -- Овочі (+20 грн)");
        Console.WriteLine("4 -- Додатковий соус (+10 грн)");
        Console.WriteLine("0 -- Завершити");

        while (true)
        {
            Console.Write("\nВаш вибір: ");
            string choice = Console.ReadLine() ?? "";

            switch (choice)
            {
                case "1":
                    pizza = new Cheese(pizza);
                    Console.WriteLine("Додано сир.");
                    break;

                case "2":
                    pizza = new Sausage(pizza);
                    Console.WriteLine("Додано ковбасу.");
                    break;

                case "3":
                    pizza = new Vegetables(pizza);
                    Console.WriteLine("Додано овочі.");
                    break;

                case "4":
                    pizza = new ExtraSauce(pizza);
                    Console.WriteLine("Додано додатковий соус.");
                    break;

                case "0":
                    Console.WriteLine("\n=== ВАШЕ ЗАМОВЛЕННЯ ===");
                    Console.WriteLine("Піца: " + pizza.GetDescription());
                    Console.WriteLine("Загальна вартість: "
                        + pizza.GetPrice() + " грн");
                    Console.WriteLine("Дякуємо за замовлення!");
                    return;

                default:
                    Console.WriteLine("Невірний вибір. Спробуйте ще раз.");
                    break;
            }
        }
    }
}
