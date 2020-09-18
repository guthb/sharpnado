using System;
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
            var manufacturers = ProcessManufacturers("manufactures.csv");


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




}
