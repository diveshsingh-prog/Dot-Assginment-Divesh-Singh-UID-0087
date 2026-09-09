using RestaurantManagement.Models.Enum;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace RestaurantManagement.Models.Entity
{
    public class Order
    {
        [Key] public int OrderId { get; set; }
        [Required] public int UserId { get; set; }
        [ForeignKey("UserId")] public User User { get; set; }
        [Required] public int RestaurantId { get; set; }
        [ForeignKey("RestaurantId")] public Restaurant Restaurant { get; set; }
        [Required] public Decimal TotalAmount { get; set; }
        [Required] public OrderStatus Status { get; set; } = OrderStatus.Placed;
        [Required] public string Address { get; set; }
        [Required] public DateTime OrderedDate { get; set; } = DateTime.Now;
        [Required] public DateTime UpdatedAt { get; set; } = DateTime.Now;
    }
}