using RestaurantManagement.Models.Enum;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace RestaurantManagement.Models.Entity
{
    public class User
    {
        [Key] public int userId { get; set; }
        [Required] public string Name { get; set; }
        [Required] public string Password { get; set; }
        [Required][StringLength(255)][Index(IsUnique = true)] public string Email { get; set; }
        [Required] [Column(TypeName = "date")] public DateTime BirthDate { get; set; }
        [Required] public Boolean IsActive { get; set; } = true;
        [Required][StringLength(20)][Index(IsUnique = true)] public string PhoneNumber { get; set; }
        [Required] public Decimal Balance { get; set; }

        [Required] public UserRole Role { get; set; }
        [Required] public DateTime CreatedAt { get; set; } = DateTime.Now;
        [Required] public DateTime UpdatedAt { get; set; } = DateTime.Now;
        [Required] public DateTime Balance_Updated_At { get; set; } = DateTime.Now;



    }
}