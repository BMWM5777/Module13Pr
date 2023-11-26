using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Module13Pr
{
    class Employee
    {
        public string LastName { get; set; }
        public string FirstName { get; set; }
        public string MiddleName { get; set; }
        public string Gender { get; set; }
        public int Age { get; set; }
        public decimal Salary { get; set; }

        public Employee(string lastName, string firstName, string middleName, string gender, int age, decimal salary)
        {
            LastName = lastName;
            FirstName = firstName;
            MiddleName = middleName;
            Gender = gender;
            Age = age;
            Salary = salary;
        }

        public override string ToString()
        {
            return $"{LastName} {FirstName} {MiddleName} {Gender} {Age} {Salary}";
        }
    }

    class Program
    {
        static void Main()
        {
            string inputFilePath = "путь/к/вашему/входу/file.txt";
            string outputFilePath = "путь/к/вашему/выходу/file.txt";

            List<Employee> employees = ReadEmployeesFromFile(inputFilePath);

            List<Employee> below10000 = new List<Employee>();
            List<Employee> aboveOrEqual10000 = new List<Employee>();

            foreach (var employee in employees)
            {
                if (employee.Salary < 10000)
                {
                    below10000.Add(employee);
                }
                else
                {
                    aboveOrEqual10000.Add(employee);
                }
            }

            WriteEmployeesToFile(outputFilePath, below10000);
            WriteEmployeesToFile(outputFilePath, aboveOrEqual10000, append: true);

            Console.WriteLine("Программа завершена. Проверьте файл txt2.txt!");
            Console.ReadKey();
        }

        static List<Employee> ReadEmployeesFromFile(string filePath)
        {
            List<Employee> employees = new List<Employee>();

            using (StreamReader reader = new StreamReader(filePath))
            {
                while (!reader.EndOfStream)
                {
                    string line = reader.ReadLine();
                    string[] parts = line.Split(' ');

                    string lastName = parts[0];
                    string firstName = parts[1];
                    string middleName = parts[2];
                    string gender = parts[3];
                    int age = int.Parse(parts[4]);
                    decimal salary = decimal.Parse(parts[5]);

                    employees.Add(new Employee(lastName, firstName, middleName, gender, age, salary));
                }
            }

            return employees;
        }

        static void WriteEmployeesToFile(string filePath, List<Employee> employees, bool append = false)
        {
            FileMode fileMode = append ? FileMode.Append : FileMode.Create;

            using (StreamWriter writer = new StreamWriter(filePath, append: append))
            {
                foreach (var employee in employees)
                {
                    writer.WriteLine(employee.ToString());
                }
            }
        }
    }
}
