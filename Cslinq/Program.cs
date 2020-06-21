using System;
using System.Collections.Generic;
using Extentions;
using System.Linq;
using System.Dynamic;
using System.Xml.Linq;


namespace Cslinq
{


    class Program
    {
        static void Main(string[] args)
        {


            dynamic doc = new DynamicXml("Employees.xml");
            foreach (var employee in doc.Employees)
            {
                Console.WriteLine(employee.FirstName);
            }






        }
        private static void ReadXmlExpando()
        {
            var doc = XDocument.Load("Employees.xml").AsExpando();
            foreach (var employee in doc.Employees)
            {
                Console.WriteLine(employee.FirstName);
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


    internal class DynamicXml : DynamicObject
    {

        private dynamic _xml;

        public DynamicXml(string fileName)
        {
            _xml = XDocument.Load(fileName);
        }

        public DynamicXml(dynamic xml)
        {
            _xml = xml;
        }


        public override bool TryGetMember(GetMemberBinder binder, out object result)
        {
            var xml = _xml.Element(binder.Name);
            if (xml != null)
            {
                result = new DynamicXml(xml);
                return true;
            }

            result = nill;
            return false;
        }


    }






}
