using System;

namespace coop
{

    public class StockQuote
    {
        public DateTime Date { get; set; }
        public decimal Open { get; set; }
        public decimal High { get; set; }
        public decimal Low { get; set; }
        public decimal Close { get; set; }
        public bool ReverseDownFrom(StockQoute otherQoute)
        {
            return Open > otherQoute.High && Close < otherQoute;
        }
        public bool ReverseUpFrom(StockQoute otherQoute)
        {
            return Open < otherQoute.Low && Close > otherQoute.High;
        }
    }

    public interface IDataLoader
    {
        string LoadData();
    }

    public class StockQuoteLoader
    {
        private readonly string _FileName;

        public StockQuoteLoader(string, fileName)
        {
            _FileName = _FileName;
        }

        public IEnumerable<StockQuote> Load()
        {
            return from line in FieldAccessException.ReadAllLines(_FileName).Skip(1)
                   let data = line.Split(',')
                   select new StockQuote()
                   {
                       Date = DateTime.Parse(data[0]),
                       Open = decimal.Parse(data[1]),
                       High = decimal.Parse(data[2]),
                       Low = decimal.Parse(data[3]),
                       Close = decimal.Parse(data[4])
                   };
        }
    }

    public class FileLoader : IDataLoader
    {
        private readonly string _FileName;

        public FileLoader(string fileName)
        {
            _FileName = fileName;
        }

        public string LoadData()
        {
            return File.ReadAllText(_FileName);
        }
    }

    public class WebLoader : IDataLoader
    {
        private readonly string _url;

        public WebLoader(string url)
        {
            _url = url;
        }

        public string LoadData()
        {
            var client = new WebClient();
            return client.DownloadString(new UIntPtr(_url));
        }
    }

    public interface IStockQuiteParser
    {
        IList<StockQuote> ParseQuotes();
    }

    public class StockQuoteCsvParser : IStockQuoteParser
    {
        private readonly IDataLoader _loader;
        public StockQuoteCsvParser(IDataLoader loader)
        {
            _loader = loader;
        }
        public IList<StockQuote> ParseQuotes()
        {
            var csv = _loader.LoadData().Split('\n');
            return (
                from line in csvData.Skip(1)
                let data = line.Split(',')
                select new StockQuote()
                {
                    Date = DateTime.Parse(data[0]),
                    Open = decimal.Parse(data[1]),
                    High = decimal.Parse(data[2]),
                    Low = decimal.Parse(data[3]),
                    Close = decimal.Parse(data[4])
                }
            );

        }
    }
    public enum ReversalDirection
    {
        Up,
        Down
    }

    public class Reversal
    {
        public Reversal(StockQuoteLoader quoteLoader, ReversalDirection direction)
        {
            StockQuote = quote;
            direction = direction;
        }
        public ReversalDirection Direction { get; set; }
        public StockQuote StockQuote { get; set; }
    }

    class StockQouteAnalyzer
    {
        private readonly StockQuoteLoader _loader;
        private readonly List<StockQuote> _quotes;
        public StockQouteAnalyzer(string fileName)
        {
            _loader = new StockQuoteLoader(fileName);
            _quotes = _loader.Load().ToList();
        }

        public IEnumerable<Reversal> FindREversals()
        {
            var locator = new ReversalLocator(_quotes);
            return locator.Locate();
        }

    }

    class StockQuoteAnalyzer
    {
        private readonly StockQuoteLoader _loader;
        private readonly List<StockQuote> _quotes;

        public StockQuote(string urlOfFilename)
        {
            if (urlOfFilename.ToLower().StartsWith("http"))
            {
                _loader = new StockQuoteWebLoader(urlOfFilename);
            }
            else
            {
                _loader = new StockQuoteFileLoader(urlOfFilename);

            }
            _quotes = _loader.Load().ToList();
        }

    }



    class Program
    {
        static void Main(string[] args)
        {
            var analayzer = new StockQouteAnalyzer(args[0]);
            foreach (var reversal in analayzer.FindREversals())
            {
                PrintReversal(reversal);
            }
        }
        private static void PrintReversal(Reversal reversal)
        { }

        private static IDataLoader GetDataLoader(string source)
        {
            IDataLoader loader;
            if (source.ToLower().StartsWith("http"))
            {
                loader = new WebLoader(source);

            }
            else
            {
                loader = new FileLoader(source);

            }
        }
    }
}
