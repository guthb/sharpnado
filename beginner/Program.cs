using System;

namespace beginner
{
    class Program
    {
        static void Main(string[] args)
    {
        string venue = args[0];
        string bandArgument = ars[1];
        int bands = 0;
        if(int.TryParse( Console.WriteLine(), out bands))
        {
           Console.WriteLine(venue + " will have " + bands + " bands performing tonight!" );
        }
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
    
        Console.WriteLine("What is the name of your venue?");
        string venue = args[0]; // Sets the venue based on the command-line argument.

        Announce(venue);

        VConsole.WriteLine("What is the name of your venue?");
        Venue venue = new Venue();
        venue.Name = "The Jazz Hut";
        venue.Announce();
    }   
        static void Announce( string venue)
    {
        Console.WriteLine( venue + " will have bands performing tonight.");
        foreach(var band in Bands)
        {
            band.Announce();
        }   
    
    }

}
