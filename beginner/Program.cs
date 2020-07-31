using System;

namespace beginner
{
    class Program
    {
        sstatic void Main(string[] args)
    {
        string venue = args[0];
        string bandArgument = ars[1];
        int bands = 0;
        if(int.TryParse( Console.WriteLine(), out bands))
        {
           Console.WriteLine(venue + " will have " + bands + " bands performing tonight!" );
        }
        // else if ()
        // {

        // } 
        else
        {
            Console.WriteLine("we are unable to determine the number of bands performing tonight, try again.");
                
        } 
        if (bands == 0)
        {
            Console.WriteLine("There will be no performances tonight.");
        }  
        else if (bands == 1)
        {
            
            Console.WriteLine("It's going to be a fantastic show tonight!");
        }
        else
        {
            Console.WriteLine("There will be plenty of thrilling performances to see tonight!");
    }
    
    
    }
}
