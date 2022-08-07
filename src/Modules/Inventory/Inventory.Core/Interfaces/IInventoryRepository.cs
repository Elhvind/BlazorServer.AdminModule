using SharedKernel.Interfaces;

namespace Inventory.Core.Interfaces;

public interface IInventoryRepository<T> : IRepository<T> where T : class, IAggregateRoot
{
}
