using System;
using System.Collections.Generic;

// Code scaffolded by EF Core assumes nullable reference types (NRTs) are not used or disabled.
// If you have enabled NRTs for your project, then un-comment the following line:
// #nullable disable

namespace CustomClearance.Context
{
    public partial class Companies
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
        public string District { get; set; }
        public string City { get; set; }
        public string PostalCode { get; set; }
        public string Nib { get; set; }
        public string SubDistrict { get; set; }
        public string Address { get; set; }
        public string Province { get; set; }
        public string Email { get; set; }
        public string Phone { get; set; }
        public string Npwp { get; set; }
        public string Type { get; set; }
        public bool RowStatus { get; set; }
        public Guid CreatedById { get; set; }
        public string CreatedBy { get; set; }
        public DateTime CreatedDate { get; set; }
        public Guid ModifiedById { get; set; }
        public string ModifiedBy { get; set; }
        public DateTime ModifiedDate { get; set; }
        public Guid? PersonId { get; set; }
    }
}
