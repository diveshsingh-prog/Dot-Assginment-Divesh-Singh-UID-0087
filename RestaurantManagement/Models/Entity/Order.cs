using RestaurantManagement.Constants;
using RestaurantManagement.Models.Enum;
using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace RestaurantManagement.Models.Entity
{
    public class Order:BaseEntity
    {
      
        [Key] public int OrderId { get; set; }
        [Required] public int UserId { get; set; }
        [ForeignKey("UserId")] public virtual User User { get; set; }
        [Required] public int RestaurantId { get; set; }
        [ForeignKey("RestaurantId")] public virtual Restaurant Restaurant { get; set; }
        [Required][Range(1.0,Double.MaxValue)] public Decimal TotalAmount { get; set; }
        public OrderStatus Status { get; set; } = OrderStatus.Placed;
        [Required] [StringLength(EntityConstants.maxaddresslength,MinimumLength =EntityConstants.minaddresslength)] public string Address { get; set; }
    }
}

