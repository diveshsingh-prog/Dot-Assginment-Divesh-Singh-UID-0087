namespace RestaurantManagement.Models.Entity
{
    public class UserAddress
    {
        [Key] public int UserAddressId { get; set; }
        [Required] public int UserId { get; set; }
        [ForeignKey("UserId")] public User User { get; set; }
        [Required] public int AddressId { get; set; }
        [ForeignKey("AddressId")] public Address Address { get; set; }
    }
}
