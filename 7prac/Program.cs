using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _7prac
{
    internal class Program
    {
        static void Mainр(string[] args)
        {
            int[] numbers = new int[10];
            Random random = new Random();

            for (int i = 0; i < numbers.Length; i++)
            {
                numbers[i] = random.Next(0,100);
            }

            int sum = 0;
            for (int i = 0; i < numbers.Length; i++)
            {
                sum += numbers[i];
            }

            double average = (double)sum / numbers.Length;

            int evenCount = 0;
            for (int i = 0; i < numbers.Length; i++)
            {
                if (numbers[i] % 2 == 0)
                {
                    evenCount++;
                }
            }

            Console.WriteLine($"Массив: {string.Join(", ", numbers)}");
            Console.WriteLine($"Сумма всех элементов: {sum}");
            Console.WriteLine($"Среднее арифметическое: {average:F2}");
            Console.WriteLine($"Количество четных чисел: {evenCount}");
        }
    }
}
