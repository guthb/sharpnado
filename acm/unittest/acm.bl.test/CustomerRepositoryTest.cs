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
    }
}