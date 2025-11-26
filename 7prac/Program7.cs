using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

class Program7
{
    static void Main()
    {
        string[] productsData = {
            "Ноутбук-120000-Электроника",
            "Смартфон-75000-Электроника",
            "Футболка-1500-Одежда",
            "Джинсы-3000-Одежда",
            "Кофеварка-8000-Бытовая техника",
            "Микроволновка-12000-Бытовая техника",
            "Книга-500-Книги",
            "Наушники-4500-Электроника",
            "Кроссовки-4000-Обувь",
            "Планшет-55000-Электроника",
            "Холодильник-45000-Бытовая техника",
            "Рубашка-2000-Одежда"
        };
        //Console.WriteLine("Исходный массив: " + string.Join(",", productsData));

        Console.WriteLine("Введите фильтр по категории");
        string filter = Console.ReadLine();

        var filtered = productsData.Where(b => Convert.ToString(b.Split('-')[2]) == filter);
        
        if (filtered.Count() > 0) { Console.WriteLine($"Продукты с фильтром по категории: {filter}"); }
        else { Console.WriteLine($"Продукты с фильтром {filter} не найдены"); }
        foreach (var product in filtered)
        {  Console.WriteLine($" {product.Split('-')[0]}"); }

        Console.WriteLine("Введите фильтр минимальной цены");
        int minCost = Convert.ToInt32(Console.ReadLine());

        Console.WriteLine("Введите фильтр максимальной цены");
        int maxCost = Convert.ToInt32(Console.ReadLine());

        var filteredminCost = productsData.Where(b => Convert.ToInt32(b.Split('-')[1]) >= minCost);
        var filteredCost = filteredminCost.Where(b => Convert.ToInt32(b.Split('-')[1]) <= maxCost);
        var filteredOrderCost = filteredCost.OrderByDescending(b => Convert.ToInt32(b.Split('-')[1]));
        if (filteredCost.Count() > 0) { Console.WriteLine($"Продукты с фильтром по убыванию цены:"); }
        else { Console.WriteLine($"Продукты с фильтром по цене не найдены"); }
        foreach (var product in filteredOrderCost)
        { 
            Console.WriteLine($" {product.Split('-')[0]}"); }
    }
}
