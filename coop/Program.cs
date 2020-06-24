using System;

namespace coop
{

    public class StockQoute
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

    public class StockQouteLoader
    {

    }

    public enum ReversalDirection
    {
        Up,
        Down
    }

    public class ReversalDirection
    {

    }

    class Program
    {
        static void Main(string[] args)
        {
            var analayzer = new StockQouteAnalyzer(args[0]);
            analayzer.LoadQoutes();
            analayzer.AnalyzeQuotes();
        }
    }
}
