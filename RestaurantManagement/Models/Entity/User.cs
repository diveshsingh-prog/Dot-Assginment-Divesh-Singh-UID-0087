using RestaurantManagement.Models.Enum;
using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using RestaurantManagement.Constants;
namespace RestaurantManagement.Models.Entity
{
    public class User:BaseEntity
    {
        [Key] public int userId { get; set; }
        [Required] [StringLength(EntityConstants.maxnamelength)]public string Name { get; set; }
        [Required][StringLength(EntityConstants.maxpasswordlength,MinimumLength =EntityConstants.minpasswordlength)] public string Password { get; set; }
        [Required][StringLength(EntityConstants.maxemaillength)][Index(IsUnique = true)] public string Email { get; set; }
        [Required] [Column(TypeName = "date")] public DateTime BirthDate { get; set; }
        public bool IsActive { get; set; } = true;
        [Required][StringLength(EntityConstants.maxphonenumberlength)][Index(IsUnique = true)] public string PhoneNumber { get; set; }
        [Required][Range(0.0, Double.MaxValue)] public decimal Balance { get; set; } = 1000;

        [Required] public UserRole Role { get; set; }
        public DateTimeOffset Balance_Updated_At { get; set; } = DateTimeOffset.UtcNow;



    }
}

