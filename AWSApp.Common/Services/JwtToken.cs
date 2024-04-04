using AWSApp.Common.Interfaces;
using AWSApp.Common.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Configuration;
using Microsoft.IdentityModel.Tokens;
using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;

namespace AWSApp.Common.Services
{
    public class JwtToken: IJwtToken
    {
        private readonly IConfiguration _config;

        public JwtToken(IConfiguration config)
        {
            _config = config;
        }

        public string GenerateToken(JwtModel user)
        {
            var securityKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_config["Jwt:SecretKey"]));
            var credentials = new SigningCredentials(securityKey, SecurityAlgorithms.HmacSha256);

            // generate token that is valid for 7 days
            var tokenHandler = new JwtSecurityTokenHandler();
            var key = Encoding.ASCII.GetBytes(_config["Jwt:SecretKey"]);
            var tokenDescriptor = new SecurityTokenDescriptor
            {
                Subject = new ClaimsIdentity(new[]
                {
                    new Claim("Username", user.Username.ToString()),
                    new Claim("Password", user.Password.ToString()),
                    new Claim("Mobile", user.Mobile.ToString()),
                    new Claim("EmailId", user.EmailId.ToString()),
                    new Claim("FirstName", user.FirstName.ToString()),
                    new Claim("LastName", user.LastName.ToString()),
                    new Claim("DOB", user.DOB.ToString()==null?"":user.DOB.ToString()),
                    new Claim("Address", user.Address.ToString()==null?"":user.Address.ToString()),
                    new Claim("StateId", user.Address.ToString()==null?"":user.StateId.ToString()),
                    new Claim("DistrictId", user.Address.ToString()==null?"":user.DistrictId.ToString()),
                }),
                Expires = DateTime.Now.AddMinutes(30),
                SigningCredentials = new SigningCredentials(new SymmetricSecurityKey(key), SecurityAlgorithms.HmacSha256Signature)
            };
            var token = tokenHandler.CreateToken(tokenDescriptor);
            return tokenHandler.WriteToken(token);
        }

        public JwtModel GetTokenDetails(HttpContext cntx)
        {
            IEnumerable<Claim> claims = cntx.User.Claims;

            return new JwtModel()
            {
                Username = claims.FirstOrDefault(x => x.Type == "Username").Value,
                Mobile = claims.FirstOrDefault(x => x.Type == "Mobile").Value,
                EmailId = claims.FirstOrDefault(x => x.Type == "EmailId").Value,
                FirstName = claims.FirstOrDefault(x => x.Type == "FirstName").Value,
                LastName = claims.FirstOrDefault(x => x.Type == "LastName").Value,
                Address = claims.FirstOrDefault(x => x.Type == "Address").Value,
                DOB = claims.FirstOrDefault(x => x.Type == "DOB").Value,
                StateId = claims.FirstOrDefault(x => x.Type == "StateId").Value,
                DistrictId = claims.FirstOrDefault(x => x.Type == "DistrictId").Value,
            };
        }

        public JsonModel ExecuteToken(JsonModel content, HttpContext cntx)
        {

            var token = cntx.Request.Headers["Authorization"].ToString();
            var tokenHandler = new JwtSecurityTokenHandler();
            var key = Encoding.ASCII.GetBytes(_config["Jwt:SecretKey"]);
            try
            {
                tokenHandler.ValidateToken(token, new TokenValidationParameters
                {
                    ValidateIssuerSigningKey = true,
                    IssuerSigningKey = new SymmetricSecurityKey(key),
                    ValidateIssuer = false,
                    ValidateAudience = false,
                    // set clockskew to zero so tokens expire exactly at token expiration time (instead of 5 minutes later)
                    ClockSkew = TimeSpan.Zero
                }, out SecurityToken validatedToken);

                var jwtToken = (JwtSecurityToken)validatedToken;
                var userId = jwtToken.Claims.First(x => x.Type == "Username").Value;

                // return user id from JWT token if validation successful
                return content;
            }
            catch
            {
                return new JsonModel()
                {
                    httpStatusCode = System.Net.HttpStatusCode.Unauthorized,
                    message = "Invalid access token"
                };
            }
        }
    }
}
