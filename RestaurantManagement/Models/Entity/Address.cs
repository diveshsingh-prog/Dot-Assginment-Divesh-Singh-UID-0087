using RestaurantManagement.Constants;
using RestaurantManagement.Models.Enum;
using System;
using System.ComponentModel.DataAnnotations;


namespace RestaurantManagement.Models.Entity
{
    public class Address:BaseEntity
    {
     
        [Key] public int AddressId { get;set; }

        [Required][StringLength(EntityConstants.maxstreetlength,MinimumLength =EntityConstants.minstreetlength)] public string Street{ get; set; }
        [Required] [StringLength(EntityConstants.maxcitylength,MinimumLength =EntityConstants.mincitylength)] public string City { get; set; }
        [Required] [StringLength(EntityConstants.maxstatelength,MinimumLength =EntityConstants.minstatelength)]public string State { get; set; }
        [Required] [StringLength(EntityConstants.maxpincodelength,MinimumLength =EntityConstants.minpincodelength)]public string PinCode { get; set; }
        [Required] public AddressType AddressType { get; set; }
  
    }
}
