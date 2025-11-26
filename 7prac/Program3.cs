using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

class Program
{
    static void Mainp()
    {
        double[] numbers = { 3.14, 2.71, 1.41, 8.54, 6.28, 4.67, 9.81, 5.43, 7.29, 0.57, 2.35, 8.13, 6.67, 4.20, 3.33, 6.54 };

        Console.WriteLine("Массив вещественных чисел:");
        for (int i = 0; i < numbers.Length; i++)
        {
            Console.WriteLine($"[{i}] {numbers[i]:F2}");
        }
        Console.WriteLine();

        double min = numbers[0];
        double max = numbers[0];

        foreach (double number in numbers)
        {
            if (number < min) min = number;
            if (number > max) max = number;
        }

        Console.WriteLine($"Минимальный элемент: {min:F2}");
        Console.WriteLine($"Максимальный элемент: {max:F2}");

        double difference = max - min;
        Console.WriteLine($"Разность между максимальным и минимальным: {difference:F2}");

        double sum = 0;
        foreach (double number in numbers)
        {
            sum += number;
        }
        double average = sum / numbers.Length;
        Console.WriteLine($"Среднее арифметическое: {average:F2}");

        Console.WriteLine("\nЭлементы, которые больше среднего арифметического:");
        for (int i = 0; i < numbers.Length; i++)
        {
            if (numbers[i] > average)
            {
                Console.WriteLine($"[{i}] {numbers[i]:F2}");
            }
        }
    }
}
