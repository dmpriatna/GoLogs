using System;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using CustomClearance.Context;
using GoLogs.CustomClearance.Common;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace GoLogs.CustomClearance.Commands
{
    public class CustomClearanceRequest : IRequest<string>
    {
        public Guid? Id { get; set; }
        public bool IsDraft { get; set; }
        public string CargoOwnerNpwp { get; set; } = "";
        public string CargoOwnerNib { get; set; } = "";
        public string CargoOwnerName { get; set; } = "";
        public string PpjkNpwp { get; set; } = "";
        public string PpjkNib { get; set; } = "";
        public string PpjkName { get; set; } = "";
        public string Phone { get; set; }
        public string DocumentTypeName { get; set; } = "";
        public string CustomsOfficeName { get; set; } = "";
        public DateTime? RequestDate { get; set; }
        public string PibTypeName { get; set; } = "";
        public string ImportTypeName { get; set; } = "";
        public string PaymentMethodName { get; set; } = "";
        public string BlNumber { get; set; }
        public DateTime? BlDate { get; set; }
        public string CreatedBy { get; set; }
        public string[] NotifyEmail { get; set; }
        public CustomClearanceFileRequest[] Files { get; set; }
        public CustomClearanceItemRequest[] Items { get; set; }
    }

    public class CustomClearanceFileRequest
    {
        public Guid? Id { get; set; }
        public string DocumentType { get; set; }
        public string FileName { get; set; }
    }

    public class CustomClearanceItemRequest
    {
        public Guid? Id { get; set; }
        public string HsCode { get; set; }
        public string ItemName { get; set; }
        public int Quantity { get; set; }
    }

    public class SaveCustomClearanceHandler : IRequestHandler<CustomClearanceRequest, string>
    {
        public SaveCustomClearanceHandler(GoLogsContext context)
        {
            Context = context;
        }

        private GoLogsContext Context { get; }

        public async Task<string> Handle(CustomClearanceRequest request, CancellationToken cancellationToken)
        {
            string result = "";
            string email = string.Join(";", request.NotifyEmail);
            if (request.Id.HasValue)
            {
                var entity = await Context.CustomClearanceSet
                .Where(w => w.Id == request.Id)
                .SingleOrDefaultAsync();
                if (entity != null)
                {
                    if (entity.JobNumber == "" &&
                        entity.RowStatus == 0 &&
                        !request.IsDraft)
                    {
                        result = Context.JobNumber;
                        entity.JobNumber = result;
                    }

                    entity.Changes(request);
                    entity.ModifiedBy = request.CreatedBy;
                    entity.ModifiedDate = DateTime.Now;
                    entity.NotifyEmail = email;
                    await Context.SaveChangesAsync();
                    PutFiles(request.Files, entity.Id, entity.ModifiedBy);
                    PutItems(request.Items, entity.Id, entity.ModifiedBy);
                    PutLog(entity.Id, entity.PositionStatus, entity.PositionStatusName, entity.CreatedBy);
                    result = entity.JobNumber;
                }
            }
            else
            {
                var newEntity = new CustomClearanceEntity();
                newEntity.Changes(request);
                newEntity.JobNumber = !request.IsDraft ? Context.JobNumber : "";
                newEntity.NotifyEmail = email;
                newEntity.PositionStatus = request.IsDraft ? 0 : 1;
                newEntity.PositionStatusName = request.IsDraft ? "Draft" : "In Progress";
                newEntity.RowStatus = (byte)(request.IsDraft ? 0 : 1);
                await Context.AddAsync(newEntity);
                await Context.SaveChangesAsync();
                PutFiles(request.Files, newEntity.Id, newEntity.CreatedBy);
                PutItems(request.Items, newEntity.Id, newEntity.CreatedBy);
                PutLog(newEntity.Id, newEntity.PositionStatus, newEntity.PositionStatusName, newEntity.CreatedBy);
                result = newEntity.JobNumber;
            }
            
            return result;
        }

        private void PutFiles(CustomClearanceFileRequest[] Files, Guid CcId, string actor)
        {
            if (Files != null && Files.Length > 0)
                foreach (var item in Files)
                {
                    if (item.Id.HasValue)
                    {
                        var entity = Context.CustomClearanceFileSet
                        .Where(w => w.Id == item.Id)
                        .SingleOrDefault();
                        if (entity != null)
                        {
                            entity.Changes(item);
                            entity.ModifiedBy = actor;
                            entity.ModifiedDate = DateTime.Now;
                        }
                    }
                    else
                    {
                        var newEntity = new CustomClearanceFileEntity();
                        newEntity.Changes(item);
                        newEntity.CreatedBy = actor;
                        newEntity.CustomClearanceId = CcId;
                        Context.Add(newEntity);
                    }
                    Context.SaveChanges();
                }
        }

        private void PutItems(CustomClearanceItemRequest[] Items, Guid CcId, string Actor)
        {
            if (Items != null && Items.Length > 0)
                foreach (var item in Items)
                {
                    if (item.Id.HasValue)
                    {
                        var entity = Context.CustomClearanceItemSet
                        .Where(w => w.Id == item.Id)
                        .SingleOrDefault();
                        if (entity != null)
                        {
                            entity.Changes(item);
                            entity.ModifiedBy = Actor;
                            entity.ModifiedDate = DateTime.Now;
                        }
                    }
                    else
                    {
                        var newEntity = new CustomClearanceItemEntity();
                        newEntity.Changes(item);
                        newEntity.CreatedBy = Actor;
                        newEntity.CustomClearanceId = CcId;
                        Context.Add(newEntity);
                    }
                    Context.SaveChanges();
                }
        }
        
        private void PutLog(Guid CcId, int Pos, string PosName, string Actor = "System")
        {
            var newEntity = new CustomClearanceLogEntity
            {
                CreatedBy = Actor,
                CustomClearanceId = CcId,
                PositionStatus = Pos,
                PositionStatusName = PosName
            };

            Context.Add(newEntity);
            Context.SaveChanges();
        }
    }
}