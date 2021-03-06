﻿using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;
using Microsoft.EntityFrameworkCore;

namespace Cars
{
    class Program
    {
        static void Main(string[] args)
        {
            var cars = ProcessFile("fuel.csv");
            var manufacturers = ProcessManufacturers("manufactures.csv");

            var records = ProcessFile("fuel.csv");

            var document = new XDocument();
            var cars1 = new XElement("Cars");

            createXml();
            QueryXml();

            //Database.SetIntializer(new DropCreateDatabaseIfModelChanges<CarDb>());  this is EF what is the Core equalent?

            InsertData();
            QueryData();


            foreach (var record in records)
            {
                var car = new XElement("Car");
                var name = new XElement("Name", record.Name);
                var combined = new XElement("Combined", record.Combined);

                car.Add(name);
                car.Add(combined);

                cars1.Add(car);
            }

            document.Add(cars);
            document.Save("fuel.xml");

            //grouping
            var query10 =
                from car in cars
                group car by car.Manufacturer.ToUpper() into manufacturer
                orderby manufacturer.Key
                select manufacturer;

            //extention syntax
            var query11 =
                cars.GroupBy(c => c.Manufacturer.ToUpper())
                .OrderBy(g => g.Key);


            foreach (var result1 in query10)
            {
                Console.WriteLine($"{result1.Key} has {result1.Count()} cars");
            }

            foreach (var group in query10)
            {

                Console.WriteLine(group.Key);
                foreach (var car in group.OrderByDescending(c=> c.Combined).Take(2))
                {
                    Console.WriteLine($"\t{car.Name}: { car.Combined}");
                }
 
            }

            var query12 =
                from manufacturer in manufacturers
                join car in cars on manufacturer.Name equals car.Manufacturer
                into carGroup
                orderby manufacturer.Name
                select new
                {
                    Manufacturer = manufacturer,
                    Cars = carGroup
                };

            var query13 =
                manufacturers.GroupJoin(cars, m => m.Name, c => c.Manufacturer, (m, g) =>
                new
                {
                    Manufacturer = m,
                    Cars = g
                })
                .OrderBy(m => m.Manufacturer.Name);

                foreach (var group in query12)
            {

                Console.WriteLine($"{group.Manufacturer.Name}:{group.Manufacturer.Headquarters}");
                foreach (var car in group.Cars.OrderByDescending(c => c.Combined).Take(2))
                {
                    Console.WriteLine($"\t{car.Name}: { car.Combined}");
                }

            }

            var query14 =
            from manufacturer in manufacturers
            join car in cars on manufacturer.Name equals car.Manufacturer
                into carGroup
            select new
            {
                Manufacturer = manufacturer,
                Cars = carGroup
            } into result5
            group result5 by result5.Manufacturer.Headquarters;

            var query15 =
                manufacturers.GroupJoin(cars, m => m.Name, c => c.Manufacturer,
                (m, g) =>
                new
                {
                    Manufacturer = m,
                    Cars = g
                })
                .GroupBy(m => m.Manufacturer.Headquarters);

            foreach (var group in query14)
            {

                Console.WriteLine($"{group.Key}");
                foreach (var car in group.SelectMany(g => g.Cars)
                    .OrderByDescending(c => c.Combined)
                    .Take(3))
                {
                    Console.WriteLine($"\t{car.Name}: { car.Combined}");
                }

            }

            var query = cars.OrderByDescending(c => c.Combined)
                            .ThenBy(c => c.Name);

            var query16 =
                from car in cars
                group car by car.Manufacturer into carGroup
                select new
                {
                    Name = carGroup.Key,
                    Max = carGroup.Max(c => c.Combined),
                    Min = carGroup.Min(c => c.Combined),
                    Avg = carGroup.Average(c => c.Combined)

                } into result16
                orderby result16.Max descending
                select result16;


            foreach (var result6 in query16)
            {

                Console.WriteLine($"{result6.Name}");
                Console.WriteLine($"{result6.Max}");
                Console.WriteLine($"{result6.Min}");
                Console.WriteLine($"{result6.Avg}");


            }

            var query17 =
                cars.GroupBy(c => c.Manufacturer)
                .Select(g =>
                {
                    var results = g.Aggregate(new CarStatistics(),
                                        (acc, c) => acc.Accumulate(c),
                                        acc => acc.Compute());

                    return new
                    {
                        Name = g.Key,
                        Avg = results.Average,
                        Min = results.Min,
                        Max = results.Max,


                    };

                })
                .OrderByDescending(r => r.Max);

            foreach(var result17 in query16)
            {

                Console.WriteLine($"{result17.Name}");
                Console.WriteLine($"{result17.Max}");
                Console.WriteLine($"{result17.Min}");
                Console.WriteLine($"{result17.Avg}");


            }

            var query5 =
                from car in cars
                where car.Manufacturer == "Bmw" && car.Year == 2016
                orderby car.Combined descending, car.Name ascending
                select new
                {
                    car.Manufacturer,
                    car.Name,
                    car.Combined
                };

            var query6 =
                from car in cars
                join manufacturer in manufacturers
                    on new { car.Manufacturer, car.Year }
                        equals
                        new { Manufacturer = manufacturer.Name, manufacturer.Year }
                orderby car.Combined descending, car.Name ascending
                select new

                {
                    manufacturer.Headquarters,
                    car.Name,
                    car.Combined
                };

            var query8 =
                cars.Join(manufacturers,
                c => new { c.Manufacturer, c.Year },
                m => new { Manufacturer = m.Name, m.Year },
                    (c, m) => new
                    { m.Headquarters,
                        c.Name,
                        c.Combined
                    });
                


            var query7 =
                cars.Join(manufacturers,
                            c => c.Manufacturer,
                            m => m.Name, (c, m) => new
                            {
                                m.Headquarters,
                                c.Name,
                                c.Combined
                            })
            .OrderByDescending(c => c.Combined)
            .ThenBy(c => c.Name);

            foreach (var car in query.Take(10))
            {
                Console.WriteLine($"{car.Name} : {car.Combined}");
            }

            foreach (var car in query6.Take(10))
            {
                Console.WriteLine($"{car.Headquarters} : {car.Name} : {car.Combined}");
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

            var top2 =
                cars
                    .OrderByDescending(c => c.Combined)
                    .ThenBy(c => c.Name)
                    .Select(c => c)
                    .First(c => c.Manufacturer == "BMW" && c.Year == 2016);

            cars.Where(c => c.Manufacturer == "BMW" && c.Year == 2016)
                    .OrderByDescending(c => c.Combined)
                    .ThenBy(c => c.Name)
                    .Select(c => c)
                    .First();

            var result =
                cars
                .Select(c => new { c.Manufacturer, c.Name, c.Combined });
           
            Console.Write(top.Name);

            foreach (var car in query.Take(10))
            {
                Console.WriteLine($"{car.Name} : {car.Combined}");
            }


            var result2 = cars.Any(c => c.Manufacturer == "Ford");
            Console.WriteLine(result2);

            var result3 = cars.All(c => c.Manufacturer == "Ford");

            Console.WriteLine(result3);

            var result4 =
                cars
                .SelectMany(c => c.Name)
                .OrderBy(c => c);
            foreach (var name in result4)
            {

                Console.WriteLine(name);
                foreach (var character in result)
                {
                    Console.WriteLine(character);
                }
            }

        }

        private static void QueryXml()
        {

            var ns = (XNamespace)"http://somecoolwebsite/neatstuff/awesomstuff";
            var ex = (XNamespace)"http://somecoolwebsite/neatstuff/awesomstuff/ex";
            var document = XDocument.Load("fuel.xml");

            var query =
                from element in document.Element(ns+ "Cars").Elements(ex + "Car") ?? Enumerable.Empty<XElement>()
                    //where element.Attribute("Manufacturer").Value == "BMW"
                where element.Attribute("Manufacturer2")?.Value == "BMW"
                select element.Attribute("Name").Value;

            foreach (var name in query)
            {
                Console.WriteLine(name);
            }
        }

        private static void createXml()
        {
            var records = ProcessFile("fuel.csv");

            var ns = (XNamespace)"http://somecoolwebsite/neatstuff/awesomstuff";
            var ex = (XNamespace)"http://somecoolwebsite/neatstuff/awesomstuff/ex";
            var document = new XDocument();
            var cars = new XElement(ns + "Cars",

                from record in records
                select new XElement(ex + "Car",
                        new XAttribute("Name", record.Name),
                        new XAttribute("Combined", record.Combined),
                        new XAttribute("Manufacturer", record.Manufacturer))


                );
        }

        private static List<Manufacturer> ProcessManufacturers(string path)
        {
        var query =
            File.ReadAllLines(path)
                .Where(l => l.Length > 1)
                .Select(l =>
                {

                    var columns = l.Split(',');
                    return new Manufacturer
                    {
                        Name = columns[0],
                        Headquarters = columns[1],
                        Year = int.Parse(columns[2])
                    };

                });
        return query.ToList();

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

                File.ReadAllLines(path)
                .Skip(1)
                .Where(l => l.Length > 1)
                .ToCar();
                //.Select(l => Car.ParseFromCsv(l));


            //from line in File.ReadAllLines(path).Skip(1)
            //where line.Length > 1
            //select Car.ParseFromCsv(line);


            return query.ToList();
        }

        //Entity and Linq
        private static void QueryData()
        {
            var db = new CarDb();

            //db.Database.Log = Console.WriteLine;  not a method on dotnet core

            var query = from car in db.Cars
                        orderby car.Combined descending, car.Name ascending
                        select car;


            foreach (var car in query.Take(10))
            {
                Console.WriteLine($"{ car.Name}: {car.Combined}");
            }

            var extentionQuery =
                    db.Cars.OrderByDescending(c => c.Combined).ThenBy(c => c.Name).Take(10);

            foreach (var car in extentionQuery)
            {
                Console.WriteLine($"{ car.Name}: {car.Combined}");
            }
        }


        private static void InsertData()
        {
            var cars = ProcessFile("fuel.csv");
            var db = new CarDb();

            //db.Database.Log = Console.WriteLine;  not a method on dotnet core

            if (!db.Cars.Any())
            {
                foreach (var car in cars)
                {
                    db.Cars.Add(car);

                }
                db.SaveChanges();
            }

        }


    }

    public static class CarExtentions
    {
        public static IEnumerable<Car> ToCar(this IEnumerable<string> source)
        {
            foreach (var line in source)
            {
                var columns = line.Split(',');

                yield return new Car
                {
                    Year = int.Parse(columns[0]),
                    Manufacturer = columns[1],
                    Name = columns[2],
                    Displacement = double.Parse(columns[3]),
                    Cylinders = int.Parse(columns[4]),
                    City = int.Parse(columns[4]),
                    Highway = int.Parse(columns[4]),
                    Combined = int.Parse(columns[7])
                };
            } 
        }
    }

    public class CarStatistics
    {

        public CarStatistics()
        {
            Max = Int32.MinValue;
            Min = Int32.MaxValue;
        }

        public CarStatistics Accumulate(Car car)
        {
            Count += 1;
            Total += car.Combined;
            Max = Math.Max(Max, car.Combined);
            Min = Math.Min(Min, car.Combined);

            return this;

        }

        public CarStatistics Compute()
        {
            Average = Total / Count;
            return this;
        }

        public int Max { get; set; }
        public int Min { get; set; }
        public int Total { get; set; }
        public int Count { get; set; }
        public double Average { get; set; }
    }




}
