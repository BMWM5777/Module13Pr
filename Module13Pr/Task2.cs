using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Module13Pr
{
    public class Task2
    {
        static void Main()
        {
            List<double> numbers = new List<double> { 1.2, 2.3, 3.4 , 4.5, 5.6, 6.7, 7.8, 8.9 };
            PrintNumbersGreaterThanAverage(numbers);
            Console.ReadKey();
        }

        static void PrintNumbersGreaterThanAverage(List<double> numbers)
        {
            if (numbers.Count == 0)
            {
                Console.WriteLine("Список пуст!");
                return;
            }
            double average = numbers.Average();
            Console.WriteLine($"Элементы выше среднего ({average}):");
            foreach (var number in numbers.Where(n => n > average))
            {
                Console.Write($"{number} ");
            }
        }
    }

}

