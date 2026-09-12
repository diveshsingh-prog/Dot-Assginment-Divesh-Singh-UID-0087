using Moq;
using RestaurantManagement.Controllers;
using RestaurantManagement.Models.Dto;
using RestaurantManagement.Models.Entity;
using RestaurantManagement.repository;
using RestaurantManagement.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RestaurantManagement.tests.Services
{
    [TestClass]
    public class UserServiceTest
    {
        private Mock<IUserRepository> _mockrepo;
        private UserService _userser;
        [TestInitialize]
        public void setup()
        {
            _mockrepo = new Mock<IUserRepository>();
            _userser = new UserService(_mockrepo.Object);
           
        }
        [TestMethod]
        public void ValidDto()
        {
            //Arrange
            var testuser = new AddUserRequest()
            {
                Name = "aabb",
                Password="lkiju",
                Email = "jnjnu@hh.com",
                PhoneNumber = "768099",
                BirthDate = DateTime.Parse("2000-01-01 00:00:00")
            };
            _mockrepo.Setup(e => e.CheckEmailIsPresent(testuser.Email)).Returns(false);
            _mockrepo.Setup(e => e.CheckPhoneNumberIsPresent(testuser.PhoneNumber)).Returns(false);
            _mockrepo.Setup(e => e.AddUser(It.IsAny<User>())).Returns("ok");
            //ACT
            var res=_userser.Adduser(testuser);
            //Asset
            Assert.AreEqual("ok", res);
            //Assert.Fail(res);

        }
        [TestMethod]
        public void InValidDto()
        {
            //Arrange
            var testuser = new AddUserRequest()
            {
                Name = "aabb",
                Email = "jnjnu@hh.com",
                PhoneNumber = "768099",
                BirthDate = DateTime.Parse("2000-01-01 00:00:00")
            };
            _mockrepo.Setup(e => e.CheckEmailIsPresent(testuser.Email)).Returns(false);
            _mockrepo.Setup(e => e.CheckPhoneNumberIsPresent(testuser.PhoneNumber)).Returns(false);
            _mockrepo.Setup(e => e.AddUser(It.IsAny<User>())).Returns("ok");
            //ACT
            var res = _userser.Adduser(testuser);
            //Asset
            Assert.AreEqual("Error while binding", res);
            //Assert.Fail(res);

        }
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
            _mockrepo.Setup(e => e.CheckEmailIsPresent(testuser.Email)).Returns(true);
            _mockrepo.Setup(e => e.CheckPhoneNumberIsPresent(testuser.PhoneNumber)).Returns(false);
            _mockrepo.Setup(e => e.AddUser(It.IsAny<User>())).Returns("ok");
            //ACT
            var res = _userser.Adduser(testuser);
            //Asset
            Assert.AreEqual("Same email and phone number", res);
            //Assert.Fail(res);

        }
    }
}
