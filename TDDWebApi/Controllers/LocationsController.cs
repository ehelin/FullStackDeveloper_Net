using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Data.Models;
using Data;

namespace TDDWebApi.Controllers
{
    [Produces("application/json")]
    [Route("api/Locations")]
    public class LocationsController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }

        //[HttpGet]
        //public List<Location> GetLocations()
        //{
        //    throw new NotImplementedException();
        //}
    }
}