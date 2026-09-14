using RestaurantManagement.Data;
using RestaurantManagement.Models.Entity;
using System.Linq;
using RestaurantManagement.repository;

namespace RestaurantManagement.Repository
{
    /// <summary>
    /// Repository for managing user-related data access logic.
    /// </summary>
    public class UserRepository : IUserRepository
    {
        private readonly ApplicationDbContext _db;

        /// <summary>
        /// Initializes a new instance of the <see cref="UserRepository"/> class.
        /// </summary>
        /// <param name="context">The database context used to access user records.</param>
        public UserRepository(ApplicationDbContext context)
        {
            _db = context;
        }

        /// <summary>
        /// Retrieves a user by email address.
        /// </summary>
        /// <param name="email">The email to search for.</param>
        /// <returns>The matching user if found; otherwise, null.</returns>
        public User GetUser(string email)
        {
            return _db.Users.FirstOrDefault(e => e.Email == email);
        }

        /// <summary>
        /// Checks whether a user with the specified email already exists.
        /// </summary>
        /// <param name="email">The email to validate.</param>
        /// <returns>True if the email exists; otherwise, false.</returns>
        public bool EmailExists(string email)
        {
            return _db.Users.Any(e => e.Email == email);
        }

        /// <summary>
        /// Checks whether a user with the specified phone number already exists.
        /// </summary>
        /// <param name="phoneNumber">The phone number to validate.</param>
        /// <returns>True if the phone number exists; otherwise, false.</returns>
        public bool PhoneNumberExists(string phoneNumber)
        {
            return _db.Users.Any(e => e.PhoneNumber == phoneNumber);
        }

        /// <summary>
        /// Adds a new user to the database.
        /// </summary>
        /// <param name="userentity">The user entity to add.</param>
        /// <returns>The ID of the newly added user.</returns>
        public int AddUser(User userentity)
        {
            _db.Users.Add(userentity);
            _db.SaveChanges();
            return userentity.userId;
        }
    }
}