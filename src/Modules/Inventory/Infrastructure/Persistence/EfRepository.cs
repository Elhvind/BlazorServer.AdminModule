using Ardalis.Specification.EntityFrameworkCore;
using Inventory.Application.Interfaces;
using Shared.Domain.Interfaces;

namespace Inventory.Infrastructure.Persistence;

public class EfRepository<T> : RepositoryBase<T>, IInventoryRepository<T> where T : class, IAggregateRoot
{
    public EfRepository(InventoryDbContext dbContext) : base(dbContext)
    {
    }
}
