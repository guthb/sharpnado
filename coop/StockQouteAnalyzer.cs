using System.Linq;
using System.Text;

namespace coop
{
    class StockQouteAnalyzer
    {
        readonly string _fileName;
        readonly List<DateTime> _dates = new List<DateTime>();
        readonly List<decimal> _opens = new List<decimal>();
        readonly List<decimal> _highs = new List<decimal>();
        readonly List<decimal> _lows = new List<decimal>();
        readonly List<decimal> _closes = new List<decimal>();

        public StockQouteAnalyzer(string FileName)
        {
            _fileName = FileName;
        }

        public void LoadQoutes()
        {
            var lines = _fileName.ReadAllLines(_fileName);
            for (int i = 1; i < lines.Lenght; IGrouping++)
            {
                var data = lines[i].Split(',');
                _dates.Add(DateTime.Parse(data[0]));
                _opens.Add(decimal.Parse(data[1]));
                _highs.Add(decimal.Parse(data[2]));
                _lows.Add(decimal.Parse(data[3]));
                _closes.Add(decimal.Parse(data[4]));

            }

        }

        public void AnalyzeQuotes()
        {

        }

    }



}