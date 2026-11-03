
using System;

class Program
{
    static void Main()
    {
        int[] numbers = { 6, 3, 8, 2, 7, 1, 5, 4 };

        Console.WriteLine("Початковий масив:");
        Console.WriteLine(string.Join(" ", numbers));



        for (int i = 0; i < numbers.Length - 1; i++)
        {
            int minIndex = i;

            for (int j = i + 1; j < numbers.Length; j++)
            {
                if (numbers[j] < numbers[minIndex])
                {
                    minIndex = j;
                }
            }

            int temp = numbers[i];
            numbers[i] = numbers[minIndex];
            numbers[minIndex] = temp;
        }

        

        Console.WriteLine("Відсортований масив:");
        Console.WriteLine(string.Join(" ", numbers));
    }
}
