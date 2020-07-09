using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace collections
{
    class Program
    {
        static void Main(string[] args)
        {
            string[] daysOfTheWeek = {
                "Monday",
                "Tuesday",
                "WednesDay",
                "Thursday",
                "Friday",
                "Saturday",
                "Sunday"
            };
            // foreach (string day in daysOfTheWeek)
            // {
            //     Console.WriteLine(day);
            // }


            Console.WriteLine("WHich day do you want to display?");
            Console.Write("(Monday = 0, etc.)>");
            int iDay = int.Parse(Console.ReadLine());

            string chosenDay = daysOfTheWeek[iDay];
            Console.WriteLine($"That day is {chosenDay}");
        }
    }
}
