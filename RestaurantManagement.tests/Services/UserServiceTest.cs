using Moq;
using RestaurantManagement.Controllers;
using RestaurantManagement.Models.Dto;
using RestaurantManagement.Models.Entity;
using RestaurantManagement.repository;
using RestaurantManagement.Services;
using RestaurantManagement.Services.Interface;
using RestaurantManagement.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RestaurantManagement.tests.Services
{
    [TestClass]
    /// <summary>
    /// Contains unit tests for <see cref="UserService"/> user creation behavior.
    /// </summary>
    public class UserServiceTest
    {
        private Mock<IUserRepository> _mockrepo;
        private Mock<IPasswordHasher> _mockpass;
        private UserService _userser;
        [TestInitialize]
        public void setup()
        {
            _mockrepo = new Mock<IUserRepository>();
            _mockpass = new Mock<IPasswordHasher>();
            _userser = new UserService(_mockrepo.Object,_mockpass.Object);
           
        }

        /// <summary>
        /// Verifies that a user with unique contact details is added successfully.
        /// </summary>
        [TestMethod]
        public void ValidDto()
        {
            //Arrange
            var testuser = new AddUserRequest()
            {
                Name = "aabb",
                Password = "lkiju",
                Email = "jnjnu@hh.com",
                PhoneNumber = "768099",
                BirthDate = DateTime.Parse("2000-01-01 00:00:00")
            };
            _mockrepo.Setup(e => e.EmailExists(testuser.Email)).Returns(false);
            _mockrepo.Setup(e => e.PhoneNumberExists(testuser.PhoneNumber)).Returns(false);
            _mockrepo.Setup(e => e.AddUser(It.IsAny<User>())).Returns(1);
            //ACT
            var res=_userser.Adduser(testuser);
            //Asset
            Assert.AreEqual(ValidationMessages.succes, res);
            //Assert.Fail(res);

        }

        /// <summary>
        /// Verifies that adding a user with an existing email is rejected.
        /// </summary>
        [TestMethod]
        public void DuplicateEmail()
        {
            //Arrange
            var testuser = new AddUserRequest()
            {
                Name = "aabb",
                Email = "jnjnu@hh.com",
                PhoneNumber = "768099",
                BirthDate = DateTime.Parse("2000-01-01 00:00:00")
            };
            _mockrepo.Setup(e => e.EmailExists(testuser.Email)).Returns(true);
            _mockrepo.Setup(e => e.PhoneNumberExists(testuser.PhoneNumber)).Returns(false);
            _mockrepo.Setup(e => e.AddUser(It.IsAny<User>())).Returns(1);
            //ACT
            var res = _userser.Adduser(testuser);
            //Asset
            Assert.AreEqual("Same email and phone number", res);
            //Assert.Fail(res);

        }
    }
}
