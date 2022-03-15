using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Newtonsoft.Json;
using GoLogs.CustomClearance.ViewModels;
using RestSharp;
using JsonSerializer = System.Text.Json.JsonSerializer;

namespace GoLogs.CustomClearance.Ceisa
{
    public class GetKontainerFTZ : ApiClient
    {
        public GetKontainerFTZ(string accessToken) : base(accessToken)
        {
        }

        public async Task<List<KontainerFTZResponse>> Execute(KontainerFTZRequest r)
        {
            var httpClient = buildHttpClient();
            var request = new RestRequest("/kontainerftz")
                .AddQueryParameter("nobl", r.nobl)
                .AddQueryParameter("tglbl", r.tglbl);

            var response = await httpClient.GetAsync(request);
            var imporResponse = JsonConvert.DeserializeObject<List<KontainerFTZResponse>>(response.Content);
            return imporResponse;
        }
    }
}