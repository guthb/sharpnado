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
                    string fullName = LastName;
                    if ( !string.IsNullOrWhiteSpace(FirstName))
                    {
                        if (!string.IsNullOrWhiteSpace(fullName))
                        {
                            fullName += ", ";
                        }
                        fullName += FirstName;
                    }
                    return fullName;
                }
        }

        public static int InstnceCount {get; set;}
        
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

        /// <summary>
        /// Validates the customer data
        /// </summary>
        /// <returns></returns>
        public bool Validate()
        {
            var isValid = true;

            if (string.IsNullOrWhiteSpace(LastName)) isValid = false;
            if (string.IsNullOrWhiteSpace(EmailAddress)) isValid = false;

            return isValid;
        }

        /// <summary>
        /// Retrive one customer
        /// </summary>
        public Customer Retrive(int customerId)
        {
            //Code that retrieves the defined customer

            return new Customer();
        }

        /// <summary>
        /// Saves the current cutomer.
        /// </summary>
        /// <returns></returns>
        public bool Save()
        {
            // Code that save the defined customer

            return true;
        }

    }
}