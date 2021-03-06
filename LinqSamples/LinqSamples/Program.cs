﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LinqSamples
{
    class Program
    {
        static void Main(string[] args)
        {

            Func<int, int> square = x => x * x;
            Console.WriteLine(square(3));

            Func<int, int, int> add = (int x, int y) =>
            {
                int temp = x + y;
                return temp;

            };

            Action<int> write = x => Console.WriteLine(x);
            write(square(add(3,5)));


            Console.WriteLine(square(add(3,5)));

            //Employee[] developers = new Employee[]
            //IEnumerable<Employee> developers = new Employee[]
            var developers = new Employee[]
                {
                    new Employee { Id = 1, Name ="Bill"},
                    new Employee { Id =2, Name = "Fred"}
                };

            //List<Employee> sales = new List<Employee>()
            //IEnumerable<Employee> sales = new List<Employee>()
            var sales = new List<Employee>()
            {
                new Employee { Id =3, Name = "Alex"}
            };

            var query = developers.Where(e => e.Name.Length == 5)
                    .OrderByDescending(e => e.Name)
                    .Select(e => e);  //no op

            var query2 = from developer in developers
                         where developer.Name.Length == 5
                         orderby developer.Name descending
                         select developer;


            foreach (var employee in query)
            {
                Console.WriteLine(employee.Name);
            }


            foreach (var employee in developers.Where(NameStartsWithS))
            {
                Console.WriteLine(employee.Name);
            }

            foreach (var employee in developers.Where(
                delegate (Employee employee)
                {
                    return employee.Name.StartsWith("S");
                }))
            {
                Console.WriteLine(employee.Name);
            }

            //refactor to be shorter
            foreach (var employee in developers.Where(
                e => e.Name.StartsWith("S")))
            {
                Console.WriteLine(employee.Name);
            }


            foreach (var employee in developers.Where(e=>e.Name.Length == 5)
                .OrderBy(e => e.Name))
            {
                Console.WriteLine(employee.Name);
            }

            Console.WriteLine(developers.Count());

            var enumerator = developers.GetEnumerator();
            while (enumerator.MoveNext())
            {
                Console.WriteLine(enumerator);
            }

        }


        static bool NameStartsWithS(Employee employee)
        {
            return employee.Name.StartsWith("S");
        }


        //private static int Square(int arg)
        //{
        //    throw new NotFiniteNumberException();
        //}
    }
}
