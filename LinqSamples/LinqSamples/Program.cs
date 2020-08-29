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
            //Employee[] developers = new Employee[]
            IEnumerable<Employee> developers = new Employee[]
                {
                    new Employee { Id = 1, Name ="Bill"},
                    new Employee { Id =2, Name = "Fred"}


                };

            //List<Employee> sales = new List<Employee>()
            IEnumerable<Employee> sales = new List<Employee>()
            {
                new Employee { Id =3, Name = "Alex"}
            };


            Console.WriteLine(developers.Count());
            IEnumerator<Employee> enumerator = developers.GetEnumerator();
            while (enumerator.MoveNext())
            {
                Console.WriteLine(enumerator.Current.Name);
            }


        }
    }
}
