namespace GoLogs.CustomClearance.Models
{
    using System.Collections.Generic;
    using Newtonsoft.Json;

    public class ContainerFtz
    {
        [JsonProperty("id")] public string Id { get; set; }

        [JsonProperty("idPpftz")] public long IdPpftz { get; set; }

        [JsonProperty("noKontainer")] public string NoKontainer { get; set; }

        [JsonProperty("kdUkuranKontainer")] public long KdUkuranKontainer { get; set; }

        [JsonProperty("kdTipeKontainer")] public string KdTipeKontainer { get; set; }

        [JsonProperty("noSeal")] public object NoSeal { get; set; }

        [JsonProperty("seriContainer")] public object SeriContainer { get; set; }

        [JsonProperty("containerType")] public object ContainerType { get; set; }
    }
}