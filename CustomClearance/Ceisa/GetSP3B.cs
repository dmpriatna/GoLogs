using System.Collections.Generic;
using System.Threading.Tasks;
using Newtonsoft.Json;
using GoLogs.CustomClearance.ViewModels;
using RestSharp;

namespace GoLogs.CustomClearance.Ceisa
{
    public class GetSP3B : ApiClient
    {
        public GetSP3B(string accessToken) : base(accessToken)
        {
        }

        public async Task<List<KontainerSp3BResponse>> Execute(KontainerSp3BRequest r)
        {
            var httpClient = buildHttpClient();
            var request = new RestRequest("/kontainersp3b")
                .AddQueryParameter("nobl", r.noBl)
                .AddQueryParameter("tglbl", r.tglBl);

            var response = await httpClient.GetAsync(request);
            var imporResponse = JsonConvert.DeserializeObject<List<KontainerSp3BResponse>>(response.Content);
            return imporResponse;
        }
    }
}