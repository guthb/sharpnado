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