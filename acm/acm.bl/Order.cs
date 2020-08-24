using System;
using System.Collections.Generic;
using acme.common;

namespace acm.bl
{
    public class Order : EntityBase, Iloggable
    {
        public Order() : this(0)
        {

        }
        public Order(int orderId)
        {
            orderId = orderId;
            OrderItems = new List<OrderItem>();
        }

        public int CustomerId { get; set; }
        public DateTimeOffset? OrderDate { get; set; }
        public int OrderId { get; private set; }

        public List<OrderItem> OrderItems { get; set; }
        public int ShippingAddressId { get; set; }

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

        public string Log()
        {
            $"{OrderId}: Date {this.OrderDate.Value.Date} Status: {this.EntityState.ToString()}";
        }

        public override string ToString() =>
            $"{OrderDate.Value.Date} ({OrderId})";

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