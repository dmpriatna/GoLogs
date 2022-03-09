using System;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using CustomClearance.Context;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace GoLogs.CustomClearance.Commands
{
    public class UpdateStatusRequest : IRequest<string>
    {
        public Guid Id { get; set; }
        public int PositionStatus { get; set; }
        public string PositionStatusName { get; set; }
    }

    public class UpdateStatusCustomHandler : IRequestHandler<UpdateStatusRequest, string>
    {
        public UpdateStatusCustomHandler(GoLogsContext context)
        {
            Context = context;
        }

        private GoLogsContext Context { get; }

        public async Task<string> Handle(UpdateStatusRequest request, CancellationToken cancellationToken)
        {
            var entity = await Context.CustomClearanceSet
            .Where(w => w.Id == request.Id)
            .SingleOrDefaultAsync();

            if (entity == null) return "";

            var newEntity = new CustomClearanceLogEntity
            {
                CreatedBy = entity.CreatedBy,
                CustomClearanceId = entity.Id,
                PositionStatus = request.PositionStatus,
                PositionStatusName = request.PositionStatusName
            };
            await Context.AddAsync(newEntity);

            entity.PositionStatus = request.PositionStatus;
            entity.PositionStatusName = request.PositionStatusName;

            await Context.SaveChangesAsync();
            return entity.JobNumber;
        }
    }
}