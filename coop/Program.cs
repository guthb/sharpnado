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

    class StockQouteAnalyzer
    {
        private readonly StockQuoteLoader _loader;
        private readonly List<StockQuote> _quotes;



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
    }
}
