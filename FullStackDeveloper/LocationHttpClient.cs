using System.Threading.Tasks;
using DataModels = Data.Models;
using WebModels = Web.Models;
using System.Net.Http;
using Newtonsoft.Json;

namespace Web
{
    public class LocationHttpClient
    {
        private string host;

        public LocationHttpClient(string host)
        {
            this.host = host;
        }

        public async Task<WebModels.LocationsModel> GetLocations()
        {
            HttpResponseMessage response = await GET(Constants.ENDPOINT_GET_LOCATIONS);

            var result = await response.Content.ReadAsStringAsync();
            DataModels.Location[] dataLocations = JsonConvert.DeserializeObject<DataModels.Location[]>(result);

            WebModels.LocationsModel webLocations = new WebModels.LocationsModel(dataLocations);
            
            return webLocations;
        }

        public async Task<WebModels.LocationModel> GetLocationDetails(int locationId)
        {
            string url = Constants.ENDPOINT_GET_LOCATION_DETAILS + "/" + locationId.ToString();

            HttpResponseMessage response = await GET(url);

            var result = await response.Content.ReadAsStringAsync();
            DataModels.Location dataLocation = JsonConvert.DeserializeObject<DataModels.Location>(result);

            WebModels.LocationModel webLocation = new WebModels.LocationModel(dataLocation);

            return webLocation;
        }

        private async Task<HttpResponseMessage> GET(string subUrl, string parameter = "")
        {
            HttpClient client = new HttpClient();
            HttpResponseMessage response = null;
            string url = host + subUrl;

            if (!string.IsNullOrEmpty(parameter)){
                url += "/" + parameter;
            }

            response = await client.GetAsync(url).ConfigureAwait(false);

            return response;
        }
    }
}
