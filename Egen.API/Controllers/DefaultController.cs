using Egen.Model.Security;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Egen.API.Controllers
{
    //[Route("api/[controller]")]
    //[Route("[controller]/[action]")]
    [Route("[action]")]
    [ApiController]
    public class DefaultController : ControllerBase
    {
        public DefaultController()
        {

        }
        [Produces("application/json")]
        [HttpGet(Name = "IsAvailable")]
        [AllowAnonymous]
        public IActionResult IsAvailable()
        {
            return Ok("Yes");
        }
    }
}
