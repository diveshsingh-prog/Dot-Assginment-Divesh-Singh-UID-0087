using RestaurantManagement.Constants;
using RestaurantManagement.Models.Enum;
using System;
using System.ComponentModel.DataAnnotations;


namespace RestaurantManagement.Models.Entity
{
    /// <summary>
    /// Represents a postal address associated with an entity.
    /// </summary>
    public class Address:BaseEntity
    {
        /// <summary>
        /// Gets or sets the unique identifier for the address.
        /// </summary>
        [Key] public int AddressId { get;set; }

        /// <summary>
        /// Gets or sets the street portion of the address.
        /// </summary>
        [Required][StringLength(EntityConstants.maxstreetlength,MinimumLength =EntityConstants.minstreetlength)] public string Street{ get; set; }

        /// <summary>
        /// Gets or sets the city portion of the address.
        /// </summary>
        [Required] [StringLength(EntityConstants.maxcitylength,MinimumLength =EntityConstants.mincitylength)] public string City { get; set; }

        /// <summary>
        /// Gets or sets the state or province portion of the address.
        /// </summary>
        [Required] [StringLength(EntityConstants.maxstatelength,MinimumLength =EntityConstants.minstatelength)]public string State { get; set; }

        /// <summary>
        /// Gets or sets the postal or PIN code.
        /// </summary>
        [Required] [StringLength(EntityConstants.maxpincodelength,MinimumLength =EntityConstants.minpincodelength)]public string PinCode { get; set; }

        /// <summary>
        /// Gets or sets the type of address.
        /// </summary>
        [Required] public AddressType AddressType { get; set; }
  
    }
}
