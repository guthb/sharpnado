using System;

namespace csharpfunc
{

    class Program
    {
        static void Main(string[] args)
        {
            var number = new[] { 3, 5, 7, 9, 11, 13 };
            var primes = FindPrimes(numbers);


            foreach (var prime in primes)
            {
                Console.WriteLine(prime);
            }

            var result = IsPrime(number);

            Console.WriteLine(result);
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
    }
}
