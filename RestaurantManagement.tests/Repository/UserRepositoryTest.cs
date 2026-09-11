using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using RestaurantManagement;
using RestaurantManagement.Data;
using RestaurantManagement.Models.Entity;
using RestaurantManagement.Models.Enum;
using RestaurantManagement.Repository;
using System;
using System.Collections.Generic;
using System.Data.Common;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web.UI.WebControls;
using Effort;



namespace RestaurantManagement.tests.Repository
{
    [TestClass]
    public class UserRepositoryTest
    {
        private ApplicationDbContext _context;
        private UserRepository _userrepo;


        [TestInitialize] 
        public void setup()
        {
            DbConnection connection = Effort.DbConnectionFactory.CreateTransient();
            _context = new ApplicationDbContext(connection);
            _userrepo = new UserRepository(_context);


        }
        [TestMethod]
        public void CheckEmailIsPresent()
        {
            var testUser = new User
            {
                Email = "divesh@gmail.com",
                Name = "DIVESH",
                Password="89hubh",
                PhoneNumber = "0i09896",
                BirthDate = DateTime.Parse("2002-01-01 00:00:00"),
                Balance = 1000,
                Role = UserRole.Customer
            };

            _context.Users.Add(testUser);
            _context.SaveChanges();
            var result = _userrepo.CheckEmailIsPresent("divesh@gmail.com");
            Assert.IsTrue(result);
        }
        [TestMethod]
        public void CheckPhoneNumberIsPresent()
        {
            var testUser = new User
            {
                Email = "divesh@gmail.com",
                Name = "DIVESH",
                Password = "89hubh",
                PhoneNumber = "0309896",
                BirthDate = DateTime.Parse("2002-01-01 00:00:00"),
                Balance = 1000,
                Role = UserRole.Customer
            };

            _context.Users.Add(testUser);
            _context.SaveChanges();
            var result = _userrepo.CheckPhoneNumberIsPresent("0309896");
            Assert.IsTrue(result);
        }
        [TestMethod]
        public void CheckPhoneNumberIsNotPresent()
        {
            var testUser = new User
            {
                Email = "divesh@gmail.com",
                Name = "DIVESH",
                Password = "89hubh",
                PhoneNumber = "0309896",
                BirthDate = DateTime.Parse("2002-01-01 00:00:00"),
                Balance = 1000,
                Role = UserRole.Customer
            };

            _context.Users.Add(testUser);
            _context.SaveChanges();
            var result = _userrepo.CheckPhoneNumberIsPresent("030996");
            Assert.IsFalse(result);
        }

        [TestMethod]
        public void CheckEmailsNotPresent()
        {
            var testUser = new User
            {
                Email = "divesh@gmail.com",
                Name = "DIVESH",
                Password = "89hubh",
                PhoneNumber = "0309896",
                BirthDate = DateTime.Parse("2002-01-01 00:00:00"),
                Balance = 1000,
                Role = UserRole.Customer
            };

            _context.Users.Add(testUser);
            _context.SaveChanges();
            var result = _userrepo.CheckPhoneNumberIsPresent("new@example.com");
            Assert.IsFalse(result);
        }
        [TestMethod]
        public void Adduser()
        {
            var testUser = new User
            {
                Email = "divesh@gmail.com",
                Name = "DIVESH",
                Password = "89hubh",
                PhoneNumber = "0309896",
                BirthDate = DateTime.Parse("2002-01-01 00:00:00"),
                Balance = 1000,
                Role = UserRole.Customer
            };
            _userrepo.AddUser(testUser);
            var result = _userrepo.GetUser("divesh@gmail.com");
            Assert.AreEqual(testUser, result);
        }

        [TestMethod]
        public void AdduserInvalid()
        {
            var testUser = new User
            {
                
                Name = "DIVESH",
                Password = "89hubh",
                PhoneNumber = "0309896",
                BirthDate = DateTime.Parse("2002-01-01 00:00:00"),
                Balance = 1000,
                Role = UserRole.Customer
            };
            var result=_userrepo.AddUser(testUser);
            Assert.AreEqual("Plz check the db connection, Error in DB", result);
        }


    }
}
