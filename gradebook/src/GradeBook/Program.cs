using System;
using System.Collections.Generic;

namespace GradeBook
{
    class Program
    {
        static void Main(string[] args)
        {
            var book = new Book("big old gradebook");
            // book.AddGrade(89.1);
            // book.AddGrade(90.5);
            // book.AddGrade(77.5);
            var done = false;

            while (!done)
            {
                Console.WriteLine("Enter a grade or 'q' to quit");
                var input = Console.ReadLine();
                if (input == "q")
                {
                    done = true;
                    continue;
                }

                var grade = double.Parse(input);
                book.AddGrade(grade);



            }

            var stats = book.GetStatistics();



            Console.WriteLine($"The lowest grade is {stats.Low:N1}");
            Console.WriteLine($"The highest grade is {stats.High:N1}");
            Console.WriteLine($"The average grade is {stats.Average:N1}");
            Console.WriteLine($"The letter grade is {stats.Letter}");

        }
    }
}
