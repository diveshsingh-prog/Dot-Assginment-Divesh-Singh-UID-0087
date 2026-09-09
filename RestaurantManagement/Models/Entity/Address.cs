using RestaurantManagement.Models.Enum;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Security.Cryptography;
using System.Web;

namespace RestaurantManagement.Models.Entity
{
    public class Address
    {
        [Key] public int AddressId { get;set; }

        [Required] public string Street{ get; set; }
        [Required] public string City { get; set; }
        [Required] public string State { get; set; }
        [Required] public string PinCode { get; set; }
        [Required] public AddressType AddressType { get; set; }
        [Required] public DateTime CreatedAt { get; set; } = DateTime.Now;
        [Required] public DateTime UpdatedAt { get; set; }= DateTime.Now;
    }
}