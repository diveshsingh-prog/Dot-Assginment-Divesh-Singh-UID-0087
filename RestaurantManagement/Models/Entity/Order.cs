using RestaurantManagement.Models.Enum;
using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace RestaurantManagement.Models.Entity
{
    public class Order
    {
        private const int maxaddresslength = 255;
        [Key] public int OrderId { get; set; }
        [Required] public int UserId { get; set; }
        [ForeignKey("UserId")] public User User { get; set; }
        [Required] public int RestaurantId { get; set; }
        [ForeignKey("RestaurantId")] public Restaurant Restaurant { get; set; }
        [Required][Range(0.0,Double.MaxValue)] public Decimal TotalAmount { get; set; }
        public OrderStatus Status { get; set; } = OrderStatus.Placed;
        [Required] [StringLength(maxaddresslength)] public string Address { get; set; }
         public DateTime OrderedDate { get; set; } = DateTime.Now;
        public DateTime UpdatedAt { get; set; } = DateTime.Now;
    }
}

