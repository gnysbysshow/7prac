using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _7prac
{
    internal class Program2
    {
        static void Maino(string[] args)
        {
                string[] strings = {
            "apple",
            "banana",
            "application",
            "computer",
            "programming",
            "hello world",
            "cat"
        };

                Console.WriteLine("Массив строк:");
                for (int i = 0; i < strings.Length; i++)
                {
                    Console.WriteLine($"[{i}] {strings[i]}");
                }

                string longestString = strings[0];
                foreach (string str in strings)
                {
                    if (str.Length > longestString.Length)
                    {
                        longestString = str;
                    }
                }
                Console.WriteLine($"Самая длинная строка: \"{longestString}\" (длина: {longestString.Length} символов)");

                Console.Write("Введите подстроку для поиска: ");
                string substring = Console.ReadLine();

                Console.WriteLine($"\nСтроки, содержащие \"{substring}\":");
                bool foundAny = false;
                for (int i = 0; i < strings.Length; i++)
                {
                    if (strings[i].Contains(substring))
                    {
                        Console.WriteLine($"[{i}] {strings[i]}");
                        foundAny = true;
                    }
                }
                if (!foundAny)
                {
                    Console.WriteLine("Строк с такой подстрокой не найдено.");
                }


                Console.Write("Введите строку для поиска индекса: ");
                string searchString = Console.ReadLine();

                int firstIndex = -1;
                for (int i = 0; i < strings.Length; i++)
                {
                    if (string.Equals(strings[i], searchString, StringComparison.OrdinalIgnoreCase))
                    {
                        firstIndex = i;
                        break;
                    }
                }

                if (firstIndex != -1)
                {
                    Console.WriteLine($"Первое вхождение строки \"{searchString}\" найдено по индексу: {firstIndex}");
                }
                else
                {
                    Console.WriteLine($"Строка \"{searchString}\" не найдена в массиве.");
                }
            }
        }
    }

