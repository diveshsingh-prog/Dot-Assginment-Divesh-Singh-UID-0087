using Microsoft.Extensions.DependencyModel;
using Moq;
using RestaurantManagement.Common;
using RestaurantManagement.Controllers;
using RestaurantManagement.Models.Dto;
using RestaurantManagement.Models.Entity;
using RestaurantManagement.repository;
using RestaurantManagement.services;
using RestaurantManagement.Services;
using System.Text.Json;
using System.Web.Http.Results;
using System.Web.UI.WebControls.WebParts;
using static Microsoft.ApplicationInsights.MetricDimensionNames.TelemetryContext;

namespace RestaurantManagement.tests.Controller
{
    /// <summary>
    /// Contains unit tests for user authentication and registration operations.
    /// </summary>
    [TestClass]
    public class AuthControllerTest
    {
        /// <summary>
        /// Provides context for the current test run.
        /// </summary>
        public TestContext TestContext { get; set; }

        /// <summary>
        /// Mock user service used by the controller under test.
        /// </summary>
        private Mock<IUserService> _mockser;

        /// <summary>
        /// Controller instance being tested.
        /// </summary>
        private AuthController _signup;

        /// <summary>
        /// Creates the mocked service and controller before each test.
        /// </summary>
        [TestInitialize]
        public void setup()
        {
            _mockser = new Mock<IUserService>();
            _signup = new AuthController(_mockser.Object);
        }

        /// <summary>
        /// Verifies that a user is created when all submitted details are valid.
        /// </summary>
        [TestMethod]
        public void all_correct_detail()
        {
            //ARRANGE
            var incominguser = new AddUserRequest()
            {
                Name = "DIVESH",
                Email = "divesh@gmail.com",
                Password = "123234@aA",
                PhoneNumber = "1232334299",
                BirthDate = DateTime.Parse("2000-01-01 00:00:00")
            };

            _mockser.Setup(r => r.Adduser(incominguser)).Returns(ValidationMessages.succes);

            //ACT
            var response = _signup.Signup(incominguser);
            //ASSERT
            //if (response as CreatedNegotiatedContentResult<AddUserRequest>!=null)
            //{
            //    Assert.Fail(response.Meassage);
            //}
            var createdResult = response as CreatedNegotiatedContentResult<AddUserRequest>;
            //Assert.Fail(createdResult);
            //Assert.Fail($"Name was: {createdResult==null}");
            Assert.IsNotNull(createdResult, ValidationMessages.succes);
            Assert.AreEqual("DIVESH", createdResult.Content.Name);
        }

        /// <summary>
        /// Verifies that an invalid email produces a model-state error response.
        /// </summary>
        [TestMethod]
        public void Invalidemail()
        {
            //ARRANGE
            var incominguser = new AddUserRequest()
            {
                Name = "DIVESH",
                Email = "divesgmail.com",
                Password = "123234@aA",
                PhoneNumber = "12323342",
                BirthDate = DateTime.Parse("2000-01-01 00:00:00")
            };
            _signup.ModelState.AddModelError("Email","Email is invalid");
            //ACT
            var response = _signup.Signup(incominguser);


            //ASSERT
            var badRequestResult = response as InvalidModelStateResult;
            Assert.IsNotNull(badRequestResult);
        }
        [TestMethod]
        public void EmailExists()
        {
            //ARRANGE
            var incominguser = new AddUserRequest()
            {
                Name = "DIVESH",
                Email = "divesh@gmail.com",
                Password = "123234@aA",
                PhoneNumber = "1232334299",
                BirthDate = DateTime.Parse("2000-01-01 00:00:00")
            };

            _mockser.Setup(r => r.Adduser(incominguser)).Returns(ValidationMessages.DuplicateEmailAndPhone);

            //ACT
            var response = _signup.Signup(incominguser);
            //ASSERT
            var BadResult = response as BadRequestErrorMessageResult;
            Assert.IsNotNull(BadResult, ValidationMessages.DuplicateEmailAndPhone);
        }




    }
}
