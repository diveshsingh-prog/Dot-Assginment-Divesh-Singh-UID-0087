namespace RestaurantManagement.Constants
{
    /// <summary>
    /// Contains validation messages used by the application.
    /// </summary>
    public class ValidationMessages
    {
        /// <summary>
        /// Indicates that the email address and phone number already exist.
        /// </summary>
        public const string DuplicateEmailAndPhone = "Same email and phone number";

        /// <summary>
        /// Indicates that an operation completed successfully.
        /// </summary>
        public const string succes = "succes";
        public const string PhoneRequired = "Phone number is required.";
        public const string InvalidPhoneFormat = "Invalid phone number format. It must contain only 10 digits.";
        public const string PhoneRegexPattern = @"^\d{20}$";
    }
}