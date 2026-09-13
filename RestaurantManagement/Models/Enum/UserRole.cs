namespace RestaurantManagement.Models.Enum
{
    /// <summary>
    /// Specifies the roles available to users in the restaurant management system.
    /// </summary>
    public enum UserRole
    {
        /// <summary>
        /// A restaurant customer.
        /// </summary>
        Customer = 1,

        /// <summary>
        /// A system administrator.
        /// </summary>
        Admin = 2,

        /// <summary>
        /// A restaurant owner.
        /// </summary>
        Owner = 3
    }
}

