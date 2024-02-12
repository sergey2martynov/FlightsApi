using MediatR;

namespace Application.Flights.Commands.CreateFlight
{
    public class CreateFlightCommand : IRequest<Guid>
    {
        public string Origin { get; set; }
        public string Destination { get; set; }
        public DateTimeOffset Departure { get; set; }
        public DateTimeOffset Arrival { get; set; }
        public Status Status { get; set; }
    }
}
