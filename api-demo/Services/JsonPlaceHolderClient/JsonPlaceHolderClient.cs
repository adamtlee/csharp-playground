using System;
using System.Text.Json;
using ApiDemo.Models;
using ApiDemo.Services.JsonPlaceHolderClient;

namespace ApiDemo.Services.JsonPlaceHolderClient
{
    public class JsonPlaceHolderClient : IJsonPlaceHolderClient
    {
        private readonly IHttpClientFactory _httpClientFactory;
        public JsonPlaceHolderClient(IHttpClientFactory httpClientFactory)
        {
            _httpClientFactory = httpClientFactory;
        }

        public async Task<JPHResponse> GetJPHResponse()
        {
            var client = _httpClientFactory.CreateClient("JPHClient");

            var response = await client.GetAsync("posts/1");
            var jphres = new JPHResponse();
            response.EnsureSuccessStatusCode();

            var content = await response.Content.ReadAsStringAsync();
            if (response.Content.Headers.ContentType.MediaType == "application/json")
            {
                var jphdata = JsonSerializer.Deserialize<JPHResponse>(content,
                        new JsonSerializerOptions
                        {
                            PropertyNamingPolicy = JsonNamingPolicy.CamelCase
                        });
                if (jphdata != null)
                {

                    jphres = jphdata;
                }
            }

            return jphres;
        }
    }
}

