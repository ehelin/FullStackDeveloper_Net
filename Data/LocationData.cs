using System;
using System.Collections.Generic;
using System.Linq;
using Microsoft.AspNetCore.Mvc;
using Data.Models;
using Data;

namespace Data
{
    public class LocationData : ILocationData
    {
        private MyAwesomeDatabaseContext dbContext = null;

        public LocationData()
        {
            dbContext = new MyAwesomeDatabaseContext();
        }

        public bool Delete(int id)
        {
            var location = dbContext.Location.FirstOrDefault(x => x.LocationiId == id);
            var locationDetails = dbContext.LocationDetails.FirstOrDefault(x => x.LocationId == id);

            dbContext.Attach(locationDetails);
            dbContext.Remove(locationDetails);
            dbContext.SaveChanges();

            dbContext.Attach(location);
            dbContext.Remove(location);
            dbContext.SaveChanges();

            return true;
        }

        public Location GetLocation(int id)
        {
            var location = dbContext.Location.FirstOrDefault(x => x.LocationiId == id);
            location.LocationDetails = dbContext.LocationDetails.FirstOrDefault(x => x.LocationId == id);

            return location;
        }

        public List<Location> GetLocations()
        {
            return dbContext.Location.ToList();
        }

        public bool SaveLocation(Location location)
        {
            dbContext.Location.Add(location);
            dbContext.SaveChanges();

            return true;
        }

        public bool UpdateLocation(Location location)
        {
            var existingLocation = dbContext.Location.FirstOrDefault(x => x.LocationiId == location.LocationiId);
            existingLocation.LocationDetails = dbContext.LocationDetails.FirstOrDefault(x => x.LocationId == location.LocationiId);

            existingLocation.LocationName = location.LocationName;
            existingLocation.LocationDetails.Food = location.LocationDetails.Food;
            existingLocation.LocationDetails.People = location.LocationDetails.People;
            existingLocation.LocationDetails.Weather = location.LocationDetails.Weather;

            dbContext.Location.Update(existingLocation);
            dbContext.SaveChanges();

            return true;
        }
    }
}
