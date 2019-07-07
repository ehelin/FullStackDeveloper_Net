using System;
using System.Collections.Generic;
using System.Linq;
using Microsoft.AspNetCore.Mvc;
using Data.Models;
using Data;

namespace WebApi.Controllers
{
    // TODO - add basic error handler around each web api method
    [Produces("application/json")]
    [Route("api/Locations")]
    [ApiAuthenticationFilter]
    public class LocationsController : Controller
    {
        private ILocationData locationData = null;

        public LocationsController(ILocationData locationData)
        {
            this.locationData = locationData;
        }

        // GET: api/Locations
        [HttpGet]
        public List<Location> GetLocations()
        {
            var locations = locationData.GetLocations();
            return locations;
        }

        // GET: api/Locations/5
        [HttpGet("{id}", Name = "Get")]
        public Location Get(int id)
        {
            return locationData.GetLocation(id);
        }

        // POST: api/Locations
        [HttpPost]
        public bool Post([FromBody]Location location)
        {
            return locationData.SaveLocation(location);
        }

        // PUT: api/Locations
        [HttpPut]
        public bool Put([FromBody]Location location)
        {
            return locationData.UpdateLocation(location);
        }

        // DELETE: api/Locations/5
        [HttpDelete("{id}")]
        public bool Delete(int id)
        {
            return locationData.Delete(id);
        }
    }
}
