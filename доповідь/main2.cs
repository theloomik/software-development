
using System;

class Program
{


    static int Factorial(int n)
    {
        
        if (n <= 1)
        {
            return 1;
        }

        return n * Factorial(n - 1);
    }



    static void Main()
    {
        Console.Write("Введіть число: ");
        int number = Convert.ToInt32(Console.ReadLine());

        int result = Factorial(number);

        Console.WriteLine($"Факторіал числа {number} = {result}");
    }
}
