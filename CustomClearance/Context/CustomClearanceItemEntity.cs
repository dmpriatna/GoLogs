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
        public string CreatedBy { get; set; }
        public DateTime? CreatedDate { get; set; }
        public string ModifiedBy { get; set; }
        public DateTime? ModifiedDate { get; set; }
        public byte? RowStatus { get; set; }
    }
}
