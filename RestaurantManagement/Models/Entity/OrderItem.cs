using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace RestaurantManagement.Models.Entity
{
    public class OrderItem
    {
        [Key] public int OrderItemId { get; set; }
        [Required] public int OrderId { get; set;}
        [ForeignKey("OrderId")] public Order Order { get; set; }
        [Required] public int ItemId { get; set; } 
        [Required] public string ItemName { get; set; }
        [Required] public decimal Price { get; set; }
        [Required] public int Quantity { get; set; }
        [Required] public DateTime CreatedAt { get; set; } = DateTime.Now;
        [Required] public DateTime UpdatedAt { get; set; } = DateTime.Now;
    }
}