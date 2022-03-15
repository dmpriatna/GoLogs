using HttpTracer;
using HttpTracer.Logger;
using Microsoft.Extensions.Http.Logging;
using Microsoft.Extensions.Logging;
using Microsoft.IdentityModel.Tokens;
using RestSharp;

namespace GoLogs.CustomClearance.Ceisa
{
    public abstract class ApiClient
    {
        private const string defaultBaseUrl = "https://apisdev-gw.beacukai.go.id/nleceisa/v1/api";
        private const string beacukaiApiKey = "362cd1df-5dfd-4762-bfb6-bb51cfa9422f";
        private string _accessToken = "";
        
        public ApiClient(string accessToken)
        {
            _accessToken = accessToken;
        }

        public RestClient buildHttpClient(string myBaseUrl=null)
        {
            var baseUrl = myBaseUrl ?? defaultBaseUrl;
            var options = new RestClientOptions(baseUrl)
            {
                ConfigureMessageHandler = handler =>
                    new HttpTracerHandler(handler, new ConsoleLogger(), HttpMessageParts.All)
            };
            var client = new RestClient(options);

            client.AddDefaultHeader("beacukai-api-key", beacukaiApiKey);
            client.AddDefaultHeader("Authorization","Bearer " +_accessToken);
            client.AddDefaultHeader("Accept","application/json");
            return client;
        }
    }
}