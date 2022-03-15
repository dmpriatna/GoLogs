using System.Collections.Generic;
using Newtonsoft.Json;
using GoLogs.CustomClearance.Models;

namespace GoLogs.CustomClearance.ViewModels
{
    public class ImporResponse
    {
        [JsonProperty("tgl_bl")] public long TglBl { get; set; }

        [JsonProperty("container")] public List<Container> Container { get; set; }

        [JsonProperty("nm_ff")] public string NmFf { get; set; }

        [JsonProperty("tgl_sppb")] public long TglSppb { get; set; }

        [JsonProperty("no_sppb")] public string NoSppb { get; set; }

        [JsonProperty("pib")] public string Pib { get; set; }

        [JsonProperty("no_bl")] public string NoBl { get; set; }

        [JsonProperty("npwp_ff")] public string NpwpFf { get; set; }

        [JsonProperty("npwp_co")] public string NpwpCo { get; set; }

        [JsonProperty("nm_co")] public string NmCo { get; set; }

        [JsonProperty("status")] public string Status { get; set; }
    }
}