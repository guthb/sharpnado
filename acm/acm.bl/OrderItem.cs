namespace acm.bl
{
    public class OrderItem
    {
        public OrderItem()
        {

        }
        public OrderItem(int orderItem)
        {
            OrderItemId = orderItemId;
        }

        public int OrderItem {get; private set;}
        public int  ProductId {get; set;}
        public decimal? PurchasePrice {get; set;}
        public int Quantity {get; set;}

        // <summary>
        /// Retreive one oder.
        /// </summary>
        public OrderItem Retreive(int orderItem)
        {
            // Code that retrieve(int orderId)

            return new OrderItem();
        }

         /// <summary>
        /// Saves the current order item.
        /// </summary>
        public bool Save()
        {
            //Code that saves the order item

            return true;
        }

        /// <summary>
        /// Validates the Order Item
        /// </summary>
        /// <returns></returns>
        public bool Valdiate()
        {
            var isValid = true;

            if (Quantity <= 0) isValid = false;
            if (ProductId <= 0) isValid = false;
            if (PurchasePrice == null) isValid = false;

            return isValid;
        }


    }
}