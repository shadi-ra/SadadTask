using System;
using System.Collections.Generic;
using System.Text;
using System.Net.Http;
using Sadad.Core.Entities.Model;
using System.Text.Json;

namespace Sadad.Core.ApplicationService.Services.HttpClient
{
   public class HttpClientUser
    {
        private readonly System.Net.Http.HttpClient client;
        private const string BaseAddress = "https://jsonplaceholder.typicode.com";
        private const int num = 1;
        public HttpClientUser(System.Net.Http.HttpClient client)
        {
            this.client = client;
            this.client.BaseAddress = new Uri(BaseAddress);
            this.client.DefaultRequestHeaders.Add("Accept", "application/json");

        }

        public HttpClientModel GetItem()
        {

            var httpResponse = client.GetAsync("todos"+$"/{num}").Result;
            httpResponse.EnsureSuccessStatusCode();
            if (!httpResponse.IsSuccessStatusCode)
            {
                return null;
            }

            HttpClientModel result;

            using (HttpContent content = httpResponse.Content)
            {

                string stringContent = content.ReadAsStringAsync()
                                               .Result;

                result = JsonSerializer.Deserialize<HttpClientModel>(stringContent);
            }
            return result;


        }
    }
}
