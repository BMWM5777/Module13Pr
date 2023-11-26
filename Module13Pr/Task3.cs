using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Module13Pr
{
    public class Task3
    {
        static void Main()
        {
            string inputFileName = "txt1.txt";
            string outputFileName = "txt2.txt";

            WriteNumbersToFile(inputFileName);
            ReverseAndWriteNumbersToFile(inputFileName, outputFileName);

            Console.WriteLine("Программа завершена. Проверьте файл txt2.txt!");
            Console.ReadKey();
        }

        static void WriteNumbersToFile(string fileName)
        {
            using (StreamWriter writer = new StreamWriter(fileName))
            {
                writer.WriteLine("1 2 3 4 5 6 7 8 9");
            }
        }

        static void ReverseAndWriteNumbersToFile(string inputFileName, string outputFileName)
        {
            string[] numbersArray = File.ReadAllText(inputFileName).Split(' ');
            Array.Reverse(numbersArray);
            using (StreamWriter writer = new StreamWriter(outputFileName))
            {
                foreach (string number in numbersArray)
                {
                    writer.Write($"{number} ");
                }
            }
        }
    }

}

