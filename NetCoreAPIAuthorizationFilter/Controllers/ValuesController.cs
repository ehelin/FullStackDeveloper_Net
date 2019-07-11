using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;

namespace NetCoreAPIAuthorizationFilter.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [ApiAuthorizationFilter]
    public class ValuesController : ControllerBase
    {
        // GET api/values
        [HttpGet]
        public string Get()
        {
            return "I am a NetCoreAPIAuthorizationFilter HTTP Get Method";
        }
    }
}
