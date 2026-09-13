using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace RestaurantManagement.Models.Entity
{
    /// <summary>
    /// Represents the association between a user and an address.
    /// </summary>
    public class UserAddress
    {
        /// <summary>
        /// Gets or sets the unique identifier for this user-address association.
        /// </summary>
        [Key] public int UserAddressId { get; set; }

        /// <summary>
        /// Gets or sets the identifier of the associated user.
        /// </summary>
        [Required] public int UserId { get; set; }

        /// <summary>
        /// Gets or sets the associated user.
        /// </summary>
        [ForeignKey("UserId")] public User User { get; set; }

        /// <summary>
        /// Gets or sets the identifier of the associated address.
        /// </summary>
        [Required] public int AddressId { get; set; }

        /// <summary>
        /// Gets or sets the associated address.
        /// </summary>
        [ForeignKey("AddressId")] public Address Address { get; set; }
    }
}
