using System;
using System.ComponentModel.DataAnnotations.Schema;

namespace CustomClearance.Context
{
    [Table("CustomClearanceItem")]
    public partial class CustomClearanceItemEntity
    {
        public Guid Id { get; set; }
        public Guid CustomClearanceId { get; set; }
        public string HsCode { get; set; }
        public string ItemName { get; set; }
        public int Quantity { get; set; }

        public string PosTarif { get; set; }
        public string Merk { get; set; }
        public string TipeBarang { get; set; }
        public string KondisiBarang { get; set; }
        public string Negara { get; set; }
        public string FasilitasNoUrut { get; set; }
        public string TarifFasilitas { get; set; }
        public string Satuan { get; set; }
        public double? BeratBersih { get; set; }
        public string SatuanBeratBersih { get; set; }
        public double? NilaiPabean { get; set; }
        public double? JenisNilaiPabean { get; set; }
        public double? NilaiDitambahkan { get; set; }
        public string JatuhTempo { get; set; }

        public string CreatedBy { get; set; }
        public DateTime? CreatedDate { get; set; }
        public string ModifiedBy { get; set; }
        public DateTime? ModifiedDate { get; set; }
        public byte? RowStatus { get; set; }
    }
}
