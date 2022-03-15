using Newtonsoft.Json;
using GoLogs.CustomClearance.Models;

namespace GoLogs.CustomClearance.ViewModels
{
    public partial class RespMessage
    {
        [JsonProperty("status")] public long Status { get; set; }

        [JsonProperty("message")] public string Message { get; set; }
    }

    public class ProfileResponse : Profil
    {
        [JsonProperty("respMessage")] public RespMessage RespMessage { get; set; }
    }
}