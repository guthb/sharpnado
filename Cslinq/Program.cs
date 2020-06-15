using System;

namespace Cslinq
{
    class Program
    {
        static void Main(string[] args)
        {
            IEnumeral<string> cites = new[] { "Ghent", "London", "Las Vegas", "Hyderbad" };


            foreach (var city in cities)
            {
                Console.WriteLine(city);
            }
        }
    }
}
