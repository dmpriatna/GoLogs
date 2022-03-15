using System.Threading.Tasks;
using Newtonsoft.Json;
using GoLogs.CustomClearance.ViewModels;
using RestSharp;

namespace GoLogs.CustomClearance.Ceisa
{
    public class PostImpor : ApiClient
    {
        public PostImpor(string token) : base(token)
        {
            
        }

        public async Task<object> Execute(PostImporRequest request)
        {
            var restClient = buildHttpClient("https://apisdev-gw.beacukai.go.id");
            var restRequest = new RestRequest("/openapi/document", Method.Post)
            .AddJsonBody(request);

            var restResponse = await restClient.PostAsync(restRequest);
            return restResponse;
            // var imporResponse = JsonConvert.DeserializeObject<ImporResponse>(response.Content);
            // return imporResponse;
        }
    }
}