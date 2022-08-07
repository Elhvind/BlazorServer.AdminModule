using Ardalis.Specification.EntityFrameworkCore;
using Sales.Application.Interfaces;
using Shared.Domain.Interfaces;

namespace Sales.Infrastructure.Persistence;

public class EfRepository<T> : RepositoryBase<T>, ISalesRepository<T> where T : class, IAggregateRoot
{
    public EfRepository(SalesDbContext dbContext) : base(dbContext)
    {
    }
}
