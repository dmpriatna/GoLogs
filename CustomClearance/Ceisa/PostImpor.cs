using System.Threading.Tasks;
using Newtonsoft.Json;
using GoLogs.CustomClearance.ViewModels;
using RestSharp;
using CustomClearance.Context;

namespace GoLogs.CustomClearance.Ceisa
{
    public class PostImpor : ApiClient
    {
        public PostImpor(GoLogsContext context)
        {
            BaseUrl = "https://nlehub.kemenkeu.go.id";
            Context = context;
        }

        private GoLogsContext Context { get; }
        public bool IsFinal { set { _isFinal = value; } }
        private bool _isFinal;

        public async Task<object> Execute(PostImporRequest request)
        {
            var resource = $"/openapi/document?isFinal={_isFinal}";
            var restClient = buildHttpClient();
            var restRequest = new RestRequest(resource, Method.Post)
            .AddJsonBody(request);

            var restResponse = await restClient.PostAsync(restRequest);

            await Context.AddAsync(new CeisaEntity
            {
                CreatedBy = "",
                CreatedDate = System.DateTime.Now,
                Id = System.Guid.NewGuid(),
                ModifiedBy = "",
                ModifiedDate = System.DateTime.Now,
                Request = JsonConvert.SerializeObject(request),
                Response = JsonConvert.SerializeObject(restResponse),
                RowStatus = 1
            });
            await Context.SaveChangesAsync();

            return restResponse;
        }

        public async Task<string> CheckStatus(string nomorAju)
        {
            var httpClient = buildHttpClient();
            var request = new RestRequest($"/openapi/status/{nomorAju}");
            var response = await httpClient.GetAsync(request);
            return response.Content;
        }
    }
}