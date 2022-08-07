using Shared.Domain.Interfaces;

namespace Inventory.Core.Interfaces;

public interface ICatalogRepository<T> : IRepository<T> where T : class, IAggregateRoot
{
}
