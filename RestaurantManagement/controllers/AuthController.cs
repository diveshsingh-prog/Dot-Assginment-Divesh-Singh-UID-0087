using RestaurantManagement.Models.Dto;
using System.Web.Http;
using RestaurantManagement.services;
using RestaurantManagement.Common;

namespace RestaurantManagement.Controllers
{
    /// <summary>
    /// Provides authentication-related API endpoints.
    /// </summary>
    [RoutePrefix("api")]
    public class AuthController : ApiController
    {
        private readonly IUserService _userservice;

        /// <summary>
        /// Initializes a new instance of the <see cref="AuthController"/> class.
        /// </summary>
        /// <param name="userser">The user service used to manage users.</param>
        public AuthController(IUserService userser)
        {
            _userservice = userser;
        }

        /// <summary>
        /// Registers a new user.
        /// </summary>
        /// <param name="adduser">The new user's registration details.</param>
        /// <returns>The result of the registration request.</returns>
        [HttpPost]
        [Route("signup")]
        public IHttpActionResult Signup(AddUserRequest adduser)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState); 
            }
            //System.Diagnostics.Debug.WriteLine(adduser);
            var res = _userservice.Adduser(adduser);
                if (res.Equals(ValidationMessages.succes))
                {
                    return Created(ValidationMessages.succes,adduser);
                }
                else
                {
                    return BadRequest(res);
                  
                }
             }
        }
    }

