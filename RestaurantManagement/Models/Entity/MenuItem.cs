
using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace RestaurantManagement.Models.Entity
{
    public class MenuItem
    {
        private const int maxdishnamelength = 50;
        [Key] public int ItemId { get; set; }
        [Required] public int RestaurantId { get; set; }
        [ForeignKey("RestaurantId")] public Restaurant Restaurant { get; set; }
   
        [Required] [StringLength(maxdishnamelength)]public string DishName { get; set; }
        [Required] [Range(0.0,Double.MaxValue)]public Decimal Price { get; set; }
        [Required][Range(0,int.MaxValue)] public int AvailableQuantity { get; set; }
         public DateTime CreatedAt { get; set; } = DateTime.Now;
         public DateTime UpdatedAt { get; set; } = DateTime.Now;

    }
}

