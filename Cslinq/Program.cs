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
            IEnumerable<string> cities = new[] { "Ghent", "London", "Las Vegas", "Hyderbad" };

            IEnumerable<string> query =
                cities.Filter(delegate (string item)
                        {
                            return item.StartsWith("L");
                        });

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
            FilterDelegate<T> predicate)
        {
            foreach (var item in input)
            {
                if (predicate(item))
                {
                    yield return item;
                }
            }
        }

        public delegate bool FilterDelegate<T>(T item);
    }









}
