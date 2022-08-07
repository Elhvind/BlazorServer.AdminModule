using SharedKernel.Interfaces;

namespace Sales.Core.Interfaces;

public interface ISalesRepository<T> : IRepository<T> where T : class, IAggregateRoot
{
}
