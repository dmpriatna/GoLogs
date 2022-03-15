using Newtonsoft.Json;

namespace GoLogs.CustomClearance.Models
{
    public partial class Container
    {
        [JsonProperty("idManifesContainer")]
        public string IdManifesContainer { get; set; }

        [JsonProperty("idManifesDetail")]
        public string IdManifesDetail { get; set; }

        [JsonProperty("seriContainer")]
        public long SeriContainer { get; set; }

        [JsonProperty("noContainer")]
        public string NoContainer { get; set; }

        [JsonProperty("jenisMuat")]
        public string JenisMuat { get; set; }

        [JsonProperty("jenisContainer")]
        public string JenisContainer { get; set; }

        [JsonProperty("ukuranContainer")]
        public long UkuranContainer { get; set; }

        [JsonProperty("noSeal")]
        public string NoSeal { get; set; }
    }
}