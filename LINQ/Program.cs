using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text.RegularExpressions;
using System.Xml.Linq;

namespace LINQ
{
    class Program
    {
        public static void Main(string[] args)
        {
            {
                var numbers = new List<int> { 3, 6, 9, 12, 15, 18, 21 };
                //Step 1 : Where is used to filter the values
                //Greater than 10
                var greaterThan10 = numbers.Where(n => n > 10).ToList();
                PrintList("Numbers Greater than 10 :", greaterThan10);

                //Greater than 15
                var greaterThan15 = numbers.Where(n => n > 15).ToList();
                PrintList("Numbers Greater than 15 :", greaterThan15);

                //Less than 10
                var lessThan10 = numbers.Where(n => n < 10).ToList();
                PrintList("Numbers Less Than 10 :", lessThan10);

                //Even Numbers
                var evenNumbers = numbers.Where(n => n % 2 == 0).ToList();
                PrintList("Even Numbers :", evenNumbers);

                //Step 2 : Select is used to perform operation on the values
                //Square Numbers
                var squareNumbers = numbers.Select(n => n * n).ToList();
                PrintList("Square Numbers : ", squareNumbers);

                //Convert to String
                var toString = numbers.Select(n => n.ToString()).ToList();
                PrintList("To String", toString);

                //Multiply greater than 10 numbers by 10
                var multiplyBy10 = numbers.Where(n => n > 10).Select(n => n * 10).ToList();
                PrintList("Multipy Greater Than 10 Numbers By 10", multiplyBy10);

                //Step 3 : 
                //Count → how many?
                //Sum → total?
                //Any → does at least one exist? (Returns True/False)
                //All → does everyone match ? (Returns True/False)

                //Count of the Numbers Greater than 10
                var countGreaterThan10 = numbers.Where(n => n > 10).Count();
                Console.WriteLine($"Count Of Numbers Greater Than 10 : {countGreaterThan10}\n");

                //Sum of Even Numbers
                var sumOfEvenNumbers = numbers.Where(n => n % 2 == 0).Sum();
                Console.WriteLine($"Sum of Even Numbers : {sumOfEvenNumbers}\n");

                //Any Number Greater than 20
                var anyNumberGreaterThan20 = numbers.Any(n => n > 20);
                Console.WriteLine($"Numbers Greater Than 20 : {anyNumberGreaterThan20}\n");

                //Are All Numbers Greater than 0
                var areAllNumbersGreaterThan0 = numbers.All(n => n > 0);
                Console.WriteLine($"Are All Numbers Greater Than 0 : {areAllNumbersGreaterThan0}\n");
            }

            //Step 4 : Objects

            var employees = new List<Employee>
            {
                new Employee {Id = 1, Name = "Sharath", Department = "IT", Salary = 60000},
                new Employee { Id = 2, Name = "Arjun", Department = "HR", Salary = 70000 },
                new Employee { Id = 3, Name = "Ravi", Department = "IT", Salary = 75000 },
                new Employee { Id = 4, Name = "Anil", Department = "Finance", Salary = 50000 },
                new Employee { Id = 5, Name = "Suresh", Department = "IT", Salary = 90000 }
            };

            //Get IT Employees
            var itEmployees = employees.Where(e => e.Department.Equals("IT"));
            PrintList("IT Employees", itEmployees);

            //Get Only Name Salary
            var nameSalary = employees.Select(e => new { e.Name, e.Salary });
            PrintList("Employees only Name and Salary", nameSalary);

            //Employees Earning More than 50k
            var salaryGreaterthan50k = employees.Count(e => e.Salary > 50000);
            Console.WriteLine($"Employees Earning More Than 50k : {salaryGreaterthan50k}");

            //Highest Salary Employee
            var highestSalaryEmployee = employees.OrderByDescending(e => e.Salary).FirstOrDefault();
            if(highestSalaryEmployee != null)
                Console.WriteLine($"Highest Salaried Employee\nId: {highestSalaryEmployee.Id}, Name: {highestSalaryEmployee.Name}, Dept: {highestSalaryEmployee.Department}, Salary: {highestSalaryEmployee.Salary}\n");

            //Is HR present that has salary greater than 60k
            var isHRSalaryGreaterthan60k = employees.Any(e => e.Department == "HR" && e.Salary > 60000);
            Console.WriteLine($"Any HR earning more than 60k : {isHRSalaryGreaterthan60k}");
        }

        public static void PrintList<T>(string operation, IEnumerable<T> values)
        {
            Console.WriteLine(operation);
            foreach (var item in values)
            {
                Console.Write($"{item} ");
            }
            Console.WriteLine("\n");
        }
    }
}