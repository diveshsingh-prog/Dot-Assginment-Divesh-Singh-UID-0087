
using RestaurantManagement.Constants;
using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace RestaurantManagement.Models.Entity
{
    public class MenuItem:BaseEntity
    {
        [Key] public int ItemId { get; set; }
        [Required] public int RestaurantId { get; set; }
        [ForeignKey("RestaurantId")] public virtual Restaurant Restaurant { get; set; }
   
        [Required] [StringLength(EntityConstants.maxdishnamelength,MinimumLength=EntityConstants.mindishnamelength)]public string DishName { get; set; }
        [Required] [Range(1.0,Double.MaxValue)]public Decimal Price { get; set; }
        [Required][Range(1,int.MaxValue)] public int AvailableQuantity { get; set; }

    }
}

