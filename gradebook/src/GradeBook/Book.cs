using System;
using System.Collections.Generic;

namespace GradeBook
{
    public class Book
    {
        public Book(string name)
        {
            grades = new List<double>();
            Name = name; //lowercase parameter
        }

        public void AddGrade(double grade)
        {

            if (grade <= 100 && grade >= 0)
            {
                grades.Add(grade);
            }
            else
            {
                Console.WriteLine("Invalid value");
            }


        }

        public Statistics GetStatistics()
        {
            var result = new Statistics();
            result.Average = 0.0;
            result.High = double.MinValue;
            result.Low = double.MaxValue;

            var index = 0;
            for (int i = 0; i < grades.Count; i++)
            {
                result.Low = Math.Min(grades[index], result.Low);
                result.High = Math.Max(grades[index], result.High);
                result.Average += grades[index];

            }

            result.Average /= grades.Count;

            return result;

        }

        //field
        private List<double> grades;
        public string Name; //Public members are upper case
    }
}