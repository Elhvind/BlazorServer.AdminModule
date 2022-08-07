using Ardalis.Specification.EntityFrameworkCore;
using Inventory.Core.Interfaces;
using SharedKernel.Interfaces;

namespace Inventory.Infrastructure.Persistence;

public class EfRepository<T> : RepositoryBase<T>, IInventoryRepository<T> where T : class, IAggregateRoot
{
    public EfRepository(InventoryDbContext dbContext) : base(dbContext)
    {
    }
}
