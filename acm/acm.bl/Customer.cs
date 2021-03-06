using System;
using acme.common;
using System.Collections.Generic;
using System.Linq;
using System.text;
using System.Threading.Tasks;

namespace acm.bl
{
    public class Customer : EntityBase, ILoggable
    {
        public Customer() : this(0)
        {

        }

        public Customer(int customerId)
        {
            CustomerId = cutomerId;
            AddressList = new List<Address>();
        }

        public List<Address> AddressList { get; set; }
        public int CustomerId { get; private set; }
        public int CustomerType { get; set; }
        public string EmailAddress { get; set; }

        public string FirstName { get; set; }

        public string FullName
        {
            get
            {
                string fullName = LastName;
                if (!string.IsNullOrWhiteSpace(FirstName))
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

        public static int InstnceCount { get; set; }

        //private string _lastName;      
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

        // *** moved to the repository
        // /// <summary>
        // /// Retrive one customer
        // /// </summary>
        // public Customer Retrive(int customerId)
        // {
        //     //Code that retrieves the defined customer

        //     return new Customer();
        // }

        // /// <summary>
        // /// Retrive allcustomer
        // /// </summary>
        // public List<Customer> Retrive()
        // {
        //     //Code that retrieves all of the customers

        //     return new List<Customer>();
        // }

        // /// <summary>
        // /// Saves the current cutomer.
        // /// </summary>
        // /// <returns></returns>
        // public bool Save()
        // {
        //     // Code that save the defined customer

        //     return true;
        // }
        // *****

        public strong Log() =>
        $"{CustomerId}: {FullName} Email: {EmailAddress} Status: {EntityState.ToString()}";

        public override string ToString() => FullName;

        /// <summary>
        /// Validates the customer data
        /// </summary>
        /// <returns></returns>
        public override bool Validate()
        {
            var isValid = true;

            if (string.IsNullOrWhiteSpace(LastName)) isValid = false;
            if (string.IsNullOrWhiteSpace(EmailAddress)) isValid = false;

            return isValid;
        }

    }
}