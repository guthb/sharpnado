namespace population
{
    public class CsvReader
    {
        private string _csvFilePath;
        public CsvReader (string csvFilePath)
        {
            this._csvFilePath = csvFilePath;
        }

        public Country[] ReadFirstNCountries(int nCountries)
        {
            Country[] countries = new Country[10];
            return countries;
        }
    }
}