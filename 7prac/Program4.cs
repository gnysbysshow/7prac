using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

class Program4
{
    static void Maino()
    {
        int[] numbers = new int[10];
        Random random = new Random();


        for (int i = 0; i < numbers.Length; i++)
        {
            numbers[i] = random.Next(0, 10);
        }
        Console.WriteLine("Исходный массив: " + string.Join(", ", numbers));

        int nonZeroCount = 0;
        foreach (int number in numbers)
        {
            if (number != 0)
            {
                nonZeroCount++;
            }
        }

        int[] result = new int[nonZeroCount];
        int index = 0;

        foreach (int number in numbers)
        {
            if (number != 0)
            {
                result[index] = number;
                index++;
            }
        }

        Console.WriteLine("Массив без нулей: " + string.Join(", ", result));
        Console.WriteLine($"Размер исходного массива: {numbers.Length}");
        Console.WriteLine($"Размер нового массива: {result.Length}");
    }
}
