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
    public class CountriesTestAPI
    {
        private readonly HttpClient _client;

        public CountriesTestAPI()
        {
            var server = new TestServer(new WebHostBuilder()
                .UseEnvironment("Development")
                .UseStartup<Startup>());
            _client = server.CreateClient();
        }

        [Theory]
        [InlineData("GET")]
        public async Task CountriesGetAll(string method)
        {
            var request = new HttpRequestMessage(new HttpMethod(method), "api/v1/world/Countries/all");

            var response = await _client.SendAsync(request);

            response.EnsureSuccessStatusCode();
            Assert.Equal(HttpStatusCode.OK, response.StatusCode);
        } // https://docs.microsoft.com/en-us/aspnet/core/test/integration-tests?view=aspnetcore-2.2  https://dotnetcorecentral.com/blog/asp-net-core-web-api-unit-testing-with-xunit/

        [Theory]
        [InlineData("GET", "Europe")]
        public async Task GetCountriesByContinent(string method, string name = null)
        {
            var request = new HttpRequestMessage(new HttpMethod(method), $"api/v1/world/Countries/continent/{name}");

            var response = await _client.SendAsync(request);

            response.EnsureSuccessStatusCode();
            Assert.Equal(HttpStatusCode.OK, response.StatusCode);
        }

        [Theory]
        [InlineData("GET", "AUT")]
        public async Task GetCountryById(string method, string id = null)
        {
            var request = new HttpRequestMessage(new HttpMethod(method), $"api/v1/world/Countries/{id}");

            var response = await _client.SendAsync(request);

            response.EnsureSuccessStatusCode();
            Assert.Equal(HttpStatusCode.OK, response.StatusCode);
        }

        [Theory]
        [InlineData("GET", "1997")]
        public async Task GetCountriesByIndependenceYear(string method, string year = null)
        {
            var request = new HttpRequestMessage(new HttpMethod(method), $"api/v1/world/Countries/Indep/{year}");

            var response = await _client.SendAsync(request);

            response.EnsureSuccessStatusCode();
            Assert.Equal(HttpStatusCode.OK, response.StatusCode);
        }

        [Theory]
        [InlineData("GET", "Estonia")]
        public async Task GetCitiesByCountry(string method, string name = null)
        {
            var request = new HttpRequestMessage(new HttpMethod(method), $"api/v1/world/Countries/{name}/city/all");

            var response = await _client.SendAsync(request);

            response.EnsureSuccessStatusCode();
            Assert.Equal(HttpStatusCode.OK, response.StatusCode);
        }
    }
}
