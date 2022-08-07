using Shared.Domain.Interfaces;

namespace Sales.Application.Interfaces;

public interface ISalesRepository<T> : IRepository<T> where T : class, IAggregateRoot
{
}
