
namespace acm.bl.test
{
    [TestClass]
    public class CustomerRepositoryTest
    {
        [TestMethod]
        public void RetrieveValid()
        {
            // --Arrange
            var CustomerRepository = new CustomerRepository();
            var expected = new Customer()
            {
                customerId = 1,
                EmailAddress = "fbaggins@hobbiton.me",
                FirstName = "Frodo",
                LastName = "Baggins"
            };
            // --Act

            // --Assert

        }
    }
}