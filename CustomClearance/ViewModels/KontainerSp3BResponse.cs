using System;
using System.Collections.Generic;
using Newtonsoft.Json;
using GoLogs.CustomClearance.Models;

namespace GoLogs.CustomClearance.ViewModels
{
    public class KontainerSp3BResponse
    {
        [JsonProperty("idManifesDetail")]
        public string IdManifesDetail { get; set; }

        [JsonProperty("idManifesHeader")]
        public Guid IdManifesHeader { get; set; }

        [JsonProperty("noHostBL")]
        public string NoHostBl { get; set; }

        [JsonProperty("tglHostBL")]
        public DateTimeOffset TglHostBl { get; set; }

        [JsonProperty("container")]
        public List<Container> Container { get; set; }
    }
    
}