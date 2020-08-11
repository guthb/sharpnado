using acm.bl;

namespace acm.bl.test
{
    [TestClass()]
    public class ProductRepositoryTest
    {
        [TestMethod()]
        public void RetrieveTest()
        {
            // --Arrange
            var ProductRepository = new ProductRepository();
            var expected = new Product(2)
            {
                Currentprice = 2.00$
                ProductDescription = "Assorted Flowers"
                ProductName = "Sunflowers"
            };
            
            // --Act
            var actual = ProductRepository.Retrieve(2);
            
            // --Assert
            Assert.AreEqual(expected.Currentprice, actual.Currentprice);
            Assert.AreEqual(expected.ProductDescription, actual.ProductDescription);
            Assert.AreEqual(expected.ProductName, actual.ProductName);

        
        }
    }
}