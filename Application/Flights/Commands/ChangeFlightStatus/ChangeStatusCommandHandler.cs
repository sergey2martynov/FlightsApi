using Application.Common.Interfaces;
using Domain.Exceptions;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace Application.Flights.Commands.ChangeFlightStatus
{
    public class ChangeStatusCommandHandler : IRequestHandler<ChangeStatusCommand>
    {
        private readonly IApplicationDbContext _context;

        public ChangeStatusCommandHandler(IApplicationDbContext context)
        {
            _context = context;
        }

        public async Task Handle(ChangeStatusCommand request, CancellationToken cancellationToken)
        {
            var flight = await _context.Flights.Where(f => f.Id == request.FlightId).SingleOrDefaultAsync();

            if (flight == null)
            {
                throw new NotFoundException($"Flight with id {request.FlightId} not found.");
            }

            flight.Status = request.Status;
            await _context.SaveChangesAsync(cancellationToken);
        }
    }
}
