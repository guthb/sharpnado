using System;
using System.Collections.Generic();
using System.Linq;
using System.Text;
using System.Threading.Tasks;

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
            Object myObject = new Object();
            Console.WriteLines($"Object: {myObject.ToString()}");
            Console.WriteLines($"Product: {product.ToString()}");
            return product;

        }
        /// <summary>
        /// Saves the current product.
        /// </summary>
        public bool Save()
        {
            var succees = true;
            if(product.HasChanges)
            {
                if(product.IsValid)
                {
                    if(product.IsNew)
                    {
                        // call stored proc
                    }
                    else
                    {
                        // call update stored prc
                    }
                }
                else
                {
                    succees = false;
                }
            }
            return succees;
        }
        
    }
}