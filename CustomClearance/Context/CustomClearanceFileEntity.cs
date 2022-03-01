using System;
using System.ComponentModel.DataAnnotations.Schema;

namespace CustomClearance.Context
{
    [Table("CustomClearanceFile")]
    public partial class CustomClearanceFileEntity
    {
        public Guid Id { get; set; }
        public Guid CustomClearanceId { get; set; }
        public string DocumentType { get; set; }
        public string FileName { get; set; }
        public string CreatedBy { get; set; }
        public DateTime CreatedDate { get; set; }
        public string ModifiedBy { get; set; }
        public DateTime ModifiedDate { get; set; }
        public byte RowStatus { get; set; }
    }
}
