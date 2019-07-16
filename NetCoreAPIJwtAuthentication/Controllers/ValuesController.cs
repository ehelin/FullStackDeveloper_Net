using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Authorization;
using System.Linq;

namespace NetCoreAPIJwtAuthentication.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ValuesController : ControllerBase
    {
        // GET api/values
        [HttpGet]
        [Authorize(Policy = "MyAwesomeClaim")]      // expecting specific claim
        public string Get()
        {
            var currentUser = HttpContext.User;

            var myAwesomeClaim = currentUser.Claims.Where(p => p.Type == "MyAwesomeClaim");
            var myAwesomeClaimValue = myAwesomeClaim.FirstOrDefault().Value;

            // pull data out as claim value
            var myAwesomeClaimDataPoint = currentUser.Claims.Where(p => p.Type == "MyAwesomeClaimDataPoint");
            var myAwesomeClaimDataPointValue = myAwesomeClaimDataPoint.FirstOrDefault().Value;

            // pull data out as json payload object
            var myJsonWebTokenDataPoint = currentUser.Claims.Where(p => p.Type == "myJsonWebTokenDataPointObject");
            var myJsonWebTokenDataPointValue = myJsonWebTokenDataPoint.FirstOrDefault().Value;

            return "I am a NetCoreAPIJwtAuthentication HTTP Get Method with a specific claim - ClaimDataPointValue: " + myAwesomeClaimDataPointValue;
        }
    }
}
