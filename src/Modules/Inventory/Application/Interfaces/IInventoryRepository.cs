using Shared.Domain.Interfaces;

namespace Inventory.Application.Interfaces;

public interface IInventoryRepository<T> : IRepository<T> where T : class, IAggregateRoot
{
}
