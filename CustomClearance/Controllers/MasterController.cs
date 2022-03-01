using System;
using System.Threading.Tasks;
using GoLogs.CustomClearance.Commands;
using GoLogs.CustomClearance.Queries;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace GoLogs.CustomClearance.Controllers
{
    [ApiController, Route("[controller]/[action]")]
    public class MasterController : Controller
    {
        public MasterController(IMediator mediator)
        {
            Mediator = mediator;
        }

        private IMediator Mediator { get; }

        [HttpPost]
        public async Task<IActionResult> SaveCustomClearance(
            [FromBody] CustomClearanceRequest request
        )
        {
            try
            {
                var result = await Mediator.Send(request);
                return Ok(new
                {
                    Status = "Success",
                    JobNumber = result
                });
            }
            catch (System.Exception se)
            {
                throw se;
            }
        }

        [HttpGet]
        public async Task<IActionResult> ListCustomClearance(
            [FromQuery] int Start,
            [FromQuery] int Length,
            [FromQuery] string CreatedBy,
            [FromQuery] bool? IsDraft
        )
        {
            try
            {
                var request = new ListCustomClearanceRequest
                {
                    CreatedBy = CreatedBy,
                    IsDraft = IsDraft,
                    Length = Length,
                    Start = Start
                };
                var result = await Mediator.Send(request);
                return Ok(new
                {
                    Status = "Success",
                    Data = result.Item2,
                    Total = result.Item1
                });
            }
            catch (System.Exception se)
            {
                throw se;
            }
        }

        [HttpGet]
        public async Task<IActionResult> GetCustomClearance(
            [FromQuery] Guid Id
        )
        {
            try
            {
                var request = new GetCustomClearanceRequest
                {
                    Id = Id
                };
                var result = await Mediator.Send(request);
                return Ok(new
                {
                    Status = "Success",
                    Data = result
                });
            }
            catch (System.Exception se)
            {
                throw se;
            }
        }
    }
}