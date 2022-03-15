using Newtonsoft.Json;

namespace GoLogs.CustomClearance.ViewModels
{
    public class KontainerSp3BRequest
    {
        [JsonProperty("nobl")] public string noBl { get; set; }
        [JsonProperty("tglbl")] public string tglBl { get; set; }
    }
}