﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Threading;

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
            Console.WriteLine($"Sum: {numbers.Sum()}\n");

            //TODO: Print the Average of numbers
            Console.WriteLine($"Average: {numbers.Average()}\n");

            //TODO: Order numbers in ascending order and print to the console
            var ordered = numbers.OrderBy(x => x).ToList();
            Console.Write("Ordered: ");
            Methods.PrintCommaed(ordered);

            //TODO: Order numbers in decsending order and print to the console
            var orderedDescending = numbers.OrderByDescending(x => x).ToList();
            Console.Write("\nOrdered by descending: ");
            Methods.PrintCommaed(orderedDescending);

            //TODO: Print to the console only the numbers greater than 6
            var aboveSix = numbers.Where(x => x > 6).ToList();
            Console.Write("\nIntegers above six: ");
            Methods.PrintCommaed(aboveSix);

            //TODO: Order numbers in any order (acsending or desc) but only print 4 of them **foreach loop only!**
            var fourInts = numbers.OrderBy(x => x).Take(4).ToList();
            Console.Write("\nFour integers: ");
            Methods.PrintCommaed(fourInts);

            //TODO: Change the value at index 4 to your age, then print the numbers in decsending order
            int[] intsWithAge = new int[10];
            Array.Copy(numbers, intsWithAge, 10);
            intsWithAge[4] = 32;
            var ageAndNumbers = intsWithAge.OrderByDescending(x => x).ToList();
            Console.Write("\nAge and integers in descending order: ");
            Methods.PrintCommaed(ageAndNumbers);

            // List of employees ****Do not remove this****
            var employees = CreateEmployees();

            //TODO: Print all the employees' FullName properties to the console only if their FirstName starts with a C OR an S and order this in ascending order by FirstName.
            var employeesC_S = employees.Where(x => x.FirstName[0] == 'C' || x.FirstName[0] == 'S').OrderBy(x => x.FirstName).ToList();
            Console.WriteLine("\nNames of employees that start with a C or an S:");
            Employee.PrintNames(employeesC_S);

            //TODO: Print all the employees' FullName and Age who are over the age 26 to the console and order this by Age first and then by FirstName in the same result.
            var over26 = employees.Where(x => x.Age >= 26).OrderBy(x => x.Age).ThenBy(x => x.FirstName).ToList();
            Console.WriteLine("\nEmployees over 26:");
            Employee.PrintNamesAndAge(over26);

            //TODO: Print the Sum and then the Average of the employees' YearsOfExperience if their YOE is less than or equal to 10 AND Age is greater than 35
            var empsToSum = employees.Where(x => x.YearsOfExperience < 10).Where(x => x.Age >= 35).ToList();
            int sum = 0;
            foreach (var emp in empsToSum) sum += emp.YearsOfExperience;
            Console.WriteLine($"\nSum of experience, employees with under ten years of experience and over 35: {sum}");
            Console.WriteLine($"Average of these employees' experience: {sum / empsToSum.Count}");

            //TODO: Add an employee to the end of the list without using employees.Add()
            Employee newGuy = new Employee("Sev", "Wallace", 20, 0);
            employees = employees.Append(newGuy).ToList();
            Console.WriteLine("\nHere is the updated list: ");
            Employee.PrintNamesAndAge(employees);

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
