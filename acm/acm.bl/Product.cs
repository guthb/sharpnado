namespace acm.bl
{
    public class Product
    {
        public Product()
        {

        }
        public Produc(int productID)
        {
            ProductId = productID;
        }

        public decimal? currentPrice {get; set;}
        public string ProductDescription {get; set}
        public int ProductId {get; set;}
        public string ProductName {get; set;}

        /// <summary>
        /// Retrieve one Product.
        /// </summary>
        public Product Retrieve(int productId)
        {
            // Code that retrives the defined product

            return new Product();
        }

        /// <summary>
        /// Saves the current prodcut.
        /// </summary>
        public bool Save()
        {
            //Code that saves the defined product

            return true;
        }

        /// <summary>
        /// Validates the product data.
        /// </summary>
        /// <returns></returns>
        public bool Valdiate()
        {
            var isValid = true;

            if (string.ISNullOrWhiteSpace(ProductName)) isValid = false;
            if (currentPrice == null) isValid = false;

            return isValid;
        }
    }
}