using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;

// Code scaffolded by EF Core assumes nullable reference types (NRTs) are not used or disabled.
// If you have enabled NRTs for your project, then un-comment the following line:
// #nullable disable

namespace CustomClearance.Context
{
    [Table("CustomClearance")]
    public partial class CustomClearanceEntity
    {
        public Guid Id { get; set; }
        public string JobNumber { get; set; }
        public int PositionStatus { get; set; }
        public string PositionStatusName { get; set; }
        public string CargoOwnerNpwp { get; set; }
        public string CargoOwnerNib { get; set; }
        public string CargoOwnerName { get; set; }
        public string PpjkNpwp { get; set; }
        public string PpjkNib { get; set; }
        public string PpjkName { get; set; }
        public string NotifyEmail { get; set; }
        public string Phone { get; set; }
        public string DocumentTypeName { get; set; }
        public string CustomsOfficeName { get; set; }
        public DateTime? RequestDate { get; set; }
        public string PibTypeName { get; set; }
        public string ImportTypeName { get; set; }
        public string PaymentMethodName { get; set; }
        public string BlNumber { get; set; }
        public DateTime? BlDate { get; set; }
        public string CreatedBy { get; set; }
        public DateTime CreatedDate { get; set; }
        public string ModifiedBy { get; set; }
        public DateTime ModifiedDate { get; set; }
        public byte RowStatus { get; set; }
    }
}
