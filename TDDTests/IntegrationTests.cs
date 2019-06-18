using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Net.Http;
using System.Threading.Tasks;
using System.Collections.Generic;
using Newtonsoft.Json;
using Data.Models;

namespace TDDTests
{
    [TestClass]
    public class IntegrationTests
    {
        private string baseUrl = "http://localhost:59952";
        
        [TestMethod]
        public void GetLocations()
        {
            string url = baseUrl + "/api/Locations";
            var locations = GetLocations(url).Result;

            Assert.IsNotNull(locations);
            Assert.IsTrue(locations.Count > 0);
        }
        
        private async Task<List<Location>> GetLocations(string url)
        {
            List<Location> locations = null;

            using (var httpClient = new HttpClient())
            {
                var response = await httpClient.GetAsync(url);
                var result = await response.Content.ReadAsStringAsync();
                locations = JsonConvert.DeserializeObject<List<Location>>(result);
            }

            return locations;
        }
    }
}
