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
        public bool ReverseDownFrom(StockQoute otherQoute) { }
        public bool ReverseUpFrom(StockQoute otherQoute) { }
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
