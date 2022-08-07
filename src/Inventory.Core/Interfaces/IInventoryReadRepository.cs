using SharedKernel.Interfaces;

namespace Inventory.Core.Interfaces;

public interface IInventoryReadRepository<T> : IReadRepository<T> where T : class, IAggregateRoot
{
}
