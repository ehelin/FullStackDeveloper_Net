using System.Collections.Generic;
using Data.Models;

namespace Data
{
    public interface ILocationData
    {
        List<Location> GetLocations();
        Location GetLocation(int id);
        bool SaveLocation(Location location);
        bool UpdateLocation(Location location);
        bool Delete(int id);
    }
}
