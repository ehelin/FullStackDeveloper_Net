using System;
using System.Collections.Generic;
using System.Linq;
using Microsoft.AspNetCore.Mvc;
using Data.Models;

namespace WebApi.Controllers
{
    // TODO - add basic error handler around each web api method
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
            var location = dbContext.Location.FirstOrDefault(x => x.LocationiId == id);
            location.LocationDetails = dbContext.LocationDetails.FirstOrDefault(x => x.LocationId == id);

            return location;
        }

        // POST: api/Locations
        [HttpPost]
        public bool Post([FromBody]Location location)
        {
            dbContext.Location.Add(location);
            dbContext.SaveChanges();

            return true;
        }

        // PUT: api/Locations/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody]Location location)
        {
            var existingLocation = dbContext.Location.FirstOrDefault(x => x.LocationiId == id);
            existingLocation.LocationDetails = dbContext.LocationDetails.FirstOrDefault(x => x.LocationId == id);

            existingLocation.LocationName = location.LocationName;
            existingLocation.LocationDetails.Food = location.LocationDetails.Food;
            existingLocation.LocationDetails.People = location.LocationDetails.People;
            existingLocation.LocationDetails.Weather = location.LocationDetails.Weather;

            dbContext.Location.Update(existingLocation);
            dbContext.SaveChanges();
        }

        // DELETE: api/Locations/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
            var location = dbContext.Location.FirstOrDefault(x => x.LocationiId == id);
            var locationDetails = dbContext.LocationDetails.FirstOrDefault(x => x.LocationId == id);

            dbContext.Attach(locationDetails);
            dbContext.Remove(locationDetails);
            dbContext.SaveChanges();

            dbContext.Attach(location);
            dbContext.Remove(location);
            dbContext.SaveChanges();
        }
    }
}
