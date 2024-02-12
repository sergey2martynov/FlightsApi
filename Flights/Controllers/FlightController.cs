using Application.Flights.Commands.ChangeFlightStatus;
using Application.Flights.Commands.CreateFlight;
using Application.Flights.Queries.GetAll;
using Asp.Versioning;
using Domain.Constants;
using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace Flights.Controllers
{
    [Authorize]
    [ApiVersion("1.0")]
    [ApiController]
    [Route("api/{version:apiVersion}/[controller]/[action]")]
    public class FlightController : ControllerBase
    {
        private readonly IMediator _mediator;

        public FlightController() 
        {
            _mediator = HttpContext.RequestServices.GetService<IMediator>();
        }

        [HttpGet]
        [Authorize(Roles = Roles.Client)]
        public async Task<IActionResult> GetAll()
        {
            var flightListVm = await _mediator.Send(new GetFlightListQuery());

            return Ok(flightListVm);
        }

        [HttpPost]
        [Authorize(Roles = Roles.Moderator)]
        public async Task<IActionResult> Create([FromBody] CreateFlightCommand command)
        {
            var flightId = await _mediator.Send(command);

            return Ok(flightId);
        }

        [HttpPut]
        [Authorize(Roles = Roles.Moderator)]
        public async Task<IActionResult> Update(ChangeStatusCommand command)
        {
            await _mediator.Send(command);

            return NoContent();
        }
    }
}
