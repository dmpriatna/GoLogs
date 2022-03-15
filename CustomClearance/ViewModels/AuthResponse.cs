using Newtonsoft.Json;
using GoLogs.CustomClearance.Models;

namespace GoLogs.CustomClearance.ViewModels
{
    public class AuthResponse
    {
        [JsonProperty("status")]
        public string Status { get; set; }

        [JsonProperty("message")]
        public string Message { get; set; }

        [JsonProperty("item")]
        public AuthSession Item { get; set; }
    }
}