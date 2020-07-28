namespace TickTack

{
    public enum Player { None = 0, Tics, Tacks}
    public struct Square
    {
        public Player Owner {get;}

        public Square(Player owner)
        {
            this.Owner = owner;
        }
    
        public override string ToString()
        {
            switch (Owner)
            {
                case Player.None:
                    return ".";
                case Player.Ticks:
                    return "X";
                case Player.Tacks:
                    return "O";
                case default:
                    throw new Exception ("Invalid State");
            }
        }
    
    }
}