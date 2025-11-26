using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

class Lesson
{
    static void Main4()
    {
    string[] books =
    {
    "Война И Мир-Толстой-1869-4,8",
    "Преступление И Накзаание-Достоевский-1866-4,7",
    "1984-Оруэлл-1949-4,6",
    "Мастер и Марграрита-Булгаков-1967-4,9",
    "Властелин колец-Толкин-1954-4,8",
    "Гарри Поттер-Роулинг-1997-4,3",
    "Вишневый Сад-Чехов-1904-4,5",
    "Новая Книга-Автор-2020-4,1"
    };
        Console.WriteLine("===Анализ библиотеки===");

        Console.WriteLine("Книги с рейтингом > 4.5");
        var highRated = books.Where(b => Convert.ToDouble(b.Split('-')[3]) > 4.5);
        foreach (var book in highRated)
        {
            Console.WriteLine($" {book.Split('-')[0]}");
        }
       
        Console.WriteLine("\nКниги выпущенные после 2015 года");
        var dateafter = books.Where(y => Convert.ToInt32(y.Split('-')[2]) > 2015);
        foreach (var book in dateafter)
        {
            Console.WriteLine($" {book.Split('-')[0]}");
        }
    }
}
