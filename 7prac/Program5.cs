using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

class Program5
{
    static void Mainщ()
    {
        // Два параллельных массива: ФИО и Должности
        string[] fullNames = {
            "Иванов Иван Иванович",
            "Петров Петр Петрович",
            "Сидоров Алексей Сергеевич",
            "Абрамов Дмитрий Викторович",
            "Иванова Мария Александровна",
            "Петрова Ольга Игоревна",
            "Смирнов Сергей Васильевич",
            "Алексеев Андрей Павлович"
        };

        string[] positions = {
            "Разработчик",
            "Аналитик",
            "Разработчик",
            "Менеджер",
            "Дизайнер",
            "Аналитик",
            "Разработчик",
            "Тестировщик"
        };

        Console.WriteLine("Все сотрудники:");
        for (int i = 0; i < fullNames.Length; i++)
        {
            Console.WriteLine($"{i + 1}. {fullNames[i]} - {positions[i]}");
        }
        Console.WriteLine();

        Console.Write("Введите должность: ");
        string position = Console.ReadLine();

        Console.WriteLine($"\nСотрудники на должности '{position}':");
        bool found = false;
        for (int i = 0; i < positions.Length; i++)
        {
            if (positions[i].Contains(position))
            {
                Console.WriteLine($"- {fullNames[i]}");
                found = true;
            }
        }
        if (!found) Console.WriteLine("Не найдено.");

        Console.Write("\nВведите первую букву фамилии: ");
        string letter = Console.ReadLine().ToUpper();

        Console.WriteLine($"\nСотрудники с фамилией на '{letter}':");
        found = false;
        for (int i = 0; i < fullNames.Length; i++)
        {
            if (fullNames[i].StartsWith(letter, StringComparison.OrdinalIgnoreCase))
            {
                Console.WriteLine($"- {fullNames[i]} - {positions[i]}");
                found = true;
            }
        }
        if (!found) Console.WriteLine("Не найдено.");


        Console.WriteLine("\nВсе сотрудники (отсортированные):");
        var sortedIndices = Enumerable.Range(0, fullNames.Length)
            .OrderBy(i => fullNames[i])
            .ToArray();

        foreach (int i in sortedIndices)
        {
            Console.WriteLine($"- {fullNames[i]} - {positions[i]}");
        }
    }
}
