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

            var clientId = "mvc";
            var redirectUri = "https%3A%2F%2Flocalhost%3A44315%2F";//host + @" / account/oAuth2";

            var response_mode = "form_post";//"code";
            var response_type = "id_token";//"code";
            var scope = "openid%20profile";//"api";
            var state = Guid.NewGuid().ToString("N");
            var x_client_SKU = "ID_NET461";
            var x_client_ver = "5.3.0.0";

            var url = host + subUrl
                + "?client_id=" + clientId
                + "&redirect_uri=" + redirectUri
                + "&response_mode=" + response_mode
                + "&response_type=" + response_type
                + "&scope=" + scope 
                + "&state=" + state
                + "&x-client-SKU=" + x_client_SKU
                + "&x_client_ver=" + x_client_ver;

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
