using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

class Program6
{
    static void Main6()
    {
        double[] temperatures = {
            15.5, 17.2, 14.8, 16.3, 18.1, 20.5, 22.3,
            19.8, 17.6, 16.9, 15.2, 14.1, 13.5, 12.8,
            11.2, 10.5, 9.8, 12.3, 15.7, 18.9, 21.2,
            23.5, 25.1, 24.8, 22.6, 20.3, 18.7, 16.4,
            14.9, 13.2
        };

        Console.WriteLine("Температуры за месяц:");
        PrintTemperatures(temperatures);
        Console.WriteLine();

        // 1. Самая теплая и холодная неделя
        FindWarmestAndColdestWeeks(temperatures);

        // 2. Дни с температурой выше средней
        FindDaysAboveAverage(temperatures);

        // 3. Группировка по диапазонам
        GroupTemperaturesByRange(temperatures);
    }

    static void PrintTemperatures(double[] temps)
    {
        for (int i = 0; i < temps.Length; i++)
        {
            Console.WriteLine($"День {i + 1,2}: {temps[i],4}°C");
        }
    }

    static void FindWarmestAndColdestWeeks(double[] temps)
    {
        int daysInWeek = 7;
        int weeks = temps.Length / daysInWeek;

        var weekAverages = new List<(int week, double avgTemp)>();

        for (int week = 0; week < weeks; week++)
        {
            double sum = 0;
            for (int day = 0; day < daysInWeek; day++)
            {
                int index = week * daysInWeek + day;
                sum += temps[index];
            }
            double avg = sum / daysInWeek;
            weekAverages.Add((week + 1, avg));
        }

        var warmestWeek = weekAverages.OrderByDescending(w => w.avgTemp).First();
        var coldestWeek = weekAverages.OrderBy(w => w.avgTemp).First();

        Console.WriteLine("Анализ по неделям:");
        Console.WriteLine($"Самая теплая неделя: {warmestWeek.week} (средняя: {warmestWeek.avgTemp:F1}°C)");
        Console.WriteLine($"Самая холодная неделя: {coldestWeek.week} (средняя: {coldestWeek.avgTemp:F1}°C)");
        Console.WriteLine();
    }

    static void FindDaysAboveAverage(double[] temps)
    {
        double average = temps.Average();
        var aboveAverage = new List<(int day, double temp)>();

        for (int i = 0; i < temps.Length; i++)
        {
            if (temps[i] > average)
            {
                aboveAverage.Add((i + 1, temps[i]));
            }
        }

        Console.WriteLine($"Средняя температура за месяц: {average:F1}°C");
        Console.WriteLine($"Дни с температурой выше средней ({aboveAverage.Count} дней):");

        foreach (var day in aboveAverage)
        {
            Console.WriteLine($"День {day.day,2}: {day.temp,4}°C");
        }
        Console.WriteLine();
    }

    static void GroupTemperaturesByRange(double[] temps)
    {
        var ranges = new Dictionary<string, (double min, double max)>
        {
            ["Мороз"] = (-50, 0),
            ["Холодно"] = (0, 10),
            ["Прохладно"] = (10, 15),
            ["Тепло"] = (15, 20),
            ["Жарко"] = (20, 50)
        };

        var grouped = new Dictionary<string, List<(int day, double temp)>>();

        // Инициализируем группы
        foreach (var range in ranges.Keys)
        {
            grouped[range] = new List<(int day, double temp)>();
        }

        // Группируем температуры
        for (int i = 0; i < temps.Length; i++)
        {
            foreach (var range in ranges)
            {
                if (temps[i] > range.Value.min && temps[i] <= range.Value.max)
                {
                    grouped[range.Key].Add((i + 1, temps[i]));
                    break;
                }
            }
        }

        Console.WriteLine("Группировка температур по диапазонам:");
        foreach (var group in grouped.OrderBy(g => ranges[g.Key].min))
        {
            Console.WriteLine($"{group.Key,-10}: {group.Value.Count,2} дней");
            if (group.Value.Any())
            {
                var days = string.Join(", ", group.Value.Select(d => $"день {d.day}({d.temp:F1}°)"));
                Console.WriteLine($"           {days}");
            }
        }
    }
}
