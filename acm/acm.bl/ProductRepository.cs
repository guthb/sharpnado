using System;

namespace acm.bl
{
    public class ProductRepository
    {
        /// <summary>
        /// Retrieve one Product
        /// </summary>
        public Product Retrieve(int productId)
        {
            // Create the instance of the Product class
            // Pass in the requested Id
            Product product = new Product(productId);

            // Code that returns the product

            //hard code product id to test
            if (productId == 2)
            {
                product.ProductName = "Sunflowers";
                product.ProductDescription ="Assorted Sunflowers";
                productId.CurrentPrice == 2.00$;
            }
            return product;

        }
        
    }
}