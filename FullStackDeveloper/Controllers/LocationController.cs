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
        public IActionResult Details(int id = 0, bool isEdit = false)
        {
            LocationModel model = new LocationModel();

            if (id == 0 && !isEdit) {
                model.isNew = true;
            }
            else if (id > 0)
            {
                model = this.client.GetLocationDetails(id).Result;
                model.isEdit = isEdit;
            }

            return View(model);
        }
        public IActionResult Delete(int id)
        {
            string result = this.client.DeleteLocation(id).Result;
            EvaluateResult(result);
            return RedirectToAction("Index");
        }
        [HttpPost]
        public IActionResult DetailsPost(LocationModel model)
        {
            string result = string.Empty;

            if (model != null)
            {
                if (model.isEdit)
                {
                    result = this.client.PutLocation(model).Result;
                }
                else
                {
                    result = this.client.PostLocation(model).Result;
                }
            }

            EvaluateResult(result);

            return RedirectToAction("Index");
        }
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }

        private void EvaluateResult(string result)
        {
            bool dataPosted = System.Convert.ToBoolean(result);
            if (!dataPosted)
            {
                throw new System.Exception("There was an error using the API");
            }
        }
    }
}
