
using RestaurantManagement.Constants;
using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace RestaurantManagement.Models.Entity
{
    public class OrderItem:BaseEntity
    {
        [Key] public int OrderItemId { get; set; }
        [Required] public int OrderId { get; set;}
        [ForeignKey("OrderId")] public virtual Order Order { get; set; }
        [Required] public int ItemId { get; set; } 
        [Required] [StringLength(EntityConstants.maxdishnamelength,MinimumLength =EntityConstants.mindishnamelength)] public string ItemName { get; set; }
        [Required] [Range(1.0,Double.MaxValue)]public decimal Price { get; set; }
        [Required] [Range(1,int.MaxValue)]public int Quantity { get; set; }
       
    }
}
