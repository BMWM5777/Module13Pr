using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Module13Pr
{
    public class Task1
    {
        static void Main(string[] args)
        {
            List<int> numbers = new List<int> { 7,4,1,3,2,1,8,6,0,8 };
            FindAndPrintSecondMax(numbers);

            RemoveOddNumbers(numbers);
            Console.WriteLine("Список после удаления:");
            foreach (var number in numbers)
            {
                Console.Write($"{number} ");
            }
            Console.ReadKey();
        }
        static void FindAndPrintSecondMax(List<int> numbers)
        {
            if (numbers.Count < 2)
            {
                Console.WriteLine("В коллекции недостаточно элементов для поиска второго максимального значения.");
                return;
            }
            int secondMax = numbers.OrderByDescending(n => n).Skip(1).First();
            Console.WriteLine($"Положение и значение второго максимального элемента: {numbers.IndexOf(secondMax)}, {secondMax}");
        }

        static void RemoveOddNumbers(List<int> numbers)
        {
            List<int> evenNumbers = numbers.Where(n => n % 2 == 0).ToList();
            numbers.Clear();
            numbers.AddRange(evenNumbers);
        }
    }
}
