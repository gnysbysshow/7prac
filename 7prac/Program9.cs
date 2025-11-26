using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

class Program9
{
    static void Main()
    {

        string[] studentsData = {
            "Иван-5-4-5-4-5",
            "Мария-3-4-3-4-3",
            "Петр-5-5-5-5-5",
            "Анна-2-3-2-3-2",
            "Сергей-4-4-5-4-4",
            "Ольга-5-4-5-5-4"
        };

        //Поиск студентов со средним баллом выше заданного
        double minAverage = 4.0;
        Console.WriteLine($"Студенты со средним баллом выше {minAverage}:");
        foreach (var student in studentsData)
        {
            var parts = student.Split('-');
            var grades = parts.Skip(1).Select(int.Parse);
            double average = grades.Average();

            if (average > minAverage)
                Console.WriteLine($"{parts[0]}: {average:F2}");
        }

        // Рейтинг студентов по успеваемости
        Console.WriteLine("\nРейтинг студентов:");
        var rankedStudents = studentsData
            .Select(s =>
            {
                var parts = s.Split('-');
                return new
                {
                    Name = parts[0],
                    Average = parts.Skip(1).Select(int.Parse).Average()
                };
            })
            .OrderByDescending(s => s.Average);

        int rank = 1;
        foreach (var student in rankedStudents)
            Console.WriteLine($"{rank++}. {student.Name}: {student.Average:F2}");

        // Автоматическое определение отличников и двоечников
        Console.WriteLine("\nОтличники (средний балл > 4.5):");
        foreach (var student in studentsData)
        {
            var parts = student.Split('-');
            var average = parts.Skip(1).Select(int.Parse).Average();
            if (average >= 4.5)
                Console.WriteLine($"{parts[0]}: {average:F2}");
        }

        Console.WriteLine("\nДвоечники (средний балл < 3.0):");
        foreach (var student in studentsData)
        {
            var parts = student.Split('-');
            var average = parts.Skip(1).Select(int.Parse).Average();
            if (average < 3.0)
                Console.WriteLine($"{parts[0]}: {average:F2}");
        }

        // Статистика по всем оценкам
        Console.WriteLine("\nОбщая статистика:");
        var allGrades = studentsData
            .SelectMany(s => s.Split('-').Skip(1).Select(int.Parse));

        Console.WriteLine($"Средний балл по всем студентам: {allGrades.Average():F2}");
        Console.WriteLine($"Максимальный балл: {allGrades.Max()}");
        Console.WriteLine($"Минимальный балл: {allGrades.Min()}");
    }
}
