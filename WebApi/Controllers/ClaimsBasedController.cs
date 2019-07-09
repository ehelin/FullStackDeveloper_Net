using System;
using System.Collections.Generic;
using System.Linq;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authorization;

namespace WebApi.Controllers
{
    [Produces("application/json")]
    [Route("api/claims")]
    //[Authorize(Policy = "MinimumAgeRequirement")]
    public class ClaimsBasedController : Controller
    {
        // GET: api/ClaimsBased
        [HttpGet]
        public string Get()
        {
            return "I am a claims based get";
        }
    }
}
