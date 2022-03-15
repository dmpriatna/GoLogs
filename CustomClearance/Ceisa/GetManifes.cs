using System.Collections.Generic;
using System.Threading.Tasks;
using Newtonsoft.Json;
using GoLogs.CustomClearance.Models;
using GoLogs.CustomClearance.ViewModels;
using RestSharp;

namespace GoLogs.CustomClearance.Ceisa
{
    public class GetManifes : ApiClient
    {
        public GetManifes(string accessToken) : base(accessToken)
        {
        }

        public async Task<List<Manifes>> Execute(ManifesRequest r)
        {
            var httpClient = buildHttpClient("https://apisdev-gw.beacukai.go.id/nleceisa/v1");
            httpClient.AddDefaultHeader("manifes", "true");

            var request = new RestRequest("/manifes/beacukai-api-key/")
                .AddQueryParameter("nobl", r.nobl)
                .AddQueryParameter("tglbl", r.tglbl)
                .AddQueryParameter("nopos", r.nopos);

            var response = await httpClient.GetAsync(request);
            var imporResponse = JsonConvert.DeserializeObject<List<Manifes>>(response.Content);
            return imporResponse;
        }
    }
}