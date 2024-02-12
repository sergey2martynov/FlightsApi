using Application.Common.Interfaces;
using Domain.Entites;
using MediatR;

namespace Application.Flights.Commands.CreateFlight
{
    public class CreateFlightCommandHandler : IRequestHandler<CreateFlightCommand, Guid>
    {
        private readonly IApplicationDbContext _context;

        public CreateFlightCommandHandler(IApplicationDbContext context)
        {
            _context = context;
        }

        public async Task<Guid> Handle(CreateFlightCommand request, CancellationToken cancellationToken)
        {
            var entity = new Flight
            {
                Origin = request.Origin,
                Destination = request.Destination,
                Departure = request.Departure,
                Arrival = request.Arrival,
                Status = request.Status,
            };

            _context.Flights.Add(entity);

            await _context.SaveChangesAsync(cancellationToken);

            return entity.Id;
        }
    }
}
