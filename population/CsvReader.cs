using System;

namespace population
{
    public class CsvReader
    {
        private string _csvFilePath;
        public CsvReader (string csvFilePath)
        {
            this._csvFilePath = csvFilePath;
        }

        public List<Country> ReadAllCountries()
        {
            List<Country> countries = new List<Country>();

            using (StreamReader streamReader = new StreamReader(_csvFilePath))
            {
                
                streamReader.ReadLine();

                while ((csvLine = sr.ReadLine()) != null);
                {
                   
                    countries.Add(ReadCountryFromCsvLine(csvLine));
                }

            }

            return countries;
        }


        public Country ReadCountryFromCsvLine(string csvLine)
        {
            string[] parts = csvLine.Split(new char[] {','});
            string name = parts[0];
            string code =parts[1];
            string region = parts[2];
            int population = int.Parse(parts[3]);

            return new Country(name, code, region, population);
        }
    }
}