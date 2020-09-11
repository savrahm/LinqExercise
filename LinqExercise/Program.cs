using System;
using System.Collections.Generic;
using System.ComponentModel;
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
             *
             * HINT: Use the List of Methods defined in the Lecture Material Google Doc ***********
             *
             * You may find that Method syntax is easier to use since it is most like C#
             * Every one of these can be completed using Linq and then printing with a foreach loop.
             * Push to your github when completed!
             * 
             */

            //Print the Sum and Average of numbers
            
            var sum = numbers.Sum();
            var avg = numbers.Average();
            Console.WriteLine($"Given an array of integers 0-9, {sum} is the sum and {avg} is the average.");

            //Order numbers in ascending order and decsending order. Print each to console.

            Console.WriteLine();
            Console.WriteLine("Numbers ascending:");
            var numbersUp = numbers.OrderBy(x => x);
            foreach (int num in numbersUp)
                Console.WriteLine(num);

            Console.WriteLine();
            Console.WriteLine("Numbers descending:");
            var numbersDown = numbersUp.Reverse();
            foreach (int num in numbersDown)
                Console.WriteLine(num);

            //Print to the console only the numbers greater than 6

            Console.WriteLine();
            Console.WriteLine($"Numbers greater than 6, ascending:");
            var bigNumbersUp = numbersUp.Where(x => x > 6);
            foreach(int num in bigNumbersUp)
                Console.WriteLine(num);

            //Order numbers in any order (acsending or desc) but only print 4 of them **foreach loop only!**

            Console.WriteLine();
            Console.WriteLine("Four even numbers:");
            foreach(int num in numbersUp.Where(x => (x > 0 && x % 2 == 0)))
                Console.WriteLine(num);

            //Change the value at index 4 to your favorite number, then print the numbers in decsending order

            Console.WriteLine();
            Console.WriteLine("Numbers in original set with a new number at index 4, descending:");
            numbers[4] = 42;
            var dontPanic = numbers.OrderByDescending(x => x);
            foreach(int num in dontPanic)
                Console.WriteLine(num);

            // List of employees ***Do not remove this***
            
            var employees = CreateEmployees();

            //Print all the employees' FullName properties to the console only if their FirstName starts with a C OR an S.
            //Order this in ascending order by FirstName.

            Console.WriteLine();
            Console.WriteLine("Employees whose first names start with C or S:");
            var cS = employees.Where(emp => emp.FirstName.ToLower()[0] == 'c' || emp.FirstName.ToLower()[0] == 's').OrderBy(emp => emp.FirstName);
            foreach(var person in cS)
                Console.WriteLine(person.FullName);

            //Print all the employees' FullName and Age who are over the age 26 to the console.
            //Order this by Age first and then by FirstName in the same result.

            Console.WriteLine();
            Console.WriteLine("Employees older than 26:");
            var empAges = employees.Where(emp => emp.Age > 26).OrderBy(emp => emp.Age).ThenBy(emp => emp.FirstName);
            foreach(var emp in empAges)
                Console.WriteLine($"{emp.FullName} - {emp.Age}");

            //Print the Sum and then the Average of the employees' YearsOfExperience
            //if their YOE is less than or equal to 10 AND Age is greater than 35
            //rounded to 2 decimal places
            
            Console.WriteLine();
            Console.WriteLine("Sum/average years of experience (employees over 35 with 10 years' experience at most):");
            var over35Under10 = employees.Where(emp => emp.YearsOfExperience <= 10 && emp.Age > 35);
            Console.WriteLine($"Sum of YOE: {over35Under10.Sum(emp => emp.YearsOfExperience)}");
            Console.WriteLine($"Average of YOE: {Math.Round(over35Under10.Average(emp => emp.YearsOfExperience), 2)}");


            //Add an employee to the end of the list without using employees.Add()

            Console.WriteLine();
            Console.WriteLine("List of all employees, plus new employee:");
            employees = employees.Append(new Employee("Buffy", "Summers", 18, 2)).ToList();
            foreach(var emp in employees)
                Console.WriteLine(emp.FullName);

            
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
