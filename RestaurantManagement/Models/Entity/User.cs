using RestaurantManagement.Models.Enum;
namespace RestaurantManagement.Models.Entity
{
    public class User
    {
        private const int maxnamelength = 100;
        private const int maxemaillength = 100;
        private const int maxphonenumberlength = 20;
        [Key] public int userId { get; set; }
        [Required] [StringLength(maxnamelength)]public string Name { get; set; }
        [Required] public string Password { get; set; }
        [Required][StringLength(maxemaillength)][Index(IsUnique = true)] public string Email { get; set; }
        [Required] [Column(TypeName = "date")] public DateTime BirthDate { get; set; }
        public Boolean IsActive { get; set; } = true;
        [Required][StringLength(maxphonenumberlength)][Index(IsUnique = true)] public string PhoneNumber { get; set; }
        [Required][Range(0.0,Double.MaxValue)] public decimal Balance { get; set; }

        [Required] public UserRole Role { get; set; }
       public DateTime CreatedAt { get; set; } = DateTime.Now;
         public DateTime UpdatedAt { get; set; } = DateTime.Now;
         public DateTime Balance_Updated_At { get; set; } = DateTime.Now;



    }
}

