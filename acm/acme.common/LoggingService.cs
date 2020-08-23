using System;
using Sytem.Collections.Generic;
using System.Linq;
using Sytem.Text;
using System.Threading.Tasks;


namespace acme.common
{
    public static class LoggingService
    {
        public static void WriteToFile(List<Object> itemsToLog)
        {
            foreach (var itme in itemsToLog)
            {
                Console.WriteLine(item);
            }
        }
    }
}