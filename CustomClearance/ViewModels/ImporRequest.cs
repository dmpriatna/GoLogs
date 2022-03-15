using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using Newtonsoft.Json;

namespace GoLogs.CustomClearance.ViewModels
{
    public class BaseRequest
    {
        
    }
    public class ImporRequest
    {
        [JsonProperty("noSppb")] public string noSppb { get; set; }
        [JsonProperty("npwp")] public string npwp { get; set; }
        [JsonProperty("tglSppb")] public string tglSppb { get; set; }
    }

// Root myDeserializedClass = JsonConvert.DeserializeObject<Root>(myJsonResponse);
    public class CBarangDokumen
    {
        [JsonProperty("seriDokumen")] public string SeriDokumen { get; set; }
    }

    public class CBarangTarif
    {
        [JsonProperty("jumlahSatuan")] public int JumlahSatuan { get; set; }

        [JsonProperty("kodeFasilitasTarif"), Required] public string KodeFasilitasTarif { get; set; }

        [JsonProperty("kodeJenisPungutan"), Required] public string KodeJenisPungutan { get; set; }

        [JsonProperty("kodeJenisTarif"), Required] public string KodeJenisTarif { get; set; }

        [JsonProperty("nilaiBayar"), Required] public double NilaiBayar { get; set; }

        [JsonProperty("nilaiFasilitas"), Required] public double NilaiFasilitas { get; set; }

        [JsonProperty("seriBarang")] public int SeriBarang { get; set; }

        [JsonProperty("tarif"), Required] public double Tarif { get; set; }

        [JsonProperty("tarifFasilitas")] public double TarifFasilitas { get; set; }

        [JsonProperty("jumlahKemasan"), Required] public int? JumlahKemasan { get; set; }

        [JsonProperty("kodeKemasan")] public string KodeKemasan { get; set; }

        [JsonProperty("kodeKomoditiCukai")] public string KodeKomoditiCukai { get; set; }

        [JsonProperty("kodeSatuanBarang")] public string KodeSatuanBarang { get; set; }

        [JsonProperty("kodeSubKomoditiCukai")] public string KodeSubKomoditiCukai { get; set; }

        [JsonProperty("nilaiSudahDilunasi")] public int? NilaiSudahDilunasi { get; set; }
    }

    public class CBarangVd
    {
        [JsonProperty("kodeJenisVd")] public string KodeJenisVd { get; set; }

        [JsonProperty("nilaiBarangVd")] public int NilaiBarangVd { get; set; }
    }

    public class CBarang
    {
        [JsonProperty("asuransi"), Required] public double Asuransi { get; set; }

        [JsonProperty("bruto")] public int Bruto { get; set; }

        [JsonProperty("cif"), Required] public double Cif { get; set; }

        [JsonProperty("cifRupiah")] public double CifRupiah { get; set; }

        [JsonProperty("diskon")] public double Diskon { get; set; }

        [JsonProperty("fob"), Required] public int Fob { get; set; }

        [JsonProperty("freight"), Required] public int Freight { get; set; }

        [JsonProperty("hargaEkspor")] public int HargaEkspor { get; set; }

        [JsonProperty("hargaPatokan")] public int HargaPatokan { get; set; }

        [JsonProperty("hargaPenyerahan")] public int HargaPenyerahan { get; set; }

        [JsonProperty("hargaPerolehan")] public int HargaPerolehan { get; set; }

        [JsonProperty("hargaSatuan"), Required] public double HargaSatuan { get; set; }

        [JsonProperty("hjeCukai")] public int HjeCukai { get; set; }

        [JsonProperty("isiPerKemasan")] public int IsiPerKemasan { get; set; }

        [JsonProperty("jumlahBahanBaku")] public int JumlahBahanBaku { get; set; }

        [JsonProperty("jumlahDilekatkan")] public int JumlahDilekatkan { get; set; }

        [JsonProperty("jumlahKemasan"), Required] public int JumlahKemasan { get; set; }

        [JsonProperty("jumlahPitaCukai")] public int JumlahPitaCukai { get; set; }

        [JsonProperty("jumlahRealisasi")] public int JumlahRealisasi { get; set; }

        [JsonProperty("jumlahSatuan"), Required] public int JumlahSatuan { get; set; }

        [JsonProperty("kapasitasSilinder")] public int KapasitasSilinder { get; set; }

        [JsonProperty("kodeJenisKemasan"), Required] public string KodeJenisKemasan { get; set; }

        [JsonProperty("kodeKondisiBarang")] public string KodeKondisiBarang { get; set; }

        [JsonProperty("kodeNegaraAsal")] public string KodeNegaraAsal { get; set; }

        [JsonProperty("kodeSatuanBarang"), Required] public string KodeSatuanBarang { get; set; }

        [JsonProperty("merk"), Required] public string Merk { get; set; }

