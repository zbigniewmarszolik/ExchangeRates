using System;
using System.Threading.Tasks;
using ExchangeRates.Domain.Models;
using ExchangeRates.Domain.Services;
using System.Net.Http;
using ExchangeRates.Services.Factories;
using Newtonsoft.Json;

namespace ExchangeRates.Services.Services
{
    public class CurrencyService : ICurrencyService
    {
        private HttpClient _client { get; set; }

        public CurrencyService(HttpClientFactory httpClientFactory)
        {
            _client = httpClientFactory.Get();
        }

        public async Task<Currency> GetLatestRates()
        {
            try
            {
                HttpResponseMessage responseMessage = await _client.GetAsync(_client.BaseAddress);

                if (responseMessage.IsSuccessStatusCode)
                {
                    var responseData = responseMessage.Content.ReadAsStringAsync().Result;

                    var taskInfo = JsonConvert.DeserializeObject<Currency>(responseData);

                    return taskInfo;
                }
            }
            catch (Exception e)
            {
                //ConnectionErrorAction("Error connecting to the server for reading available tasks.");
            }

            return null;
        }
    }
}
