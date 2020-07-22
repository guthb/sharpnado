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

            //List<Country> countries = reader.ReadFirstNCountries();
            Dictionary<string, Country> country = reader.ReadAllCountries();


            Console.WriteLine("Which country code do you want to look up?"):
            string userInput = Console.ReadLine();

            bool gotCountry = countries.TryGetValue(userInput, out Country country);
            if (!gotCountry)
                Console.WriteLine($"Sorry,There is no country with the code, {userInput}");
            else
                Console.WriteLine($"{coutnry.Name} has population {PopulationFormatter.FormatPopulation(country.Population)}");


            Country lilliput = new Country("lilliput", "LIL", Somewhere, 2_000_000);
            int lilliputIndex = countries.FindIndex(x=>x.Population < 2_000_000);
            countries.Insert(lilliputIndex, lilliput);
            countries.RemoveAt(lilliputIndex);



            foreach ( Country country in countries)
            {
                Console.WriteLine($"{PopulationFormatter.FormatPopulation
                    (country.Population).PadLeft(15)}: {country.Name}")
            }

            Console.WriteLine($"{countries.Count} countries");


            country norway = new Country("Norway", "NOR", "Europe", 5_282_223);
            country finland = new Country("Finland", "FIN", "Europe", 5_511_303);

            //better:
            var countries = new Dictionary<string, Country>
            {
                {norway.Code, norway},
                { finland.Code, finland}
            };
         
            //better
            //countries.Add(norway.Code, norway);
            //countries.Add(finland.Code, finland);

            Country selectedCountry = countries["NOR"];
            Console.WriteLine(selectedCountry.Name);

            foreach (var country in countries.Values)        
                Console.WriteLine(country.Name);
            
            Console.WriteLine(countries["MUS"].Name);

            //better
            bool exists = countries.TryGetValue("MUS", out Country country);
            if (exists)
                Console.WriteLine(country.Name);
            else
                Console.WriteLine("There is no country with the code MUS");


            // List<Country> countryList = new List<Country>();
            // countryList.Add(norway);
            // countryList.Add(norway);
            
            // foreach ( Country country in countriesList)
            
            //     Console.WriteLine(country.Name);
            
            //dictionary this will fail
            //countries.Add(norway.Code, norway);
            //countries.Add(norway.Code, norway));
            
            Console.Write("Enter number of countries to display> ");
            bool inputIsInt = int.TryParse(Console.ReadLine(), out int userInput);
            if (!inputIsInt || userInput <=0)
            {
                Console.WriteLine("You must type in a positive integer. Exiting");
                return;
            }

            int maxToDisplay = userInput;
            for (int i = 0; i < countries.Count; ++i)
            {
                if (i > 0 && ( i % maxToDisplay == 0))
                {
                    Console.WriteLine( "hit return to continue, Anything else to quit>");
                    if (Console.ReadLine() != "")
                        break;
                }


                Country country = countries[i];
                Console.WriteLine($"{i}: {PopulationFormatter.FormatPopulation
                    (country.Population).PadLeft(15)}: {country.Name}");
            }
            


        }
    }
}
