﻿using System;
using System.Linq;
using System.Collections;
using System.Collections.Generic;


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

            //return userQuery.Count();

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
        }
        public static partial class Example
        {
            public static int GetNumbers()
            {
                var numbers = new int[] { 0, 1, 2, 3, 4, 5, 6, 7, 8, 9 };
                var query =
                from number in numbers
                orderby number ascending
                //where number > 6
                select number;

                return query;


            }

            public static void GetUsers(List<User> users)
            {
                var userQuery = from user in users
                                group user by user.Active into userGroup
                                select userGroup;

                foreach (var userGroup in userQuery)
                {
                    Console.WriteLine("Active: {0}", userGroup.Key);
                    foreach (var user in userGroup)
                    {
                        Console.WriteLine(user.Name);
                    }
                }
            }

        }
    }
}


