using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace RestaurantManagement.Models.Entity
{
    public class RestaurantOwner
    {
        [Key] public int OwnerId { get; set; }
        [Required] public int RestaurantId { get; set; }
        [ForeignKey("RestaurantId")] public Restaurant Restaurant { get; set; }
        [Required] public int UserId { get; set; }
        [ForeignKey("UserId")] public User User { get; set; }
        [Required] public DateTime CreatedAt { get; set; } = DateTime.Now;
        [Required] public DateTime UpdatedAt { get; set; } = DateTime.Now;
    }
}