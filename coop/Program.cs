using System;

namespace coop
{
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
