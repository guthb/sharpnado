using System;
using Linq;

namespace linq
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Hello World!");
        }

        public void GetUserRecords()
        {
            var users = new string[] { "Emily", "Jacob", "Thomas" };

            var userQuery =
            from user in users
            where user.Contains("m")
            orderby user.Length ascending

            select user;

            //userQuery.Count();

            foreach (var user in userQuery)
            {
                Console.WriteLine(user);
            }

            var userQuery2 =
            from user in users
            group user by user.Length into userGroup
            select userGroup;

            foreach (var userGroup in userQuery2)
            {
                Console.WriteLine("{0} characters long", userGroup.Key);
                foreach (var item in userGroup)
                {
                    Console.WriteLine(user);
                }
            }
            
            
            )
        
        
        }
    }
}
