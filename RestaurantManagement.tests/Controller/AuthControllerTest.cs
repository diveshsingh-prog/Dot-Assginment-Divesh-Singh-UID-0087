using Microsoft.Extensions.DependencyModel;
using Moq;
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
using System.Threading.Tasks;
using RestaurantManagement.Constants;

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
        public async Task all_correct_detail()
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

            _mockser.Setup(r => r.AdduserAsync(incominguser)).ReturnsAsync(ValidationMessages.succes);

            //ACT
            var response = await _signup.Signup(incominguser);
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
        public async Task EmailExists()
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

            _mockser.Setup(r => r.AdduserAsync(incominguser)).ReturnsAsync(ValidationMessages.DuplicateEmailAndPhone);

            //ACT
            var response = await _signup.Signup(incominguser);
            //ASSERT
            var BadResult = response as BadRequestErrorMessageResult;
            Assert.IsNotNull(BadResult, ValidationMessages.DuplicateEmailAndPhone);
        }




    }
}
