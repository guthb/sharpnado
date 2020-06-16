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



            IEnumerable<string> query = cities.StringsThatStartWith("L");

            foreach (var city in query)
            {
                Console.WriteLine(city);
            }





            DateTime date = new DateTime(2020, 6, 16);

            int daysTillEndOfMonth = date.DaysToEndOfMonth();

            Console.WriteLine(daysTillEndOfMonth);

        }
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
        public static IEnumerable<string> StringsThatStartWith
            (this IEnumerable<string> input, string start)
        {
            foreach (var s in input)
            {
                if (s.StartsWith(start))
                {
                    yield return s;
                }
            }
        }
    }









}
