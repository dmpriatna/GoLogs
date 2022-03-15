using Newtonsoft.Json;

namespace GoLogs.CustomClearance.ViewModels
{
    public class AuthRequest
    {
        [JsonProperty("username")]
        public string Username { get; set; }

        [JsonProperty("password")]
        public string Password { get; set; }
    }
}