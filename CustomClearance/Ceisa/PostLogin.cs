using System.Threading.Tasks;
using HttpTracer;
using HttpTracer.Logger;
using Newtonsoft.Json;
using GoLogs.CustomClearance.ViewModels;
using RestSharp;

namespace GoLogs.CustomClearance.Ceisa
{
    public class PostLogin
    {
        private RestClient newRestClient()
        {
            var options = new RestClientOptions("https://nlehub.kemenkeu.go.id/nle-oauth/oauth/v1")
            {
                ConfigureMessageHandler = handler =>
                    new HttpTracerHandler(handler, new ConsoleLogger(), HttpMessageParts.All)
            };
            var client = new RestClient(options);
            return client;
        }

        public async Task<AuthResponse> Execute(AuthRequest r)
        {
            var httpClient = newRestClient();
            var request = new RestRequest("/login");
            request.AddBody(r);

            var response = await httpClient.PostAsync(request);
            var authResponse = JsonConvert.DeserializeObject<AuthResponse>(response.Content);
            return authResponse;
        }
    }
}