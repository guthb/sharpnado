using System;
using Cslinq;

public class Employee
{

    public string FirstName { get; set; }

    public void Speak()
    {
        Console.WriteLine("Hi, my name is {0}", FirstName);
    }


}