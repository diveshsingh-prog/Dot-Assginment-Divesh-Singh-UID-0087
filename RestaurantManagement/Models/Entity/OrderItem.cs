
using RestaurantManagement.Constants;
using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace RestaurantManagement.Models.Entity
{
    /// <summary>
    /// Represents an item included in a customer order.
    /// </summary>
    public class OrderItem:BaseEntity
    {
        /// <summary>Gets or sets the unique identifier of the order item.</summary>
        [Key] public int OrderItemId { get; set; }
        /// <summary>Gets or sets the identifier of the associated order.</summary>
        [Required] public int OrderId { get; set;}
        /// <summary>Gets or sets the associated order.</summary>
        [ForeignKey("OrderId")] public virtual Order Order { get; set; }
        /// <summary>Gets or sets the identifier of the ordered menu item.</summary>
        [Required] public int ItemId { get; set; } 
        /// <summary>Gets or sets the name of the ordered menu item.</summary>
        [Required] [StringLength(EntityConstants.maxdishnamelength,MinimumLength =EntityConstants.mindishnamelength)] public string ItemName { get; set; }
        /// <summary>Gets or sets the price of one unit of the item.</summary>
        [Required] [Range(1.0,Double.MaxValue)]public decimal Price { get; set; }
        /// <summary>Gets or sets the quantity ordered.</summary>
        [Required] [Range(1,int.MaxValue)]public int Quantity { get; set; }
       
    }
}
