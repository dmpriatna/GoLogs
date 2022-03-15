using Newtonsoft.Json;

namespace GoLogs.CustomClearance.ViewModels
{
    public class ProfileRequest
    {
        [JsonProperty("npwp")] public string npwp { get; set; }
    }
}