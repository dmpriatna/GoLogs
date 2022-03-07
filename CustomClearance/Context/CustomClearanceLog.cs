using System;
using System.ComponentModel.DataAnnotations.Schema;

namespace CustomClearance.Context
{
    [Table("CustomClearanceLog")]
    public partial class CustomClearanceLogEntity
    {
        public Guid Id { get; set; }
        public Guid CustomClearanceId { get; set; }
        public int PositionStatus { get; set; }
        public string PositionStatusName { get; set; }
        public string CreatedBy { get; set; }
        public DateTime CreatedDate { get; set; }
        public string ModifiedBy { get; set; }
        public DateTime ModifiedDate { get; set; }
        public byte RowStatus { get; set; }
    }
}