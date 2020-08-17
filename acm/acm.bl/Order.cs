namespace acm.bl
{
    public class Order
    {
        public Order()
        {

        }
        public Order (int orderId)
        {
            orderId = orderId;
        }
        public int CustomerId {get; set;}
        public DateTimeOffset? OrderDate{get; set;}
        public int OrderId {get; private set;}
        public int ShippingAddressId {get; set;}

        // // <summary>
        // /// Retreive one oder.
        // /// </summary>
        // public Order Retreive(int orderId)
        // {
        //     // Code that retrieve(int orderId)

        //     return new Order();
        // }

        //  /// <summary>
        // /// Saves the current order.
        // /// </summary>
        // public bool Save()
        // {
        //     //Code that saves the order

        //     return true;
        // }

        /// <summary>
        /// Validates the Order.
        /// </summary>
        /// <returns></returns>
        public bool Valdiate()
        {
            var isValid = true;

            if (OrderDate == null) isValid = false;

            return isValid;
        }


    }
}