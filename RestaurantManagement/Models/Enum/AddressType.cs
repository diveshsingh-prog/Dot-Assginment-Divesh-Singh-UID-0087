namespace RestaurantManagement.Models.Enum
{
    /// <summary>
    /// Identifies the type of an address.
    /// </summary>
    public enum AddressType
    {
        /// <summary>
        /// A residential address.
        /// </summary>
        Home=1,

        /// <summary>
        /// A workplace address.
        /// </summary>
        Work=2,

        /// <summary>
        /// An address that does not fit another category.
        /// </summary>
        Other=3
    }
}
