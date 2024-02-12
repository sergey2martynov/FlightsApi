using Application.Common.Interfaces;
using AutoMapper;
using AutoMapper.QueryableExtensions;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace Application.Flights.Queries.GetAll
{
    public class GetFlightListQueryHandler : IRequestHandler<GetFlightListQuery, FlightListVm>
    {
        private readonly IApplicationDbContext _context;
        private readonly IMapper _mapper;

        public GetFlightListQueryHandler(IApplicationDbContext context, IMapper mapper) 
        {
            _context = context;
            _mapper = mapper;
        }

        public async Task<FlightListVm> Handle(GetFlightListQuery request, CancellationToken cancellationToken)
        {
            var flights = await _context.Flights.AsNoTracking()
                .ProjectTo<FlightLookupDto>(_mapper.ConfigurationProvider)
                .ToListAsync(cancellationToken);

            return new FlightListVm { Flights = flights };
        }
    }
}
