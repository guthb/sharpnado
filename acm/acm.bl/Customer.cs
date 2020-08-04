namespace acm.bl
{
    public class Customer
    {
        
        public int CustomerId {get; private set;}
        
        public string EmailAddress {get; set;}
        
        public string FirstName {get; set;}

        public string FullName
        {
            get
                {
                    return LastName + "," + FirstName;
                }
        }
        
        private string _lastName;      
        public string _lastName
        {
            get
            {
                return _LastName;
            }
            set
            {
                _lastName = value;
            }
        }

    }
}