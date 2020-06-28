using System;

namespace csharpfunc
{

    class Program
    {
        static void Main(string[] args)
        {
            var number = int.Parse(args[0]);
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
