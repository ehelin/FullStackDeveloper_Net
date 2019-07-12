using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Authorization;
using System.Linq;

namespace NetCoreAPIJwtAuthentication.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ValuesTwoController : ControllerBase
    {
        // GET api/valuesTwo
        [HttpGet]
        [Authorize]                         // expecting any claim
        public string Get()
        {
            var currentUser = HttpContext.User;

            var myAwesomeClaim = currentUser.Claims.Where(p => p.Type == "MyAwesomeClaim");
            var myAwesomeClaimValue = myAwesomeClaim.FirstOrDefault().Value;

            var myAwesomeClaimDataPoint = currentUser.Claims.Where(p => p.Type == "MyAwesomeClaimDataPoint");
            var myAwesomeClaimDataPointValue = myAwesomeClaimDataPoint.FirstOrDefault().Value;

            return "I am a NetCoreAPIJwtAuthentication HTTP Get Method with no specified claim - ClaimDataPointValue: " + myAwesomeClaimDataPointValue;
        }
    }
}
