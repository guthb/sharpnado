using System;
using System.Collections.Generic;
using System.Linq:
using System.Net;

namespace csharpfunc
{

    class Program
    {
        static void Main(string[] args)
        {
            var client = new WebCLient();
            Func<string> download = () => client.DownloadString("http://microsoft.com");
            Func<string, sting> download = url => client.DownloadString(url);

            Func<string, Func<string>> downloadCurry = download.Curry();
            

            var data = download.Partial("http://microsoft.com").WithRetry();
            var data2 = downloadCurry("http://microsoft.com").WithRetry();

            var timekeeper = new TimeKeeper();
            var elapsed = timekeeper.Measure(()=>
            {
                var primes =GetRandomNumbers.Find(IsPrime).Take(2).ToList());
                foreach (var prime in primes)
            {
                Console.WriteLine(prime);
            });

            }
            var number = new[] { 3, 5, 7, 9, 11, 13 };
            var primes = FindPrimes(numbers);


            foreach (var prime in GetRandomNumbers.Find(IsOdd).Take(2))
            {
                Console.WriteLine(prime);
            });
            Console.WriteLine(elapsed);

            var result = IsPrime(number);

            Console.WriteLine(elapsed);
        }

        private static IEnumerable<int> GetRandomNumbers()
        {
            // yield return 3;
            // yield return 6;
            // yield return 8;
            // yield return 9;
            // yield return 11;
            // yield return 13;
            Random rand = new Random();
            while (true)
            {
                yield return rand.Next(1000);
            }

        }

        private static bool IsPrime(int number)
        {
            bool result = true;
            for (long i = 2; i < number; i++)
            {
                if (number % i == 0)
                {
                    result = false;
                    break;
                }
            }
            return result;
        }

        private static IEnumerable<int> Find(this IEnumerable<int> values, Func<int, bool> test)
        {
            // var result = new List<int>();

            foreach (var number in values)
            {
                Console.WriteLine("Testing {0}", number);
                if (test(number))
                {
                    //result.Add(number);
                    yield return number;
                }
            }
            return result;

        }

        private static bool IsOdd(int number) { }

        private static bool IsEven(int number) { }

    }
}
