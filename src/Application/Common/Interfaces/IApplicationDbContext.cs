using Domain.Entities;
using Microsoft.EntityFrameworkCore;

namespace Application.Common.Interfaces;

public interface IApplicationDbContext
{
    DbSet<Voucher> Vouchers { get; }

    Task<int> SaveChangesAsync(CancellationToken cancellationToken);
}
