using RestaurantManagement.Constants;
using RestaurantManagement.Models.Enum;
using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace RestaurantManagement.Models.Entity
{
    /// <summary>
    /// Represents a restaurant order placed by a user.
    /// </summary>
    public class Order:BaseEntity
    {
        /// <summary>
        /// Gets or sets the unique identifier of the order.
        /// </summary>
        [Key] public int OrderId { get; set; }

        /// <summary>
        /// Gets or sets the identifier of the user who placed the order.
        /// </summary>
        [Required] public int UserId { get; set; }

        /// <summary>
        /// Gets or sets the user who placed the order.
        /// </summary>
        [ForeignKey("UserId")] public virtual User User { get; set; }

        /// <summary>
        /// Gets or sets the identifier of the restaurant fulfilling the order.
        /// </summary>
        [Required] public int RestaurantId { get; set; }

        /// <summary>
        /// Gets or sets the restaurant fulfilling the order.
        /// </summary>
        [ForeignKey("RestaurantId")] public virtual Restaurant Restaurant { get; set; }

        /// <summary>
        /// Gets or sets the total monetary amount of the order.
        /// </summary>
        [Required][Range(1.0,Double.MaxValue)] public Decimal TotalAmount { get; set; }

        /// <summary>
        /// Gets or sets the current status of the order.
        /// </summary>
        public OrderStatus Status { get; set; } = OrderStatus.Placed;

        /// <summary>
        /// Gets or sets the delivery address for the order.
        /// </summary>
        [Required] [StringLength(EntityConstants.maxaddresslength,MinimumLength =EntityConstants.minaddresslength)] public string Address { get; set; }
    }
}