        [JsonProperty("ndpbm")] public double Ndpbm { get; set; }

        [JsonProperty("netto")] public double Netto { get; set; }

        [JsonProperty("nilaiBarang")] public int NilaiBarang { get; set; }

        [JsonProperty("nilaiDanaSawit")] public int NilaiDanaSawit { get; set; }

        [JsonProperty("nilaiDevisa")] public int NilaiDevisa { get; set; }

        [JsonProperty("nilaiTambah")] public int NilaiTambah { get; set; }

        [JsonProperty("pernyataanLartas")] public string PernyataanLartas { get; set; }

        [JsonProperty("persentaseImpor")] public int PersentaseImpor { get; set; }

        [JsonProperty("posTarif"), Required] public string PosTarif { get; set; }

        [JsonProperty("saldoAkhir"), Required] public double SaldoAkhir { get; set; }

        [JsonProperty("saldoAwal"), Required] public double SaldoAwal { get; set; }

        [JsonProperty("seriBarang"), Required] public int SeriBarang { get; set; }

        [JsonProperty("seriBarangDokAsal")] public int SeriBarangDokAsal { get; set; }

        [JsonProperty("seriIjin")] public int SeriIjin { get; set; }

        [JsonProperty("tahunPembuatan")] public int TahunPembuatan { get; set; }

        [JsonProperty("tarifCukai")] public int TarifCukai { get; set; }

        [JsonProperty("tipe"), Required] public string Tipe { get; set; }

        [JsonProperty("uraian"), Required] public string Uraian { get; set; }

        [JsonProperty("volume")] public int Volume { get; set; }

        [JsonProperty("barangDokumen")] public List<CBarangDokumen> BarangDokumen { get; set; }

        [JsonProperty("barangTarif"), Required] public List<CBarangTarif> BarangTarif { get; set; }

        [JsonProperty("barangVd"), Required] public List<CBarangVd> BarangVd { get; set; }

        [JsonProperty("barangSpekKhusus")] public List<object> BarangSpekKhusus { get; set; }

        [JsonProperty("barangPemilik")] public List<object> BarangPemilik { get; set; }
    }

    public class CEntitas
    {
        [JsonProperty("alamatEntitas")] public string AlamatEntitas { get; set; }

        [JsonProperty("kodeEntitas")] public string KodeEntitas { get; set; }

        [JsonProperty("kodeJenisApi")] public string KodeJenisApi { get; set; }

        [JsonProperty("kodeJenisIdentitas")] public string KodeJenisIdentitas { get; set; }

        [JsonProperty("kodeStatus")] public string KodeStatus { get; set; }

        [JsonProperty("namaEntitas")] public string NamaEntitas { get; set; }

        [JsonProperty("nibEntitas")] public string NibEntitas { get; set; }

        [JsonProperty("nomorIdentitas")] public string NomorIdentitas { get; set; }

        [JsonProperty("seriEntitas")] public int SeriEntitas { get; set; }

        [JsonProperty("kodeNegara")] public string KodeNegara { get; set; }
    }

    public class CKemasan
    {
        [JsonProperty("jumlahKemasan")] public int JumlahKemasan { get; set; }

        [JsonProperty("kodeJenisKemasan")] public string KodeJenisKemasan { get; set; }

        [JsonProperty("merkKemasan")] public string MerkKemasan { get; set; }

        [JsonProperty("seriKemasan")] public int SeriKemasan { get; set; }
    }

    public class CKontainer
    {
        [JsonProperty("kodeJenisKontainer")] public string KodeJenisKontainer { get; set; }

        [JsonProperty("kodeTipeKontainer")] public string KodeTipeKontainer { get; set; }

        [JsonProperty("kodeUkuranKontainer")] public string KodeUkuranKontainer { get; set; }

        [JsonProperty("nomorKontainer")] public string NomorKontainer { get; set; }

        [JsonProperty("seriKontainer")] public int SeriKontainer { get; set; }
    }

    public class CDokumen
    {
        [JsonProperty("idDokumen")] public string IdDokumen { get; set; }

        [JsonProperty("kodeDokumen")] public string KodeDokumen { get; set; }

        [JsonProperty("kodeFasilitas")] public string KodeFasilitas { get; set; }

        [JsonProperty("nomorDokumen")] public string NomorDokumen { get; set; }

        [JsonProperty("seriDokumen")] public int SeriDokumen { get; set; }

        [JsonProperty("tanggalDokumen")] public string TanggalDokumen { get; set; }

        [JsonProperty("namaFasilitas")] public string NamaFasilitas { get; set; }
    }

    public class CPengangkut
    {
        [JsonProperty("kodeBendera")] public string KodeBendera { get; set; }

        [JsonProperty("namaPengangkut")] public string NamaPengangkut { get; set; }

        [JsonProperty("nomorPengangkut")] public string NomorPengangkut { get; set; }

