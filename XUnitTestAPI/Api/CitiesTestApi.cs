using System;
using System.Collections.Generic;
using System.Text;
using Xunit;
using ASP.NET;
using Microsoft.AspNetCore.TestHost;
using Microsoft.AspNetCore.Hosting;
using System.Net;
using System.Net.Http;
using System.Threading.Tasks;

namespace XUnitTestAPI.Api
{
    public class CitiesTestApi
    {
        private readonly HttpClient _client;

        public CitiesTestApi()
        {
            var server = new TestServer(new WebHostBuilder()
                .UseEnvironment("Development")
                .UseStartup<Startup>());
        }

        [Theory]
        [InlineData("DELETE", "33")]
        public async Task DeleteCity(string method, string id = null)
        {
            var request = new HttpRequestMessage(new HttpMethod(method), $"api/Cities/{id}");

            var response = await _client.SendAsync(request);

            response.EnsureSuccessStatusCode();
            Assert.Equal(HttpStatusCode.OK, response.StatusCode);
        }

        [Theory]
        [InlineData("POST")]
        public async Task PostCities(string method)
        {
            var request = new HttpRequestMessage(new HttpMethod(method), "api/Cities/all");

            var response = await _client.SendAsync(request);

            response.EnsureSuccessStatusCode();
            Assert.Equal(HttpStatusCode.OK, response.StatusCode);
        }
    }
}
