using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

class Program8
{
    static void Main0()
    {
        {
            double[] results = { 85, 92, 78, 96, 67, 88, 74, 91, 83, 79, 95, 82, 76, 89, 72, 98, 81, 87, 93, 68 };

            var sorted = results.OrderBy(x => x).ToArray();

            double median;
            if (sorted.Length % 2 == 0)
            { // Четное
                int middleIndex1 = sorted.Length / 2 - 1;
                int middleIndex2 = sorted.Length / 2;
                double middleValue1 = sorted[middleIndex1];
                double middleValue2 = sorted[middleIndex2];
                median = (middleValue1 + middleValue2) / 2.0;
            }
            else
            {// Нечетное
                int middleIndex = sorted.Length / 2;
                median = sorted[middleIndex];
            }

            // Стандартное отклонение
            double mean = sorted.Average();
            double stdDev = Math.Sqrt(sorted.Average(x => Math.Pow(x - mean, 2)));

            // Топ-10%
            var top10 = sorted.Skip((int)(sorted.Length * 0.9)).ToArray();

            var grp = new List<string>();

            // Группируем элементы отсортированного массива
            foreach (var group in sorted.GroupBy(x => (int)(x / 10) * 10))
            {
                int rangeStart = group.Key;
                int rangeEnd = group.Key + 9;

                int countInGroup = group.Count();

                double percentage = (double)countInGroup / sorted.Length * 100;
                string resultString = $"{rangeStart}-{rangeEnd}: {countInGroup} ({percentage:F1}%)";
                grp.Add(resultString);
            }

            Console.WriteLine($"Медиана: {median:F1}");
            Console.WriteLine($"Стандартное отклонение: {stdDev:F1}");
            Console.WriteLine($"Топ 10% лучших результатов: {string.Join(" ", top10.Select(x => x.ToString("F0")))}");
            Console.WriteLine($"Группировка по интервалам:\n{string.Join("\n", grp)}");
        }
    }
}
