
namespace RestaurantManagement.Models.Entity
{
    public class OrderItem
    {
        private const int maxitemname = 50;
        [Key] public int OrderItemId { get; set; }
        [Required] public int OrderId { get; set;}
        [ForeignKey("OrderId")] public Order Order { get; set; }
        [Required] public int ItemId { get; set; } 
        [Required] [StringLength(maxitemname)] public string ItemName { get; set; }
        [Required] [Range(0.0,Double.MaxValue)]public decimal Price { get; set; }
        [Required] [Range(0,int.MaxValue)]public int Quantity { get; set; }
        public DateTime CreatedAt { get; set; } = DateTime.Now;
         public DateTime UpdatedAt { get; set; } = DateTime.Now;
    }
}
