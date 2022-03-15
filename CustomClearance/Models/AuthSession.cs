using System;
using System.ComponentModel.DataAnnotations;
using Newtonsoft.Json;

namespace GoLogs.CustomClearance.Models
{
    public class AuthSession
    {
        [Key] [JsonIgnore] public Guid Id { get; set; }
        [JsonIgnore] public DateTime ExpiredDateTime { get; set; }

        [JsonProperty("access_token")] public string AccessToken { get; set; }

        [JsonProperty("expires_in")] public long ExpiresIn { get; set; }

        [JsonProperty("refresh_expires_in")] public long RefreshExpiresIn { get; set; }

        [JsonProperty("refresh_token")] public string RefreshToken { get; set; }

        [JsonProperty("token_type")] public string TokenType { get; set; }

        [JsonProperty("id_token")] public string IdToken { get; set; }

        [JsonProperty("not-before-policy")] public long NotBeforePolicy { get; set; }

        [JsonProperty("session_state")] public Guid SessionState { get; set; }

        [JsonProperty("scope")] public string Scope { get; set; }
    }
}