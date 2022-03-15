using System.Collections.Generic;
using Newtonsoft.Json;
using GoLogs.CustomClearance.Models;

namespace GoLogs.CustomClearance.ViewModels
{
    public class KontainerFTZResponse
    {
        [JsonProperty("id")] public string Id { get; set; }

        [JsonProperty("idPpftz")] public long IdPpftz { get; set; }

        [JsonProperty("noDokumen")] public string NoDokumen { get; set; }

        [JsonProperty("tglDokumen")] public string TglDokumen { get; set; }

        [JsonProperty("container")] public List<ContainerFtz> Container { get; set; }
    }
}