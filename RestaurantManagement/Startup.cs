using Microsoft.IdentityModel.Tokens;
using Microsoft.Owin.Security;
using Microsoft.Owin.Security.Jwt;
using Owin;
using System;
using System.Text;
using System.Web.Http;

[assembly: Microsoft.Owin.OwinStartup(typeof(YourProject.Startup))]

namespace YourProject
{
    public class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            HttpConfiguration config = GlobalConfiguration.Configuration;

            string issuerAndAudience = "https://localhost:44384";
            string securitySecret = "gfr6dedrftyfgyuhgyugyg7f56e4sr5dtfguygyugtf";

            var secretBytes = Encoding.UTF8.GetBytes(securitySecret);
            var symmetricKey = new SymmetricSecurityKey(secretBytes);
            string base64Secret = Convert.ToBase64String(secretBytes);

            app.UseJwtBearerAuthentication(
                new JwtBearerAuthenticationOptions
                {
                    AuthenticationMode = AuthenticationMode.Active,
                    // This links it perfectly to the HostAuthenticationFilter("Bearer") in WebApiConfig!
                    AuthenticationType = "Bearer",

                    TokenHandler = new System.IdentityModel.Tokens.Jwt.JwtSecurityTokenHandler(),

                    IssuerSecurityKeyProviders = new IIssuerSecurityKeyProvider[]
                    {
                new SymmetricKeyIssuerSecurityKeyProvider(issuerAndAudience, base64Secret)
                    },

                    TokenValidationParameters = new TokenValidationParameters()
                    {
                        ValidateIssuer = true,
                        ValidIssuer = issuerAndAudience,

                        ValidateAudience = true,
                        ValidAudience = issuerAndAudience,

                        ValidateIssuerSigningKey = true,
                        IssuerSigningKey = symmetricKey,

                        ValidateLifetime = true,
                        ClockSkew = TimeSpan.Zero
                    }
                });
        }

    }
}
