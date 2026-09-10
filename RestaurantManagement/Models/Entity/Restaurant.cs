using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace RestaurantManagement.Models.Entity
{
    public class Restaurant
    {
        private const int maxnamelength = 50;
        private const int maxemaillength = 100;
        private const int maxphonenumberlength = 20;
        [Key] public int RestaurantId { get; set; }
        [Required] [StringLength(maxnamelength)]public string Name { get; set; }
        [Required] public int AddressId { get; set; }
        [ForeignKey("AddressId")] public virtual Address Address { get; set; }
        [Required] [StringLength(maxemaillength)]  [Index(IsUnique =true)] public string Email { get; set; }
        [Required][StringLength(maxphonenumberlength)] [Index(IsUnique = true)] public string PhoneNumber { get; set; }

         public Boolean IsActive { get; set; } = true;
         public DateTime CreatedAt { get; set; }= DateTime.Now;
         public DateTime UpdatedAt { get; set; }= DateTime.Now;


    }
}