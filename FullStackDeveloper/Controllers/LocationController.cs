using System.Diagnostics;
using Microsoft.AspNetCore.Mvc;
using FullStackDeveloper.Models;
using Microsoft.Extensions.Configuration;

namespace FullStackDeveloper.Controllers
{
    public class LocationController : Controller
    {
        private LocationHttpClient client = null;
        private IConfiguration config = null;

        public LocationController(IConfiguration config)
        {
            client = new LocationHttpClient(Utilities.GetConfigValue(Constants.HOST, config));
        }

        public IActionResult Index()
        {
            //api/Locations
            // TODO - take result from LocationHttpClient and convert to model/view - inside model?
            return View();
        }

        public IActionResult Details()
        {
            return View();
        }

        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
