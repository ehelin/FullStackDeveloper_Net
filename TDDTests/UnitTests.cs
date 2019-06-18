using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Net.Http;
using System.Threading.Tasks;
using System.Collections.Generic;
using Newtonsoft.Json;
using Data.Models;
using System.Net;
using Moq;
using System;

namespace TDDTests
{
    public class FakeHttpMessageHandler : HttpMessageHandler
    {
        public virtual HttpResponseMessage Send(HttpRequestMessage request)
        {
            throw new NotImplementedException("Now we can setup this method with our mocking framework");
        }

        protected override Task<HttpResponseMessage> SendAsync(HttpRequestMessage request, System.Threading.CancellationToken cancellationToken)
        {
            return Task.FromResult(Send(request));
        }
    }

    [TestClass]
    public class UnitTests
    {
        //http://hamidmosalla.com/2017/02/08/mock-httpclient-using-httpmessagehandler/
        [TestMethod]
        public void GetLocations() 
        {
            var result = TestHttpClient().Result;
            Assert.IsTrue(result);
        }

        private async Task<bool> TestHttpClient()
        {
            var mockHttp = new Mock<FakeHttpMessageHandler>() { CallBase = true };

            mockHttp.Setup(f => f.Send(It.IsAny<HttpRequestMessage>())).Returns(new HttpResponseMessage
            {
                StatusCode = HttpStatusCode.OK,
                Content = new StringContent("{\"success\": false,\"error-codes\": [\"It's a fake error!\",\"It's a fake error\"]}")
            });
           
            // Inject the handler or client into your application code
            var client = new HttpClient(mockHttp.Object);

            var response = await client.GetAsync("http://localhost/api/user/1234");
            // or without async: var response = client.GetAsync("http://localhost/api/user/1234").Result;

            var json = await response.Content.ReadAsStringAsync();

            // No network connection required
            //Console.Write(json); // {'name' : 'Test McGee'}
            return false;
        }
    }
}
