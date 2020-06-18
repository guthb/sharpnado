using System;
using System.Collections.Generic;
using Extentions;
using System.Linq;


namespace Cslinq
{
    class Program
    {
        static void Main(string[] args)
        {
            MovieDB db = new MovieDB();


            IEnumerable<Movie> query =
            db.MOvies.Where(m => m.Title.StartsWith("Star")
                .OrderBy(m => m.ReleaseDate.Year));

            foreach (var movie in query)
            {
                Console.WriteLine(movie.Title);
            }


        }


        private static void QueryCites()
        {
            IEnumerable<string> cities = new[] { "Ghent", "London", "Las Vegas", "Hyderbad" };
            Func<int, int> square = x => x * x;
            Console.WriteLine(square(3));

            Func<int, int, int> add = (x, y) => x + y;
            Console.WriteLine(add(1, 3));

            Action<int> write = x => Console.WriteLine(x);
            write(square(add(1, 3)));


            IEnumerable<string> query =
                //cities.Filter((item) => item.StartsWith("L"));
                cities.Where(city => city.StartsWith("L")).OrderByDescending(city => city.Length);

            foreach (var city in query)
            {
                Console.WriteLine(city);
            }

            DateTime date = new DateTime(2020, 6, 16);

            int daysTillEndOfMonth = date.DaysToEndOfMonth();

            Console.WriteLine(daysTillEndOfMonth);
        }




        // static bool StringsThatStartWithL(string s)
        // {
        //     return s.StartsWith("L");
        // }

    }

    public static class DateUtilites
    {
        public static int DaysToEndOfMonth(this DateTime date)
        {
            return DateTime.DaysInMonth(date.Year, date.Month) - date.Day;
        }
    }

}

namespace Extentions
{

    public static class FilterExtentions
    {
        public static IEnumerable<T> Filter<T>
            (this IEnumerable<T> input,
            Func<T, bool> predicate)
        {
            foreach (var item in input)
            {
                if (predicate(item))
                {
                    yield return item;
                }
            }
        }

        //public delegate bool FilterDelegate<T>(T item);
    }









}
