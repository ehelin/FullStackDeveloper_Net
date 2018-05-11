using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using DataModels = Data.Models;
using WebModels = FullStackDeveloper.Models;
using System.Net.Http;

namespace FullStackDeveloper
{
    public class LocationHttpClient
    {
        private string host;

        public LocationHttpClient(string host)
        {
            this.host = host;
        }

        public async Task<List<WebModels.Location>> GetLocations()
        {
            HttpResponseMessage response = await GET("api/Locations");
            var result = await response.Content.ReadAsStringAsync();
            
            // TODO - convert result to List of data.locations
            // TODO - convert data.locations to web.locations
            // TODO - return result

            return null;
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
