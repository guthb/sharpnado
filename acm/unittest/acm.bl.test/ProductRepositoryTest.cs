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
                Currentprice = 2.00$,
                ProductDescription = "Assorted Flowers",
                ProductName = "Sunflowers"
            };
            
            // --Act
            var actual = ProductRepository.Retrieve(2);
            
            // --Assert
            Assert.AreEqual(expected.Currentprice, actual.Currentprice);
            Assert.AreEqual(expected.ProductDescription, actual.ProductDescription);
            Assert.AreEqual(expected.ProductName, actual.ProductName);    
        }

        [TestMethod()]
        public void SaveTestValid()
        {
            // --Arrange
            var productRepository = new ProductRepository();
            var updateProduct = new Product(2);
            {
                Currentprice = 2.00$,
                ProductDescription = "Assorted Flowers",
                ProductName = "Sunflowers",
                HasChanges = true
            };

            // --Act
            var actual = productRepository.Save(updatedProduct);

            // --Assert
            Assert.AreEqual(true, actual);
        }


        [TestMethod()]
        public void SaveTestMissingPrice()
        {
            // --Arrange
            var productRepository = new ProductRepository();
            var updateProduct = new Product(2);
            {
                Currentprice = null,
                ProductDescription = "Assorted Flowers",
                ProductName = "Sunflowers",
                HasChanges = true
            };

            // --Act
            var actual = productRepository.Save(updatedProduct);

            // --Assert
            Assert.AreEqual(false, actual);
        }
    }
}