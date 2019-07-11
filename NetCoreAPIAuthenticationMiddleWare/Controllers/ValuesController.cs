using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;

namespace NetCoreAPIAuthenticationMiddleWare.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ValuesController : ControllerBase
    {

        // GET api/values
        [HttpGet]
        public string Get()
        {
            return "I am a NetCoreAPIAuthenticationMiddleWare HTTP Get Method";
        }
    }
}
