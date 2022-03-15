using System;
using System.Threading.Tasks;
using Newtonsoft.Json;
using GoLogs.CustomClearance.ViewModels;
using RestSharp;
using JsonSerializer = System.Text.Json.JsonSerializer;

namespace GoLogs.CustomClearance.Ceisa
{
    public class GetImpor : ApiClient
    {
        public GetImpor(string accessToken) : base(accessToken)
        {
        }

        public async Task<ImporResponse> Execute(ImporRequest r)
        {
            var httpClient = buildHttpClient();
            var request = new RestRequest("/impor")
                .AddQueryParameter("noSppb", r.noSppb)
                .AddQueryParameter("npwp", r.npwp)
                .AddQueryParameter("tglSppb", r.tglSppb);

            var response = await httpClient.GetAsync(request);
            var imporResponse =JsonConvert.DeserializeObject<ImporResponse>(response.Content);
            return imporResponse;
        }
    }
}