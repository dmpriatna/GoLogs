using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Newtonsoft.Json;
using GoLogs.CustomClearance.ViewModels;
using RestSharp;
using JsonSerializer = System.Text.Json.JsonSerializer;

namespace GoLogs.CustomClearance.Ceisa
{
    public class GetProfil : ApiClient
    {
        public GetProfil(string accessToken) : base(accessToken)
        {
        }

        public async Task<List<ProfileResponse>> Execute(ProfileRequest r)
        {
            var httpClient = buildHttpClient();
            var request = new RestRequest("/profile/" + r.npwp);

            var response = await httpClient.GetAsync(request);
            var imporResponse = JsonConvert.DeserializeObject<List<ProfileResponse>>(response.Content);
            return imporResponse;
        }
    }
}