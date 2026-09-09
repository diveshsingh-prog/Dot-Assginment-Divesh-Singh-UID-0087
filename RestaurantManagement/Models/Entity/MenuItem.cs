using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace RestaurantManagement.Models.Entity
{
    public class MenuItem
    {
        [Key] public int ItemId { get; set; }
        [Required] public int RestaurantId { get; set; }
        [ForeignKey("RestaurantId")] public Restaurant Restaurant { get; set; }
   
        [Required] public string DishName { get; set; }
        [Required]public Decimal Price { get; set; }
        [Required] public int AvailableQuantity { get; set; }
        [Required] public DateTime CreatedAt { get; set; } = DateTime.Now;
        [Required] public DateTime UpdatedAt { get; set; } = DateTime.Now;

    }
}