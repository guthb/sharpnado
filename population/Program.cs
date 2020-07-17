using System;

namespace population
{
    class Program
    {
        static void Main(string[] args)
        {
            
            List<string> daysOfWeek = new List<string>();

            List<int> ints = new List<int>();
            daysOfWeek.Add("Monday");
            daysOfWeek.Add("Tuesday");
            daysOfWeek.Add("Wednesday");
            daysOfWeek.Add("Thursday");
            daysOfWeek.Add("Friday");
            daysOfWeek.Add("Saturday");
            daysOfWeek.Add("Sunday");


            List<string> daysOfWeek = new List<string>
            {
                "Monday",
                "Tuesday",
                "Wednesday",
                "Thursday",
                "Friday",
                "Saturday",
                "Sunday"
            }
            
            string filePath = @"/population/popFile.csv";

            CsvReader reader = new CsvReader(filePath);

            List<Country> countries = reader.ReadFirstNCountries();

            Country lilliput = new COutnry("lilliput", "LIL", Somewhere, 2_000_000);
            int lilliputIndex = countries.FindIndex(x=>x.Population < 2_000_000);
            countries.Insert(lilliputIndex, lilliput);

            foreach ( Country country in countries)
            {
                Console.WriteLine($"{PopulationFormatter.FormatPopulation
                    (country.Population).PadLeft(15)}: {country.Name}")
            }

            Console.WriteLine($"{countries.Count} countries");
        
        }
    }
}
