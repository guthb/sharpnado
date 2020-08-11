using System;

namespace acm.bl
{
    public class OrderRepository
    {
        /// <summary>
        /// Retrive one order.
        /// </summary>
        public Order Retrieve(int orderId)
        {
            Order order = new Order(orderId);
            
            // retrieves the order

            // hard-coded to return an order
            if ( orderId == 10)
            {
                // Use current year
                order.OrderDate = new DateTimeOffset(DateTime.Now.Year, 8, 11, 10, 00, 00, new TimeSpan(7, 0, 0));
            }
            return order;
        }
        /// <summary>
        /// Saves the current order.
        /// </summary>
        public bool Save()
        {
            //Code that saves the order

            return true;
        }
        

    }
}