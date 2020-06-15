using System;

namespace Cslinq
{
    class Program
    {
        static void Main(string[] args)
        {
            IEnumeral<string> cites = new[] { "Ghent", "London", "Las Vegas", "Hyderbad" };


            foreach (var city in cities)
            {
                Console.WriteLine(city);
            }

            DateTime date = new DateTime(2020, 6, 16);
            int daysTillEndOfMonth = date.DaysToEndOfMonth();

            Console.WriteLine(daysTillEndOfMonth);

        }
    }

    public static class DateUtilites

        public static int DaysToEndOfMonth(DateTime date)
    {
        return DateTime.DaysToEndOfMonth(date.Year, date.Month) - date.Day;
    }

}
