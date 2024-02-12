using Domain.Entites;
using Microsoft.EntityFrameworkCore;

namespace Application.Common.Interfaces
{
    public interface IApplicationDbContext
    {
        DbSet<Flight> Flights { get; }
        Task<int> SaveChangesAsync(CancellationToken cancellationToken);
    }
}
