using System;

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
            select user;
        }
    }
}
