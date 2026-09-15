using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims; // Make sure this is present
using System.Text;
using Microsoft.IdentityModel.Tokens;
using RestaurantManagement.Models.Entity;
using RestaurantManagement.Services.Interface;

namespace RestaurantManagement.Services
{
    public class ObtainJwtService : IObtainJwtService
    {
        public string CraftJwt(User user)
        {
            string key = "gfr6dedrftyfgyuhgyugyg7f56e4sr5dtfguygyugtf";
            var issuer = "https://localhost:44384";

            var securityKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(key));
            var credentials = new SigningCredentials(securityKey, SecurityAlgorithms.HmacSha256);

            // FIX: Map using standard framework claim types so the security engine registers the identity
            var permClaims = new List<Claim>
            {
                new Claim(JwtRegisteredClaimNames.Jti, Guid.NewGuid().ToString()),
                new Claim(ClaimTypes.NameIdentifier, user.UserId.ToString()), // Standard User ID Claim
                new Claim(ClaimTypes.Role, user.Role.ToString())             // Standard Role Claim
            };

            var token = new JwtSecurityToken(
                issuer: issuer,
                audience: issuer,
                claims: permClaims,
                expires: DateTime.UtcNow.AddMinutes(15),
                signingCredentials: credentials);

            return new JwtSecurityTokenHandler().WriteToken(token);
        }
    }
}
