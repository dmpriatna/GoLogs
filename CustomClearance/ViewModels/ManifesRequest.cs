using Newtonsoft.Json;

namespace GoLogs.CustomClearance.ViewModels
{
    public class ManifesRequest
    {
        [JsonProperty("nobl")] public string nobl { get; set; }
        [JsonProperty("tglbl")] public string tglbl { get; set; }
        [JsonProperty("nopos")] public string nopos { get; set; }
    }
}