namespace Web.Models
{
    public class LocationsModel
    {
        public LocationModel[] Locations;

        public LocationsModel(Data.Models.Location[] dataLocations)
        {
            Locations = new LocationModel[dataLocations.Length];

            for (int i = 0; i < dataLocations.Length; i++)
            {
                LocationModel webLocation = new LocationModel(dataLocations[i]);

                Locations[i] = webLocation;
            }
        }
    }
}
