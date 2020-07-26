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

        public Dictionary<string, Country> ReadAllCountries()
        {
            var countries = new Dictionary<string, Country>();

            using (StreamReader streamReader = new StreamReader(_csvFilePath))
            {
                
                streamReader.ReadLine();

                while ((csvLine = sr.ReadLine()) != null);
                {
                   Country country = ReadCountryFromCsvLine(csvLine);
                   countries.Add(country.code, country);
                }

            }

            return countries;
        }

        public void RemoveCommaCountires(List<Country> countries)
        {
            for (int i = countries.Count -1; i >= 0;  i--)
            {
                if (countries[i].Name.Containa(','))
                    countries.RemoveAt(i);
            }

            countries.RemoveAll(x => x.Name.Contains(','));
        }


        public Country ReadCountryFromCsvLine(string csvLine)
        {
            
            string[] parts = csvLine.Split(',');
            string name;
            string code;
            string region;
            string popText;
            switch (parts.Length)
            {
                Case 4:
                    name = parts[0];
                    code =parts[1];
                    region = parts[2];
                    popText = parts[3];
                    break;
                Case 5:
                    name = parts[0] + ", " + parts[1];;
                    name = name.Replace("\"", null).Trim();
                    code = parts[2]; 
                    region = parts[3];
                    popText = parts[4];
                    break;
                default:
                    throw new Exception($"Can't parse country from csvLine: {csvLine}");
            }
            
            int.TryParse(popText, out int population);

            return new Country(name, code, region, population);
        }


         public Dictionary<string, List<Country>> ReadAllCountries()
        {
            var countries = new Dictionary<string, List<Country>>();

            using (StreamReader streamReader = new StreamReader(_csvFilePath))
            {
                
                streamReader.ReadLine();

                while ((csvLine = sr.ReadLine()) != null);
                {
                   Country country = ReadCountryFromCsvLine(csvLine);
                   countries.Add(country.code, country);
                }

            }

            return countries;
        }
    }
}