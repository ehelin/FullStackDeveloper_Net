using System;
using System.Collections.Generic;
using System.Linq;
using Microsoft.AspNetCore.Mvc;
using Data.Models;

namespace WebApi.Controllers
{
    [Produces("application/json")]
    [Route("api/Locations")]
    public class LocationsController : Controller
    {
        private MyAwesomeDatabaseContext dbContext = null;

        public LocationsController()
        {
            dbContext = new MyAwesomeDatabaseContext();
        }

        // GET: api/Locations
        [HttpGet]
        public List<Location> GetLocations()
        {
            return dbContext.Location.ToList();
        }

        // GET: api/Locations/5
        [HttpGet("{id}", Name = "Get")]
        public Location Get(int id)
        {
            var result = dbContext.Location.FirstOrDefault(x => x.LocationiId == id);

            return result;
        }
        
        // POST: api/Locations
        [HttpPost]
        public void Post([FromBody]Location location)
        {
            var myLocation = location;
        }
        
        // PUT: api/Locations/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody]Location location)
        {
            var myLocation = location;
        }
        
        // DELETE: api/ApiWithActions/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
            var deleteId = id;
        }
    }
}
