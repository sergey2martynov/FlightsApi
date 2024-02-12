using MediatR;

namespace Application.Flights.Commands.ChangeFlightStatus
{
    public class ChangeStatusCommand : IRequest
    {
        public Guid FlightId {  get; set; }
        public Status Status { get; set; }
    }
}
