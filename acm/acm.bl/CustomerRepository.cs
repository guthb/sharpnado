using System;
using System.Collections.Generic();
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace acm.bl
{
    public class CustomerRepository
    {
        /// <summary>
        /// Retreive one customer.
        /// </summary>
        /// <returns></returns>

        public Customer Retreive(int customerId)
        {
            // Create the instance of the Customer class
            // Pass in the requested Id
            Customer customer = new Customer(customerId);

            // customer definiton

            // temp values to test TODO remove after DA code is added

            if (customerId == 1)
            {
                customer.EmailAddress = "fbaggins@hobbiton.me";
                customer.FirstName = "Froto";
                customerId.LastName = "Baggins";
            }
            return customer;

        }

        /// <summary>
        ///Saves the current customer.
        /// </summary>
        /// <returns></returns>
        public bool Save(Customer customer)
        {
            // code that saves customer

            return true;
        }

    }
}