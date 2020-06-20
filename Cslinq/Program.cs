using System;
using System.Collections.Generic;
using Extentions;
using System.Linq;
using System.Dynamic;


namespace Cslinq
{


    class Program
    {
        static void Main(string[] args)
        {
            //MovieDB db = new MovieDB();


            // IEnumerable<Movie> query =
            // db.Movies.Where(m => m.Title.StartsWith("Star")
            //     .OrderBy(m => m.ReleaseDate.Year));


            //comprehension query syntax

            // var query2 =
            //     from m in db.Movies
            //     where m.Title.StartsWith("L")
            //     select m;

            //changed to query2 from query
            // foreach (var movie in query2)
            // {
            //     Console.WriteLine(movie.Title);
            // }

            // WorkWithFuncs();

            //object o = GetASpeaker();

            //o.GetType().GetMethod("Speak").Invoke(o, null);  //reflection?

            //dynamic
            // dynamic o = GetASpeaker();
            // o.Speak();

            dynamic expando = new ExpandoObject();
            expando.Name = "John";
            expando.Speak = new Action(() => Console.WriteLine(expando.Name));

            //expando.Speak();

            foreach (var member in expando)
            {
                Console.WriteLine(member.Key);
            }
        }

        private static void AutomateExcel()
        {
            Type excelType = Type.GetTypeFromProgID("Excel.Application");

            dynamic excel = Activator.CreateInstance(excelType);
            excel.Visible = true;

            excel.Workbooks.Add();

            dynamic sheet = excel.ActiveSheet;

            // Process[] processes = Process.GetProcesses();

            // for (int i = 0; i < processes.Length; i++)
            // {
            //     sheet.Cells[i + 1, "A"] = processes[i].ProcessName;
            //     sheet.Cells[i + 1, "B"] = processes[i].Threads.Count;
            // }
        }

        private static object GetASpeaker()
        {
            return new Employee { FirstName = "John" };
        }


        private static void QueryCites()
        {
            IEnumerable<string> cities = new[] { "Ghent", "London", "Las Vegas", "Hyderbad" };

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

        // private static void WorkWithFuncs()
        // {
        //     Expression<Func<int, int>> square = x => x * x;
        //     //Func<int, int> square = x => x * x;
        //     Console.WriteLine(square(3));

        //     Func<int, int, int> add = (x, y) => x + y;
        //     Console.WriteLine(add(1, 3));

        //     Action<int> write = x => Console.WriteLine(x);
        //     //write(square(add(1, 3)));
        // }




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
