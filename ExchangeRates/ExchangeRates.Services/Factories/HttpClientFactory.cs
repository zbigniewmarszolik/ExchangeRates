using System;
using System.Net.Http;

namespace ExchangeRates.Services.Factories
{
    public class HttpClientFactory
    {
        public HttpClient Get()
        {
            var uri = new Uri(string.Format("https://api.fixer.io/latest"));

            var instance = new HttpClient
            {
                Timeout = new TimeSpan(0, 0, 15),
                MaxResponseContentBufferSize = 256000,
                BaseAddress = uri
            };

            return instance;
        }
    }
}
