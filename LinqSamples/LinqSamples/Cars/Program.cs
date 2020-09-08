﻿using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Cars
{
    class Program
    {
        static void Main(string[] args)
        {
            var cars = ProcessFile("fuel.csv");

            var query = cars.OrderByDescending(c => c.Combined)
                            .ThenBy(c => c.Name);

            foreach (var car in query.Take(10))
            {
                Console.WriteLine($"{car.Name} : {car.Combined}");
            }


            var query2 =
                (from car in cars
                 where car.Manufacturer == "BMW" && car.Year == 2016
                 orderby car.Combined descending, car.Name ascending
                 select car).First();

            var top =
                cars.Where(c => c.Manufacturer == "BMW" && c.Year == 2016)
                    .OrderByDescending(c => c.Combined)
                    .ThenBy(c => c.Name)
                    .Select(c => c)
                    .First();

            Console.Write(top.Name);

            foreach (var car in query.Take(10))
            {
                Console.WriteLine($"{car.Name} : {car.Combined}");
            }
        }

        //extention method syntax
        private static List<Car> ProcessFile(string path)
        {
            return
            File.ReadAllLines(path)
                .Skip(1)
                .Where(line => line.Length > 1)
                .Select(Car.ParseFromCsv)
                .ToList();

        }

        //query syntax
        private static List<Car> ProcessFile2(string path)
        {
            var query =
            from line in File.ReadAllLines(path).Skip(1)
            where line.Length > 1
            select Car.ParseFromCsv(line);


            return query.ToList();
        }

    }
}
