using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace RestaurantManagement.Models.Entity
{
    public class Restaurant
    {
        [Key] public int RestaurantId { get; set; }
        [Required] public string Name { get; set; }
        [Required] public int AddressId { get; set; }
        [ForeignKey("AddressId")] public virtual Address Address { get; set; }
        [Required] [StringLength(255)]  [Index(IsUnique =true)] public string Email { get; set; }
        [Required][StringLength(20)] [Index(IsUnique = true)] public string PhoneNumber { get; set; }

        [Required] public Boolean IsActive { get; set; } = true;
        [Required] public DateTime CreatedAt { get; set; }= DateTime.Now;
        [Required] public DateTime UpdatedAt { get; set; }= DateTime.Now;


    }
}