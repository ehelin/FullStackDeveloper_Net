using System.Threading.Tasks;
using System.Net.Http;
using Newtonsoft.Json;
using System;

namespace IdentityClassicNetTests
{
    class Program
    {
        static void Main(string[] args)
        {
            var result = Program.Test().Result;
        }

        public static async Task<bool> Test() 
        {
            var host = "https://localhost:44315";
            var subUrl = "/identity/connect/authorize";
            var clientId = "mvc"; string response_type = "code";
            var redirectUri = host + @"/account/oAuth2";
            var scope = "api";
            var state = Guid.NewGuid().ToString("N");

            var url = host + subUrl
                + "?client_id=" + clientId
                + "&response_type=" + response_type
                + "&redirect_uri=" + redirectUri 
                + "&scope=" + scope 
                + "&state=" + state;

            HttpClient client = new HttpClient();
            HttpResponseMessage response = null;

            response = await client.GetAsync(url).ConfigureAwait(false);
            var result = await response.Content.ReadAsStringAsync().ConfigureAwait(false);

            //var client = new TokenClient(
            //       "https://localhost:44319/identity/connect/token",
            //       "mvc_service",
            //       "secret");

            return true;
        }
    }
}
