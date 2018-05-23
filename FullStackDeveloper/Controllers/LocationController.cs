using System.Diagnostics;
using Microsoft.AspNetCore.Mvc;
using Web.Models;
using Microsoft.Extensions.Configuration;

namespace Web.Controllers
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
            var model = this.client.GetLocations().Result;

            return View(model);
        }
        public IActionResult Details(int? id = null)
        {
            LocationModel model = new LocationModel(); 

            if (id != null && id > 0)
            {
                model = this.client.GetLocationDetails(id ?? 0).Result;
            }
            
            return View(model);
        }
        [HttpPost]
        public IActionResult DetailsPost(LocationModel model)
        {
            // TODO - implemet this to save the updated model and return to the summary screen

            return null;
        }
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
