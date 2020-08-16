using System;
using acm.bl;

namespace acm.bl.test
{
    [TestClass()]
    public class CustomerRepositoryTest
    {
        [TestMethod]
        public void RetrieveValid()
        {
            // --Arrange
            var CustomerRepository = new CustomerRepository();
            var expected = new Customer(1)
            {
                EmailAddress = "fbaggins@hobbiton.me",
                FirstName = "Frodo",
                LastName = "Baggins"
            };
            // --Act
            var actual = customerRepository.Retrive(1);
            
            // --Assert
            Assert.AreEqual(expected.CustmerId, actual.CustmerId);
            Assert.AreEqual(expected.EmailAddress, actual.EmailAddress);
            Assert.AreEqual(expected.FirstName, actual.FirstName);
            Assert.AreEqual(expected.LastName, actual.LastName);

        }

        [MestMethod]
        {
            // --Arange
            var customerRepository = new CustomerRepository();
            var expected = new Customer(1)
            {
                EmailAddress = "fbaggins@hobbiton.me",
                FirstName = "Frodo",
                LastName = "Baggins",
                AddressList = new List<Address>()
                {
                    new Address()
                    {
                        AddressId = 1;
                        StreetLine1 ="Bag End";
                        StreetLine2 = "Bagshot row";
                        City = "Hobbiton";
                        State="Shire";
                        Country ="middle Earth";
                        PostalCode = "114";
                    },
                    new Address()
                    {
                        AddressType = 2,
                        StreetLine1 ="Green Dragon";
                        StreetLine2 = "Bywater";
                        City = "Hobbiton";
                        State="Shire";
                        Country ="middle Earth";
                        PostalCode = "146";
                    }
                }
            }

        }
    }
}