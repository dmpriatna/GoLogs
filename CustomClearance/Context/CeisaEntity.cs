using System;
using System.ComponentModel.DataAnnotations.Schema;

namespace CustomClearance.Context
{
    [Table("CEISA")]
    public partial class CeisaEntity
    {
        public Guid Id { get; set; }
        public string Request { get; set; }
        public string Response { get; set; }

        public string CreatedBy { get; set; }
        public DateTime CreatedDate { get; set; }
        public string ModifiedBy { get; set; }
        public DateTime ModifiedDate { get; set; }
        public byte RowStatus { get; set; }
    }
}
