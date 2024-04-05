using AWSApp.Application.Logic.Interfaces.Auth;
using AWSApp.Common.Models;
using AWSApp.Models.Auth;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace AWSApp.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AuthController : ControllerBase
    {

        private IUserService _userService;
        public AuthController(IUserService userService)
        {

            _userService = userService;
        }

        [HttpPost("Login")]
        public JsonModel Loign(LoginRequest login)
        {
            return _userService.Login(login);
        }
    }
}
