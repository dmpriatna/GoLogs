namespace GoLogs.CustomClearance.Models
{
    using System;
    using System.Collections.Generic;
    using System.Globalization;
    using Newtonsoft.Json;
    using Newtonsoft.Json.Converters;

    public partial class Manifes
    {
        [JsonProperty("id")] public string Id { get; set; }

        [JsonProperty("nobl")] public string Nobl { get; set; }

        [JsonProperty("tglbl")] public DateTimeOffset Tglbl { get; set; }

        [JsonProperty("nopos")] public string Nopos { get; set; }

        [JsonProperty("nomormanifes")] public Guid Nomormanifes { get; set; }

        [JsonProperty("no_host_bl")] public string NoHostBl { get; set; }

        [JsonProperty("tgl_host_bl")] public DateTimeOffset TglHostBl { get; set; }

        [JsonProperty("seri_container")] public long SeriContainer { get; set; }

        [JsonProperty("no_container")] public string NoContainer { get; set; }

        [JsonProperty("type_container")] public string TypeContainer { get; set; }

        [JsonProperty("ukuran_container")] public long UkuranContainer { get; set; }

        [JsonProperty("no_seal")] public string NoSeal { get; set; }

        [JsonProperty("jenis_container")] public string JenisContainer { get; set; }

        [JsonProperty("status")] public object Status { get; set; }

        [JsonProperty("bruto")] public long Bruto { get; set; }

        [JsonProperty("nama_sarana_pengangkut")] public string NamaSaranaPengangkut { get; set; }

        [JsonProperty("no_voyage")] public string NoVoyage { get; set; }

        [JsonProperty("nahkoda")] public string Nahkoda { get; set; }

        [JsonProperty("bendera")] public string Bendera { get; set; }

        [JsonProperty("nama_shipper")] public string NamaShipper { get; set; }

        [JsonProperty("alamat_shipper")] public string AlamatShipper { get; set; }

        [JsonProperty("nama_pemilik")] public string NamaPemilik { get; set; }

        [JsonProperty("npwp_pemilik")] public object NpwpPemilik { get; set; }

        [JsonProperty("alamat_pemilik")] public string AlamatPemilik { get; set; }

        [JsonProperty("nama_penerima")] public string NamaPenerima { get; set; }

        [JsonProperty("alamat_penerima")] public string AlamatPenerima { get; set; }

        [JsonProperty("id_pelabuhan_asal")] public string IdPelabuhanAsal { get; set; }

        [JsonProperty("id_pelabuhan_muat")] public string IdPelabuhanMuat { get; set; }

        [JsonProperty("id_pelabuhan_transit")] public string IdPelabuhanTransit { get; set; }

        [JsonProperty("id_pelabuhan_bongkar")] public string IdPelabuhanBongkar { get; set; }

        [JsonProperty("id_pelabuhan_berikut")] public string IdPelabuhanBerikut { get; set; }

        [JsonProperty("id_pelabuhan_akhir")] public string IdPelabuhanAkhir { get; set; }

        [JsonProperty("nm_kantor_pendek")] public string NmKantorPendek { get; set; }
    }
}