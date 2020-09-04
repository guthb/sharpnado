using System;
using System.Linq;
using System.Collections.Generic;

namespace Queries
{
    class Program
    {
        static void Main(string[] args)
        {
            var movies = new List<Movie>
            {
                new Movie { Title = "The Dark Knight", Rating = 8.9f, Year =2008},
                new Movie { Title = "The Kings Speach", Rating = 8.0f, Year =2010},
                new Movie { Title = "Casablanca", Rating = 8.5f, Year =1942},
                new Movie { Title = "Star Wars V", Rating = 8.7f, Year =1980}
            };


            //extentions methods
            //var query = movies.Where(m => m.Year > 2000);

            //foreach (var movie in query)
            //{
            //    Console.WriteLine(movie.Title);
            //}

            //var query2 = movies.Filter(m => m.Year > 2000).ToList();

            //query2 = query2.Take(1);

            //foreach (var movie in query)
            //{
            //    Console.WriteLine(movie.Title);
            //}

            //var query2 = Enumerable.Empty<Movie>();

            //var query2 = movies.Where(m => m.Year > 2000).ToList();
            var query2 = movies.Where(m => m.Year > 2000)
                .OrderByDescending(m => m.Rating);


            var query3 = from movie in movies
                         where movie.Year > 2000
                         orderby movie.Rating descending
                         select movie;

            Console.WriteLine(query2.Count());
          

            var enumerator = query2.GetEnumerator();
            while (enumerator.MoveNext())
            {
                Console.WriteLine(enumerator.Current.Title);
            }


        }
    }
}
