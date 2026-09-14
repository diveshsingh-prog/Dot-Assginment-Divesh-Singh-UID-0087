using System;
using System.ComponentModel.DataAnnotations;

namespace RestaurantManagement.Models.Dto
{
    /// <summary>
    /// Represents the information required to create a user.
    /// </summary>
    public class AddUserRequest
    {
        /// <summary>
        /// Gets or sets the user's name.
        /// </summary>
        [Required(ErrorMessage = "Name is required.")]
        [StringLength(100, ErrorMessage = "Name cannot exceed 100 characters.")]
        public string Name { get; set; }

        /// <summary>
        /// Gets or sets the user's password.
        /// </summary>
        [Required(ErrorMessage = "Password is required.")]
        [StringLength(100, MinimumLength = 8, ErrorMessage = "The password must be at least 8 characters long.")]
        [RegularExpression(@"^(?=.*[a-z])(?=.*[A-Z])(?=.*\d)(?=.*[^\da-zA-Z]).{8,}$",
       ErrorMessage = "Password must contain an uppercase letter, lowercase letter, number, and special character.")]
        [DataType(DataType.Password)]
        public string Password { get; set; }

        /// <summary>
        /// Gets or sets the user's email address.
        /// </summary>
        [Required(ErrorMessage = "Email is required.")]
        [EmailAddress(ErrorMessage = "Invalid email format.")]
        [StringLength(100, ErrorMessage = "Email cannot exceed 100 characters.")]
        public string Email { get; set; }

        /// <summary>
        /// Gets or sets the user's birth date.
        /// </summary>
        [Required(ErrorMessage = "Birth date is required.")]
        public  DateTime BirthDate { get; set; }

        /// <summary>
        /// Gets or sets the user's phone number.
        /// </summary>
        [Required(ErrorMessage = "Phone number is required.")]
        public string PhoneNumber { get; set; }

    }
}