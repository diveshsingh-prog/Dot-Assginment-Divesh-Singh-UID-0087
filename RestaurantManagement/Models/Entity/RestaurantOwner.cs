using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace RestaurantManagement.Models.Entity
{
    /// <summary>
    /// Represents the relationship between a restaurant and its owner.
    /// </summary>
    public class RestaurantOwner:BaseEntity
    {
        /// <summary>
        /// Gets or sets the unique identifier of the ownership record.
        /// </summary>
        [Key] public int OwnerId { get; set; }

        /// <summary>
        /// Gets or sets the identifier of the restaurant.
        /// </summary>
        [Required] public int RestaurantId { get; set; }

        /// <summary>
        /// Gets or sets the associated restaurant.
        /// </summary>
        [ForeignKey("RestaurantId")] public  virtual Restaurant Restaurant { get; set; }

        /// <summary>
        /// Gets or sets the identifier of the owner user.
        /// </summary>
        [Required] public int UserId { get; set; }

        /// <summary>
        /// Gets or sets the associated user.
        /// </summary>
        [ForeignKey("UserId")] public virtual User User { get; set; }
    }
}
