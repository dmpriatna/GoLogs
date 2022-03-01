using System;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using CustomClearance.Context;
using GoLogs.CustomClearance.Common;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace GoLogs.CustomClearance.Queries
{
    public class GetCustomClearanceRequest :
        IRequest<CustomClearanceDetail>
    {
        public Guid Id { get; set; }
    }

    public class GetCustomClearanceHandler :
        IRequestHandler<GetCustomClearanceRequest,
            CustomClearanceDetail>
    {
        public GetCustomClearanceHandler(GoLogsContext context)
        {
            Context = context;
        }
        
        private GoLogsContext Context { get; }

        public async Task<CustomClearanceDetail> Handle(
            GetCustomClearanceRequest request, CancellationToken cancellationToken
        )
        {
            var entity = await Context.CustomClearanceSet
            .Where(w => w.Id == request.Id)
            .SingleOrDefaultAsync();

            if (entity == null)
            return new CustomClearanceDetail();

            var result = To(entity);

            var fEntities = await Context.CustomClearanceFileSet
            .Where(w => w.CustomClearanceId == entity.Id)
            .ToListAsync();

            result.Files = fEntities.SelectSafe(To).ToArray();

            var iEntities = await Context.CustomClearanceItemSet
            .Where(w => w.CustomClearanceId == entity.Id)
            .ToListAsync();

            result.Items = iEntities.SelectSafe(To).ToArray();

            return result;
        }

        private CustomClearanceDetail To(CustomClearanceEntity s)
        {
            return new CustomClearanceDetail
            {
                BlDate = s.BlDate,
                BlNumber = s.BlNumber,
                CargoOwnerName = s.CargoOwnerName,
                CargoOwnerNpwp = s.CargoOwnerNpwp,
                CreatedBy = s.CreatedBy,
                CreatedDate = s.CreatedDate,
                CustomsOfficeName = s.CustomsOfficeName,
                DocumentTypeName = s.DocumentTypeName,
                Id = s.Id,
                ImportTypeName = s.ImportTypeName,
                JobNumber = s.JobNumber,
                ModifiedDate = s.ModifiedDate,
                NotifyEmail = s.NotifyEmail.Split(';'),
                PaymentMethodName = s.PaymentMethodName,
                Phone = s.Phone,
                PibTypeName = s.PibTypeName,
                PositionStatus = s.PositionStatus,
                PositionStatusName = s.PositionStatusName,
                PpjkName = s.PpjkName,
                PpjkNpwp = s.PpjkNpwp,
                RequestDate = s.RequestDate
            };
        }

        private CustomClearanceFileOut To(CustomClearanceFileEntity s)
        {
            return new CustomClearanceFileOut
            {
                DocumentType = s.DocumentType,
                FileName = s.FileName,
                Id = s.Id
            };
        }

        private CustomClearanceItemOut To(CustomClearanceItemEntity s)
        {
            return new CustomClearanceItemOut
            {
                HsCode = s.HsCode,
                Id = s.Id,
                ItemName = s.ItemName,
                Quantity = s.Quantity
            };
        }
    }

    public class CustomClearanceDetail
    {
        public Guid Id { get; set; }
        public string JobNumber { get; set; }
        public int PositionStatus { get; set; }
        public string PositionStatusName { get; set; }
        public string CargoOwnerNpwp { get; set; }
        public string CargoOwnerName { get; set; }
        public string PpjkNpwp { get; set; }
        public string PpjkName { get; set; }
        public string Phone { get; set; }
        public string DocumentTypeName { get; set; }
        public string CustomsOfficeName { get; set; }
        public string RequestDate { get; set; }
        public string PibTypeName { get; set; }
        public string ImportTypeName { get; set; }
        public string PaymentMethodName { get; set; }
        public string BlNumber { get; set; }
        public string BlDate { get; set; }
        public string CreatedBy { get; set; }
        public DateTime CreatedDate { get; set; }
        // public string ModifiedBy { get; set; }
        public DateTime ModifiedDate { get; set; }
        // public byte RowStatus { get; set; }
        public string[] NotifyEmail { get; set; }
        public CustomClearanceFileOut[] Files { get; set; }
        public CustomClearanceItemOut[] Items { get; set; }
    }

    public class CustomClearanceFileOut
    {
        public Guid Id { get; set; }
        public string DocumentType { get; set; }
        public string FileName { get; set; }
    }

    public class CustomClearanceItemOut
    {
        public Guid Id { get; set; }
        public string HsCode { get; set; }
        public string ItemName { get; set; }
        public int Quantity { get; set; }
    }
}