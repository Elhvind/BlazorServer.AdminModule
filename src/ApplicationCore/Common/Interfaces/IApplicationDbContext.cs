using Domain.Entities;
using Microsoft.EntityFrameworkCore;

namespace ApplicationCore.Common.Interfaces;

public interface IApplicationDbContext
{
    DbSet<Application> Applications { get; }
    DbSet<Voucher> Vouchers { get; }

    Task<int> SaveChangesAsync(CancellationToken cancellationToken);
}
