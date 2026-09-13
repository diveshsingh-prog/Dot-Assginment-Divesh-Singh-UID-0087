using RestaurantManagement.Constants;
using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace RestaurantManagement.Models.Entity
{
    /// <summary>
    /// Represents a restaurant registered in the system.
    /// </summary>
    public class Restaurant:BaseEntity
    {
        /// <summary>
        /// Gets or sets the unique identifier of the restaurant.
        /// </summary>
        [Key] public int RestaurantId { get; set; }

        /// <summary>
        /// Gets or sets the restaurant name.
        /// </summary>
        [Required] [StringLength(EntityConstants.maxnamelength)]public string Name { get; set; }

        /// <summary>
        /// Gets or sets the identifier of the restaurant's address.
        /// </summary>
        [Required] public int AddressId { get; set; }

        /// <summary>
        /// Gets or sets the restaurant's address.
        /// </summary>
        [ForeignKey("AddressId")] public virtual Address Address { get; set; }

        /// <summary>
        /// Gets or sets the unique email address of the restaurant.
        /// </summary>
        [Required] [StringLength(EntityConstants.maxemaillength)]  [Index(IsUnique =true)] public string Email { get; set; }

        /// <summary>
        /// Gets or sets the unique phone number of the restaurant.
        /// </summary>
        [Required][StringLength(EntityConstants.maxphonenumberlength)] [Index(IsUnique = true)] public string PhoneNumber { get; set; }

        /// <summary>
        /// Gets or sets a value indicating whether the restaurant is active.
        /// </summary>
        public bool IsActive { get; set; } = true;


    }
}

