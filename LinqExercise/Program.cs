﻿using System;
using System.Collections.Generic;
using System.Linq;

namespace LinqExercise
{
    class Program
    {
        //Static array of integers
        private static int[] numbers = { 1, 2, 3, 4, 5, 6, 7, 8, 9, 0 };

        static void Main(string[] args)
        {
            /*
             * 
             * Complete every task using Method OR Query syntax. 
             * You may find that Method syntax is easier to use since it is most like C#
             * Every one of these can be completed using Linq and then printing with a foreach loop.
             * Push to your github when completed!
             * 
             */

            //TODO: Print the Sum of numbers
            Console.WriteLine($"Sum: {numbers.Sum()}");
            //TODO: Print the Average of numbers
            Console.WriteLine($"Average: {numbers.Average()}");
            //TODO: Order numbers in ascending order and print to the console
            Console.WriteLine("numbers in Ascending Order:");
            numbers.OrderBy(x => x).ToList().ForEach(x => Console.WriteLine(x));
            //TODO: Order numbers in decsending order and print to the console
            Console.WriteLine("numbers in Descending Order:");
            numbers.OrderByDescending(x => x).ToList().ForEach(x => Console.WriteLine(x));
            //TODO: Print to the console only the numbers greater than 6
            Console.WriteLine("Numbers >  6");
            numbers.Where(x => x > 6).ToList().ForEach(x => Console.WriteLine(x));
            //TODO: Order numbers in any order (acsending or desc) but only print 4 of them **foreach loop only!**
            Console.WriteLine("numbers in Descending Order (Only Print 4):");
            foreach (var item in numbers.OrderBy(x => x).Take(4))
            {
                Console.WriteLine(item);
            }
            //TODO: Change the value at index 4 to your age, then print the numbers in decsending order
            numbers.SetValue(21, 4);
            Console.WriteLine("Changed Number at Index 4");
            numbers.ToList().ForEach(x => Console.WriteLine(x));

            // List of employees ****Do not remove this****
            var employees = CreateEmployees();

            //TODO: Print all the employees' FullName properties to the console only if their FirstName starts with a C OR an S and order this in ascending order by FirstName.
            employees.Where(x => x.FirstName.StartsWith("C") || x.FirstName.StartsWith("S")).OrderBy(x => x.FirstName).ToList().ForEach(x => Console.WriteLine(x.FullName));
            //TODO: Print all the employees' FullName and Age who are over the age 26 to the console and order this by Age first and then by FirstName in the same result.
            Console.WriteLine();
            employees.Where(employee => employee.Age > 26)
                .OrderBy(employee => employee.Age)
                .ThenBy(employee => employee.FirstName)
                .ToList()
                .ForEach(x => Console.WriteLine($"{x.FullName} Age:{x.Age}"));
            //TODO: Print the Sum and then the Average of the employees' YearsOfExperience if their YOE is less than or equal to 10 AND Age is greater than 35.
            Console.WriteLine();
            int sum = employees.Where(x => x.YearsOfExperience <= 10 && x.Age > 35).Sum(x => x.YearsOfExperience);
            Console.WriteLine(sum);

            //Average
            double average = employees.Where(x => x.YearsOfExperience <= 10 && x.Age > 35).Average(x => x.YearsOfExperience);
            Console.WriteLine(Math.Round(average));
            //TODO: Add an employee to the end of the list without using employees.Add()
            Console.WriteLine();

            var newList = employees.Append(new Employee("Super", "Mario", 42, 10));

            foreach (var item in newList)
            {
                Console.WriteLine(item.FullName);
            }

            Console.WriteLine();

            Console.ReadLine();
        }

        #region CreateEmployeesMethod
        private static List<Employee> CreateEmployees()
        {
            List<Employee> employees = new List<Employee>();
            employees.Add(new Employee("Cruz", "Sanchez", 25, 10));
            employees.Add(new Employee("Steven", "Bustamento", 56, 5));
            employees.Add(new Employee("Micheal", "Doyle", 36, 8));
            employees.Add(new Employee("Daniel", "Walsh", 72, 22));
            employees.Add(new Employee("Jill", "Valentine", 32, 43));
            employees.Add(new Employee("Yusuke", "Urameshi", 14, 1));
            employees.Add(new Employee("Big", "Boss", 23, 14));
            employees.Add(new Employee("Solid", "Snake", 18, 3));
            employees.Add(new Employee("Chris", "Redfield", 44, 7));
            employees.Add(new Employee("Faye", "Valentine", 32, 10));

            return employees;
        }
        #endregion
    }
}
