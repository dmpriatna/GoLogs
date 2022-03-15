using Newtonsoft.Json;

namespace GoLogs.CustomClearance.Models
{
    public class Profil
    {
        [JsonProperty("id")]
        public string Id { get; set; }

        [JsonProperty("nib")]
        public string Nib { get; set; }

        [JsonProperty("npwp")]
        public string Npwp { get; set; }

        [JsonProperty("companyName")]
        public string CompanyName { get; set; }

        [JsonProperty("namePerson")]
        public string NamePerson { get; set; }

        [JsonProperty("alamatPerseroan")]
        public string AlamatPerseroan { get; set; }

        [JsonProperty("rtRw")]
        public string RtRw { get; set; }

        [JsonProperty("postalCode")]
        public long PostalCode { get; set; }

        [JsonProperty("phone")]
        public string Phone { get; set; }

        [JsonProperty("email")]
        public string Email { get; set; }

        [JsonProperty("perseroanDaerahId")]
        public string PerseroanDaerahId { get; set; }

        [JsonProperty("address")]
        public string Address { get; set; }

        [JsonProperty("province")]
        public string Province { get; set; }

        [JsonProperty("city")]
        public string City { get; set; }

        [JsonProperty("district")]
        public string District { get; set; }

        [JsonProperty("subDistrict")]
        public string SubDistrict { get; set; }
    }
}