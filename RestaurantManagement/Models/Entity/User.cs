using RestaurantManagement.Models.Enum;
using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using RestaurantManagement.Constants;
namespace RestaurantManagement.Models.Entity
{
    /// <summary>
    /// Represents a user account in the restaurant management system.
    /// </summary>
    public class User:BaseEntity
    {
        /// <summary>Gets or sets the unique identifier of the user.</summary>
        [Key] public int userId { get; set; }
        /// <summary>Gets or sets the user's name.</summary>
        [Required] [StringLength(EntityConstants.MaxNameLength)]public string Name { get; set; }
        /// <summary>Gets or sets the user's password.</summary>
        [Required] public string Password { get; set; }
        /// <summary>Gets or sets the user's unique email address.</summary>
        [Required][StringLength(EntityConstants.MaxEmailLength)][Index(IsUnique = true)] public string Email { get; set; }
        /// <summary>Gets or sets the user's birth date.</summary>
        [Required] [Column(TypeName = "date")] public DateTime BirthDate { get; set; }
        /// <summary>Gets or sets a value indicating whether the user is active.</summary>
        public bool IsActive { get; set; } = true;
        /// <summary>Gets or sets the user's unique phone number.</summary>
        [Required][StringLength(EntityConstants.MaxPhoneNumberLength)][Index(IsUnique = true)] public string PhoneNumber { get; set; }
        /// <summary>Gets or sets the user's account balance.</summary>
        [Required][Range(typeof(decimal), "0.0", "79228162514264337593543950335")] public decimal Balance { get; set; } = 1000;

        /// <summary>Gets or sets the user's role.</summary>
        [Required] public UserRole Role { get; set; }
        /// <summary>Gets or sets the date and time when the balance was last updated.</summary>
        public DateTimeOffset BalanceUpdatedAt { get; set; } = DateTimeOffset.UtcNow;



    }
}

