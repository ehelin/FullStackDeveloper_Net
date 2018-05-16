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
            WebModels.LocationsModel webLocations = new WebModels.LocationsModel();
            webLocations.Locations = new WebModels.LocationModel[dataLocations.Length];

            for (int i=0; i< dataLocations.Length; i++)
            {
                WebModels.LocationModel webLocation = new WebModels.LocationModel();

                webLocation.LocationiId = dataLocations[i].LocationiId;
                webLocation.LocationName = dataLocations[i].LocationName;

                webLocations.Locations[i] = webLocation;
            }

            return webLocations;
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
