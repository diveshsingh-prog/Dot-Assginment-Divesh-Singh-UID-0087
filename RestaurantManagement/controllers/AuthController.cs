using RestaurantManagement.Models.Dto;
using System.Web.Http;
//using RestaurantManagement.services;
using System.Threading.Tasks;
using RestaurantManagement.Constants;
using RestaurantManagement.Services;
//using OWIN.WebApi.Controllers;
//using RestaurantManagement.Common;
using RestaurantManagement.Models;
using RestaurantManagement.Models.Dto;
using RestaurantManagement.Models.Entity;
//using RestaurantManagement.services;
using RestaurantManagement.Services;
using RestaurantManagement.Services.Interface;
using System.IdentityModel.Tokens.Jwt;
using System.Web.Http;

namespace RestaurantManagement.Controllers
{
    /// <summary>
    /// Provides authentication-related API endpoints.
    /// </summary>
    [AllowAnonymous]
    [RoutePrefix("api/auth")]
    public class AuthController : ApiController
    {
        private readonly IUserService _userService;
        private readonly ITokenService _tokenService;
        private readonly IObtainJwtService _jwtClaim;

        /// <summary>
        /// Initializes a new instance of the <see cref="AuthController"/> class.
        /// </summary>
        /// <param name="userservice">The user service used to manage users.</param>
        //public AuthController(IUserService userserice)
        //{
        //    _userService = userserice;
        //}

        public AuthController(IUserService userser, IObtainJwtService jwtclaim, ITokenService tokenService)
        {
            _userService = userser;
            _jwtClaim = jwtclaim;
            _tokenService = tokenService;
        }

        /// <summary>
        /// Registers a new user.
        /// </summary>
        /// <param name="adduser">The new user's registration details.</param>
        /// <returns>The result of the registration request.</returns>
        [HttpPost]
        [Route("signup")]
        public async Task<IHttpActionResult> Signup(AddUserRequest adduser)
        {
            await _userService.AdduserAsync(adduser);
            return Ok(ValidationMessages.succes);
        }
        [HttpPost]
        [Route("login")]
        public async Task<IHttpActionResult> Login(UserCredential login)
        {
         
            var user = await _userService.CheckUserAsync(login);

            if (user != null)
            {

                var tokenHandler = new JwtSecurityTokenHandler();
                var refreshtoken = await _tokenService.AddRefreshTokenAsync(user.UserId);
                var accesstoken = _jwtClaim.CraftJwt(user);

                _tokenService.SetRefreshTokenCookie(refreshtoken);

                return Ok(new { AccessToken = accesstoken });
            }

            return Unauthorized();
        }
        [HttpPost]
        [Route("logout")]
        public async Task<IHttpActionResult> Logout()
        {
            string currentRefreshToken = _tokenService.GetRefreshTokenFromCookie();
            _tokenService.ClearRefreshTokenCookie();
            await _tokenService.RevokedAsync(currentRefreshToken);
            return Ok(ValidationMessages.succes);
        }

        [HttpPost]
        [Route("refresh")]
        public async Task<IHttpActionResult> Refresh()
        {
            string token = _tokenService.GetRefreshTokenFromCookie();
            var tokenHandler = new JwtSecurityTokenHandler();
            var refreshtoken = await _tokenService.RefreshTheTokenAsync(token);
            var tokenDetail = await _tokenService.GetTokenDetailAsync(refreshtoken);
            var user = await _userService.GetUserAsync(tokenDetail.UserId);
            var accesstoken = _jwtClaim.CraftJwt(user);
            _tokenService.SetRefreshTokenCookie(refreshtoken);

            return Ok(new { AccessToken = accesstoken });

        }


    }
}

