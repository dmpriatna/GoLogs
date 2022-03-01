using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using CustomClearance.Context;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace GoLogs.CustomClearance.Queries
{
    public class ListCustomClearanceRequest :
        IRequest<Tuple<int, IEnumerable<CustomClearanceOut>>>
    {
        public int Start { get; set; }
        public int Length { get; set; }
        public string CreatedBy { get; set; }
        public bool? IsDraft { get; set; }
    }

    public class ListCustomClearanceHandler :
        IRequestHandler<ListCustomClearanceRequest,
            Tuple<int, IEnumerable<CustomClearanceOut>>>
    {
        public ListCustomClearanceHandler(GoLogsContext context)
        {
            Context = context;
        }
        
        private GoLogsContext Context { get; }

        public async Task<Tuple<int, IEnumerable<CustomClearanceOut>>> Handle(
            ListCustomClearanceRequest request, CancellationToken cancellationToken
        )
        {
            int count = 0;
            var query = Context.CustomClearanceSet.AsQueryable();

            if (request.IsDraft.HasValue && request.IsDraft.Value)
            query = query.Where(w => w.PositionStatus == 0);

            if (request.IsDraft.HasValue && !request.IsDraft.Value)
            query = query.Where(w => w.PositionStatus > 0);

            if (!string.IsNullOrWhiteSpace(request.CreatedBy))
            query = query.Where(w => w.CreatedBy == request.CreatedBy);

            count = query.Count();
            query = query.OrderByDescending(obd => obd.ModifiedDate);

            if (request.Start > 0)
            query = query.Skip(request.Start);

            if (request.Length > 0)
            query = query.Take(request.Length);

            var entities = await query
            .Select(s => new CustomClearanceOut
            {
                CreatedDate = s.CreatedDate,
                Id = s.Id,
                JobNumber = s.JobNumber,
                ModifiedDate = s.ModifiedDate,
                PositionStatus = s.PositionStatus
            })
            .ToListAsync();

            if (entities == null)
            return new Tuple<int, IEnumerable<CustomClearanceOut>>
            (count, new List<CustomClearanceOut>());

            return new Tuple<int, IEnumerable<CustomClearanceOut>>
            (count, entities);
        }
    }

    public class CustomClearanceOut
    {
        public Guid Id { get; set; }
        public string JobNumber { get; set; }
        public int PositionStatus { get; set; }
        public DateTime CreatedDate { get; set; }
        public DateTime ModifiedDate { get; set; }
    }
}