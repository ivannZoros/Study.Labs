using Study.Labs.Lab04.Entities;
using System;
using System.Collections.Generic;

namespace Study.Labs.Lab04.Helpers
{
    static class EmployeeHelper
    {
        public static List<Employee> FindOldestEmployee(Employee[] employees)
        {
            List<Employee> result = new List<Employee>();
            var listOfYear = new List<int>();
            foreach (var employee in employees)
            {
                int year = employee.HireYear;
                listOfYear.Add(year);
            }
            listOfYear.Sort();
            var minYear = listOfYear[0];
            foreach (var employee in employees)
            {
                if (minYear == employee.HireYear)
                {
                    result.Add(employee);
                }
            }
            return result;
        }
        public static List<Employee> FindEmployee(Employee[] employees, string post)
        {
            List<Employee> result = new List<Employee>();
            foreach (var employee in employees)
            {
                bool employeeHasPost = employee.Post.Contains(post);
                if (employeeHasPost)
                {
                    result.Add(employee);
                }
            }
            return result;
        }
        public static void PrintEmployee(Employee employee)
        {
            if (employee == null)
            {
                Console.WriteLine("������ �������� �� ����������");
            }
            else
            {
                Console.WriteLine($"������� {employee.LastName}" +
                    $"\n��� {employee.FirstName}" +
                    $"\n�������� {employee.MiddleName}" +
                    $"\n��������� {employee.Post}" +
                    $"\n����� {employee.Adress}" +
                    $"\n��� ��������������� {employee.HireYear}");
            }
        }
    }
}