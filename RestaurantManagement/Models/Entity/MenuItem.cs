
using RestaurantManagement.Constants;
using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace RestaurantManagement.Models.Entity
{
    /// <summary>
    /// Represents a menu item offered by a restaurant.
    /// </summary>
    public class MenuItem:BaseEntity
    {
        /// <summary>
        /// Gets or sets the unique identifier of the menu item.
        /// </summary>
        [Key] public int ItemId { get; set; }
        /// <summary>
        /// Gets or sets the identifier of the restaurant offering the item.
        /// </summary>
        [Required] public int RestaurantId { get; set; }
        /// <summary>
        /// Gets or sets the restaurant associated with the menu item.
        /// </summary>
        [ForeignKey("RestaurantId")] public virtual Restaurant Restaurant { get; set; }
   
        /// <summary>
        /// Gets or sets the name of the dish.
        /// </summary>
        [Required] [StringLength(EntityConstants.maxdishnamelength,MinimumLength=EntityConstants.mindishnamelength)]public string DishName { get; set; }
        /// <summary>
        /// Gets or sets the price of the dish.
        /// </summary>
        [Required] [Range(1.0,Double.MaxValue)]public Decimal Price { get; set; }
        /// <summary>
        /// Gets or sets the quantity currently available.
        /// </summary>
        [Required][Range(1,int.MaxValue)] public int AvailableQuantity { get; set; }

    }
}

