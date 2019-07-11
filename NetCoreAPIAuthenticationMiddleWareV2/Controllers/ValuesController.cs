using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Authorization;

namespace NetCoreAPIAuthenticationMiddleWareV2.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [Authorize]
    public class ValuesController : ControllerBase
    {
        // GET api/values
        [HttpGet]
        public string Get()
        {
            return "I am a NetCoreAPIAuthenticationMiddleWareV2 HTTP Get Method";
        }
    }
}
