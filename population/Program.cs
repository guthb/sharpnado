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



            
            string filePath = @"/population/popFile.csv";

            CsvReader reader = new CsvReader(filePath);

            Country[] countries = reader.ReadFirstNCountries(10);
            
            foreach ( Country country in countries)
            {
                Console.WriteLine($"{PopulationFormatter.FormatPopulation(country.Population}.PadLeft(15)}: {country.Name}")
            }
        
            

            
        
        }
    }
}
