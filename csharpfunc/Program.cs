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


    }
}
