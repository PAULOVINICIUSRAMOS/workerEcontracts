using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ConsoleApp23.Entities.Enums;
using ConsoleApp23.Entities;
using System.Globalization;

namespace ConsoleApp23
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.Write("Enter departtment's name:");
            string deptName = Console.ReadLine();
            Console.WriteLine("Enter worker data:");
            Console.WriteLine("Enter name employee");
            string name = Console.ReadLine();
            Console.WriteLine("level (Junior/MidLevel/Senior");
            WorkerLevel level = (WorkerLevel)Enum.Parse(typeof(WorkerLevel), Console.ReadLine());
            Console.WriteLine("Enter Base salary:");
            double baseSalary = double.Parse(Console.ReadLine(), CultureInfo.InvariantCulture);

            Departament dept = new Departament(deptName);
            Worker worker = new Worker(name, level, baseSalary, dept);

            Console.Write("How Many contract to this worker");
            int n = int.Parse(Console.ReadLine());

            for (int i = 1; i <= n; i++)
            {
                Console.WriteLine($"Enter #{i} contract data:");
                Console.Write(" Date(DD/MM/YYYY): ");
                DateTime date = DateTime.Parse(Console.ReadLine());
                Console.Write("Value Hour:");
                double valuePerHour = double.Parse(Console.ReadLine());
                Console.Write("Duration (hours):");
                int hours = int.Parse(Console.ReadLine());

                HourContract contract = new HourContract(date, valuePerHour, hours);
                worker.addContract(contract); // adiciona o contrato ao trabalhador

            }

            Console.WriteLine();
            Console.WriteLine("Enter month and year to calculate income (MM/YYYY):");
            string monthAndYear = Console.ReadLine();
            int month = int.Parse(monthAndYear.Substring(0, 2));
            int year = int.Parse(monthAndYear.Substring(3));

            Console.WriteLine("Name" + worker.Name);
            Console.WriteLine("Departament:" + worker.Departament.Name);
            Console.WriteLine("Income:" + monthAndYear + "," + worker.Income(year , month));



        }
    }
}
