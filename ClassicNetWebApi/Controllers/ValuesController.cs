using System.Web.Http;

namespace ClassicNetWebApi.Controllers
{
    [ApiAuthorizationFilter]
    public class ValuesController : ApiController
    {
        // GET api/values
        public string Get()
        {
            return "I am a classic .net get method";
        }
    }
}
