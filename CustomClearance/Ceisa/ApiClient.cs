using HttpTracer;
using HttpTracer.Logger;
using RestSharp;

namespace GoLogs.CustomClearance.Ceisa
{
    public abstract class ApiClient
    {
        public ApiClient()
        {

        }

        public ApiClient(string accessToken)
        {
            _accessToken = accessToken;
        }

        public string BaseUrl { set { _baseUrl = value; } }
        private string _baseUrl = "";
        public string Token { set { _accessToken = value; } }
        private string _accessToken = "";

        private const string defaultBaseUrl = "https://apisdev-gw.beacukai.go.id/nleceisa/v1/api";
        private const string beacukaiApiKey = "362cd1df-5dfd-4762-bfb6-bb51cfa9422f";
        
        public RestClient buildHttpClient()
        {
            var baseUrl = _baseUrl ?? defaultBaseUrl;
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
        
        public RestClient buildHttpClient(string myBaseUrl)
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