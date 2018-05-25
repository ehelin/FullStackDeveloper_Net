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
        public IActionResult Details(int? id = null, bool isEdit = false, bool isDelete = false)
        {
            LocationModel model = new LocationModel();

            if (id != null && id > 0 && isDelete != true)
            {
                model = this.client.GetLocationDetails(id ?? 0).Result;
                model.isEdit = isEdit;
            }
            else if (isDelete)
            {
                // Handle the delete
            }

            return View(model);
        }
        [HttpPost]
        public IActionResult DetailsPost(LocationModel model)
        {
            if (model != null)
            {
                if (model.isEdit)
                {
                    this.client.PutLocation(model);
                }
                else
                {
                    this.client.PostLocation(model);
                }
            }

            //PutLocation

            return RedirectToAction("Index");
        }
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
