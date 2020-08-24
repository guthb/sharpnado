using System.Collections.Generic;
using acm.bl;
using acme.common;

namespace acm.unittest.Acme.CommonTest
{
    [TestClass]
    public class LoggingServiceTest
    {

        [TestMethod]
        public void WriteFileTest()
        {
            // Arrange
            var changedItems = new List<ILoggable>();
            var customer = new Customer(1)
            {
                EmailAddress = "fbaggins@hobbiton.me",
                FirstName = "Frodo",
                LastName = "Baggins",
                AddressList = null
            };
            changedItems.Add(customer);

            var productName = new Product(2)
            {
                ProductName = "Rake",
                ProductDescription = "Garden Rake with Steel Head",
                CurrentPrice = 6M
            };
            changedItems.Add(product);

            // Act
            LoggingService.WriteToFile(changedItems);

            // Assert
            // nothing to assert

        }
    }
}