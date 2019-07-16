using System;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Authorization;
using Microsoft.Extensions.Configuration;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Text;
using System.Security.Claims;
using System.Collections.Generic;

namespace NetCoreAPIJwtAuthentication.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TokenController : ControllerBase
    {
        private IConfiguration _config;

        public TokenController(IConfiguration config)
        {
            _config = config;
        }

        [AllowAnonymous]
        [HttpPost]
        public string Get(Login login)
        {
            var tokenString = GenerateJSONWebToken(login.tokenDataPoint);
            return tokenString;
        }
               
        private string GenerateJSONWebToken(string tokenDataPointValue = "")
        {
            var securityKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_config["Jwt:Key"]));
            var credentials = new SigningCredentials(securityKey, SecurityAlgorithms.HmacSha256);

            var claims = new List<Claim>();

            // meant to work (it does)
            claims.Add(new Claim("MyAwesomeClaim", "MyAwesomeClaimValue"));
            claims.Add(new Claim("MyAwesomeClaimDataPoint", tokenDataPointValue));

            //claims.Add(new Claim("MyAwesomeClaim", "MyAwesomeClaimValueWrong"));// meant to not work (it does)

            var token = new JwtSecurityToken(_config["Jwt:Issuer"],
              _config["Jwt:Issuer"],
              claims,
              expires: DateTime.Now.AddMinutes(120),
              signingCredentials: credentials);

            token.Payload["myJsonWebTokenDataPointObject"] = new {
                tokenDataPoint1 = "value 1",
                tokenDataPoint2 = "value 2",
                tokenDataPoint3 = tokenDataPointValue,
            };

            return new JwtSecurityTokenHandler().WriteToken(token);
        }
    }
}
