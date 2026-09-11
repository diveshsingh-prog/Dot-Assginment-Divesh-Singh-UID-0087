using RestaurantManagement.Models.Enum;


namespace RestaurantManagement.Models.Entity
{
    public class Address
    {
        private const int maxstreetlength= 100;
        private const int maxcitylength = 50;
        private const int maxstatelength = 50;
        private const int maxpincodelength = 30;

        [Key] public int AddressId { get;set; }

        [Required][StringLength(maxstreetlength)] public string Street{ get; set; }
        [Required] [StringLength(maxcitylength)] public string City { get; set; }
        [Required] [StringLength(maxstatelength)]public string State { get; set; }
        [Required] [StringLength(maxpincodelength)]public string PinCode { get; set; }
        [Required] public AddressType AddressType { get; set; }
         public DateTime CreatedAt { get; set; } = DateTime.Now;
        public DateTime UpdatedAt { get; set; }= DateTime.Now;
    }
}
