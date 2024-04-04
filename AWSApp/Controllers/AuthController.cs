using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace AWSApp.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AuthController : ControllerBase
    {
        [HttpGet]
        public string Get()
        {
            return "test";
        }
    }
}
