using Newtonsoft.Json;

namespace GoLogs.CustomClearance.ViewModels
{
    public class KontainerFTZRequest
    {
        [JsonProperty("nobl")] public string nobl { get; set; }
        [JsonProperty("tglbl")] public string tglbl { get; set; }
    }
}