namespace RestaurantManagement.Models.Enum
{
    /// <summary>
    /// Defines the possible statuses of a restaurant order.
    /// </summary>
    public enum OrderStatus
    {
        /// <summary>An order has been placed.</summary>
        Placed = 1,
        /// <summary>An order has been accepted.</summary>
        Accepted = 2,
        /// <summary>An order has been rejected.</summary>
        Rejected = 3,
        /// <summary>An order has been dispatched.</summary>
        Dispatched = 4,
        /// <summary>An order is out for delivery.</summary>
        Delivery = 5,
        /// <summary>An order has been cancelled.</summary>
        Cancelled = 6


    }
}