        [JsonProperty("kodeCaraAngkut")] public string KodeCaraAngkut { get; set; }

        [JsonProperty("seriPengangkut")] public int SeriPengangkut { get; set; }
    }

    public class PostImporRequest
    {
        [JsonProperty("asuransi"), Required] public int Asuransi { get; set; }

        [JsonProperty("biayaPengurang"), Required] public int BiayaPengurang { get; set; }

        [JsonProperty("biayaTambahan"), Required] public int BiayaTambahan { get; set; }

        [JsonProperty("bruto"), Required] public double Bruto { get; set; }

        [JsonProperty("cif"), Required] public double Cif { get; set; }

        [JsonProperty("freight"), Required] public int Freight { get; set; }

        [JsonProperty("jabatanTtd"), Required] public string JabatanTtd { get; set; }

        [JsonProperty("jumlahKontainer"), Required] public int JumlahKontainer { get; set; }

        [JsonProperty("kodeCaraBayar"), Required] public string KodeCaraBayar { get; set; }

        [JsonProperty("kodeJenisImpor"), Required] public string KodeJenisImpor { get; set; }

        [JsonProperty("kodeKantor"), Required] public string KodeKantor { get; set; }

        [JsonProperty("kodePelMuat"), Required] public string KodePelMuat { get; set; }

        [JsonProperty("kodePelTujuan"), Required] public string KodePelTujuan { get; set; }

        [JsonProperty("kodeTps"), Required] public string KodeTps { get; set; }

        [JsonProperty("kodeTutupPu"), Required] public string KodeTutupPu { get; set; }

        [JsonProperty("kodeValuta"), Required] public string KodeValuta { get; set; }

        [JsonProperty("kotaTtd"), Required] public string KotaTtd { get; set; }

        [JsonProperty("namaTtd"), Required] public string NamaTtd { get; set; }

        [JsonProperty("ndpbm"), Required] public double Ndpbm { get; set; }

        [JsonProperty("netto"), Required] public double Netto { get; set; }

        [JsonProperty("nomorAju"), Required] public string NomorAju { get; set; }

        [JsonProperty("tanggalTiba"), Required] public string TanggalTiba { get; set; }

        [JsonProperty("tanggalTtd"), Required] public string TanggalTtd { get; set; }

        [JsonProperty("barang"), Required] public List<CBarang> Barang { get; set; }

        [JsonProperty("entitas"), Required] public List<CEntitas> Entitas { get; set; }

        [JsonProperty("kemasan"), Required] public List<CKemasan> Kemasan { get; set; }

        [JsonProperty("kontainer"), Required] public List<CKontainer> Kontainer { get; set; }

        [JsonProperty("dokumen"), Required] public List<CDokumen> Dokumen { get; set; }

        [JsonProperty("pengangkut"), Required] public List<CPengangkut> Pengangkut { get; set; }

        [JsonProperty("asalData")] public string AsalData { get; set; }

        [JsonProperty("disclaimer")] public string Disclaimer { get; set; }

        [JsonProperty("flagVd")] public string FlagVd { get; set; }

        [JsonProperty("fob")] public int Fob { get; set; }

        [JsonProperty("hargaPenyerahan")] public int HargaPenyerahan { get; set; }

        [JsonProperty("idPengguna")] public string IdPengguna { get; set; }

        [JsonProperty("jumlahTandaPengaman")] public int JumlahTandaPengaman { get; set; }

        [JsonProperty("kodeAsuransi")] public string KodeAsuransi { get; set; }

        [JsonProperty("kodeDokumen")] public string KodeDokumen { get; set; }

        [JsonProperty("kodeIncoterm")] public string KodeIncoterm { get; set; }

        [JsonProperty("kodeJenisNilai")] public string KodeJenisNilai { get; set; }

        [JsonProperty("kodeJenisProsedur")] public string KodeJenisProsedur { get; set; }

        [JsonProperty("kodePelTransit")] public string KodePelTransit { get; set; }

        [JsonProperty("nilaiBarang")] public int NilaiBarang { get; set; }

        [JsonProperty("nilaiIncoterm")] public int NilaiIncoterm { get; set; }

        [JsonProperty("nilaiMaklon")] public int NilaiMaklon { get; set; }

        [JsonProperty("nomorBc11")] public string NomorBc11 { get; set; }

        [JsonProperty("posBc11")] public string PosBc11 { get; set; }

        [JsonProperty("seri")] public int Seri { get; set; }

        [JsonProperty("subPosBc11")] public string SubPosBc11 { get; set; }

        [JsonProperty("tanggalAju")] public string TanggalAju { get; set; }

        [JsonProperty("tanggalBc11")] public string TanggalBc11 { get; set; }

        [JsonProperty("totalDanaSawit")] public int TotalDanaSawit { get; set; }

        [JsonProperty("volume")] public int Volume { get; set; }

    }
}