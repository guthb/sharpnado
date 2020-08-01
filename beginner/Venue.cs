namespace beginner
{
    public class Venue
    {
        public string name;

        public void AddBand(string name)
    {
        Band band = new Band();
        band.Name = name;
        Bands[0] = band;
    }
    

    public Band[] bands = new Band[2];

    public List<Band> Bands = new List<Band>();
        public void Announce()
        {
            Console.WriteLine(name + " will have bands performing tonight.");    
        }

    }

}