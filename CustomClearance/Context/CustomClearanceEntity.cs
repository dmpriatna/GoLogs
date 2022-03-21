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

        public string SenderName { get; set; }
        public string SenderAddress { get; set; }
        public string SellerName { get; set; }
        public string SellerAddress { get; set; }
        public string ImportirName { get; set; }
        public string ImportirAddress { get; set; }
        public string CargoOwnerAddress { get; set; }
        public string RegistrationNumber { get; set; }
        public DateTime? RegistrationDate { get; set; }
        public string ModaType { get; set; }
        public string VoyageName { get; set; }
        public string VoyageNumber { get; set; }
        public DateTime? EstimatedTimeArrival { get; set; }
        public string PortOfLoadingName { get; set; }
        public string PortOfTransitName { get; set; }
        public string PortOfDestinationName { get; set; }
        public string PortOfLoadingCode { get; set; }
        public string PortOfTransitCode { get; set; }
        public string PortOfDestinationCode { get; set; }
        public string InvoiceNumber { get; set; }
        public string KmdTransactionNumber { get; set; }
        public string DocumentNumber { get; set; }
        public DateTime? DocumentDate { get; set; }
        public string ImportFacilityDescription { get; set; }
        public string ImportFacilityCode { get; set; }
        public string WarehouseName { get; set; }
        public string WarehouseCode { get; set; }
        public string CurrencyName { get; set; }
        public string CurrencyCode { get; set; }
        public double? Ndpbm { get; set; }
        public double? FobTotal { get; set; }
        public double? InsuranceTotal { get; set; }
        public double? FreightTotal { get; set; }
        public double? ClearanceTotal { get; set; }
        public double? GrandTotal { get; set; }
        public string ContainerNumber { get; set; }
        public string ContainerSize { get; set; }
        public string ContainerType { get; set; }
        public double? PackagingTotal { get; set; }
        public string PackagingType { get; set; }
        public string PackagingBrand { get; set; }
        public double? GrossWeight { get; set; }
        public double? NettWeight { get; set; }

        public string CreatedBy { get; set; }
        public DateTime CreatedDate { get; set; }
        public string ModifiedBy { get; set; }
        public DateTime ModifiedDate { get; set; }
        public byte RowStatus { get; set; }
    }
}
