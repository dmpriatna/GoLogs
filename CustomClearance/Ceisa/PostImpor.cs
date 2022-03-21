using System.Threading.Tasks;
using Newtonsoft.Json;
using GoLogs.CustomClearance.ViewModels;
using RestSharp;
using CustomClearance.Context;

namespace GoLogs.CustomClearance.Ceisa
{
    public class PostImpor : ApiClient
    {
        public PostImpor(string token, GoLogsContext context) : base(token)
        {
            Context = context;
        }

        private GoLogsContext Context { get; }

        public async Task<object> Execute(PostImporRequest request)
        {
            var restClient = buildHttpClient("https://apisdev-gw.beacukai.go.id");
            var restRequest = new RestRequest("/openapi/document", Method.Post)
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
            // var imporResponse = JsonConvert.DeserializeObject<ImporResponse>(response.Content);
            // return imporResponse;
        }
    }
}