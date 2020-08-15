using System;
using System.Collections.Generic();
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace acm.bl
{
    public class AddressRepository
    {
        /// <summary>
        /// Retrieve one address
        /// </sumary>
        public Address Retrieve(int addressId);

        // Code that retrieves the defined address

        // hardcode to return address

        if (aaddressId == 1)
        {
            address.AddressId = 1;
            address.StreetLine1 ="Bag End";
            address.StreetLine2 = "Bagshot row";
            address.City = "Hobbiton";
            address.State="Shire";
            address.Country ="middle Earth";
            address.PostalCode = "114";
        }
        return address;

    }

    public IEnumerable<Address> RetriveByCustomerId(int CustomerId)
    {
        // code that retrieves defined addresses

        // hard code test data
        var addressList = new List<Address>();
        Address address = new Address(1);
        {
            AddressType = 1,
            StreetLine1 ="Bag End";
            StreetLine2 = "Bagshot row";
            City = "Hobbiton";
            State="Shire";
            Country ="middle Earth";
            PostalCode = "114";
        }
        addressList.Add(address);

        address = new Address(2)
        {
            AddressType = 2,
            StreetLine1 ="Green Dragon";
            StreetLine2 = "Bywater";
            City = "Hobbiton";
            State="Shire";
            Country ="middle Earth";
            PostalCode = "146";
        }
        addressList.Add(address);
        return addressList;
    }


    /// <summary>
        ///Saves the current address.
        /// </summary>
        /// <returns></returns>
        public bool Save(Address address)
        {
            // code that saves address

            return true;
        }
}