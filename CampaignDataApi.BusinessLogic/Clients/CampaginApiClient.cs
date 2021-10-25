using CampaignDataApi.BusinessLogic.Clients.Interfaces;
using CampaignDataApi.DataObjects;
using Microsoft.Extensions.Configuration;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Threading.Tasks;

namespace CampaignDataApi.BusinessLogic.Clients
{
    public class CampaginApiClient : ICampaignApiClient
    {
        private readonly string _uriString;
        private const string MediaType = "application/json";
        private const string RequestUri = "api/campaign";

        public CampaginApiClient(IConfiguration configuration)
        {
            _uriString = configuration["CampaignDataApi"];
        }

        public async Task<List<Campaign>> GetData()
        {
            List<Campaign> data = new List<Campaign>();

            try
            {
                using (HttpClient httpClient = new HttpClient())
                {
                    httpClient.BaseAddress = new Uri(_uriString);
                    httpClient.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue(MediaType));
                    HttpResponseMessage response = await httpClient.GetAsync(RequestUri);
                    if (response.IsSuccessStatusCode)
                    {
                        string dataInString = await response.Content.ReadAsStringAsync();
                        data = JsonConvert.DeserializeObject<List<Campaign>>(dataInString);
                    }
                    else
                    {
                        Console.WriteLine($"GetData: Failed with status code: {(int)response.StatusCode} ({response.ReasonPhrase})");
                    }
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine($"GetData: Failed with exception: {ex.Message}, stack trace: {ex.StackTrace}");
            }


            return data;
        }
    }
}
