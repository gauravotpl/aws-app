using AWSApp.Common.Interfaces;
using AWSApp.Common.Models;
using AWSApp.Models.Auth;
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

        public string GenerateToken(UserManager user)
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
                    new Claim("userid", user.userid.ToString()),
                    new Claim("Password", user.PASSWORD.ToString()),
                    new Claim("TokenPage", user.TokenPage.ToString()),
                    new Claim("AreaName", user.AreaName.ToString()),
                    new Claim("dist_Eng", user.dist_Eng.ToString()),
                    new Claim("dist_Hindi", user.dist_Hindi.ToString()),
                    new Claim("ApiUrl", user.ApiUrl.ToString()==null?"":user.ApiUrl.ToString()),
                    new Claim("houseid", user.houseid.ToString() == null ? "" : user.houseid.ToString()),
                    new Claim("cccd", user.cccd.ToString()==null?"":user.cccd.ToString()),
                    new Claim("Opername", user.Opername.ToString()==null?"":user.Opername.ToString()),
                    new Claim("id", user.id.ToString()==null?"":user.id.ToString()),
                    new Claim("mobileno", user.mobileno.ToString()==null?"":user.mobileno.ToString()),
                    new Claim("email", user.email.ToString()==null?"":user.email.ToString()),
                    new Claim("USER_TYPE", user.USER_TYPE.ToString()==null?"":user.USER_TYPE.ToString()),
                    new Claim("crdate", user.crdate.ToString()==null?"":user.crdate.ToString()),
                    new Claim("useronoff", user.useronoff.ToString()==null?"":user.useronoff.ToString()),
                    new Claim("loginattempt", user.loginattempt.ToString()==null?"":user.loginattempt.ToString()),
                    new Claim("photo", user.photo.ToString()==null?"":user.photo.ToString()),
                    new Claim("ccnm", user.ccnm.ToString()==null?"":user.ccnm.ToString()),
                    new Claim("Distcode", user.Distcode.ToString()==null?"":user.Distcode.ToString()),
                    new Claim("AreaType", user.AreaType.ToString()==null?"":user.AreaType.ToString()),
                    new Claim("Dashname", user.Dashname.ToString()==null?"":user.Dashname.ToString()),
                    new Claim("LjsId", user.LjsId.ToString()==null?"":user.LjsId.ToString()),
                    new Claim("EE", user.EE.ToString()==null?"":user.EE.ToString()),
                    new Claim("EE_English", user.EE_English.ToString()==null?"":user.EE_English.ToString()),
                    new Claim("EE_Hindi", user.EE_Hindi.ToString()==null?"":user.EE_Hindi.ToString()),
                    new Claim("EmpCode", user.EmpCode.ToString()==null?"":user.EmpCode.ToString()),
                    new Claim("Oldcase", user.Oldcase.ToString()==null?"":user.Oldcase.ToString()),
                    new Claim("RevTrackng", user.RevTrackng.ToString()==null?"":user.RevTrackng.ToString())
                }),
                Expires = DateTime.Now.AddMinutes(30),
                SigningCredentials = new SigningCredentials(new SymmetricSecurityKey(key), SecurityAlgorithms.HmacSha256Signature)
            };
            var token = tokenHandler.CreateToken(tokenDescriptor);
            return tokenHandler.WriteToken(token);
        }

        public UserManager GetTokenDetails(HttpContext cntx)
        {
            IEnumerable<Claim> claims = cntx.User.Claims;

            return new UserManager()
            {
                userid = claims.FirstOrDefault(x => x.Type == "userid").Value,
                PASSWORD = claims.FirstOrDefault(x => x.Type == "Password").Value,
                TokenPage = claims.FirstOrDefault(x => x.Type == "TokenPage").Value,
                AreaName = claims.FirstOrDefault(x => x.Type == "AreaName").Value,
                dist_Eng = claims.FirstOrDefault(x => x.Type == "dist_Eng").Value,
                dist_Hindi = claims.FirstOrDefault(x => x.Type == "dist_Hindi").Value,
                ApiUrl = claims.FirstOrDefault(x => x.Type == "ApiUrl").Value,
                houseid = claims.FirstOrDefault(x => x.Type == "houseid").Value,
                
            };
        }

        public JsonModel ExecuteToken(UserManager content, HttpContext cntx)
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
                var userId = jwtToken.Claims.First(x => x.Type == "userid").Value;

                // return user id from JWT token if validation successful
                return new JsonModel() { data=content,httpStatusCode=System.Net.HttpStatusCode.OK,message="Success"};
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
