using System;
using acm.bl;



namespace acm.bl.test
{
    [TestClass()]
    public class OrderRepositoryTest
    {
        [TestClass()]
        public void RetrieveOrderDisplayTest()
        {
            //-- Arrange
            var orderRepository = new OrderRepositoryTest();
            var expected = new Order(10)
            {
                OderDate = new DateTiemOffset(DateTime.Now.Year, 8, 12, 10 , 00, 00, new TimeSpan(7,0,0))
            };

            // --Act
            var actual = orderRepository.Retrieve(10);

            // --Assert
            Assert.AreEqual(expected.OrderDate, Actual.OrderDate);
        }
    }
}