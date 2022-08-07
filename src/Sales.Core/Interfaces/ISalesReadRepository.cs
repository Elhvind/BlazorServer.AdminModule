using SharedKernel.Interfaces;

namespace Sales.Core.Interfaces;

public interface ISalesReadRepository<T> : IReadRepository<T> where T : class, IAggregateRoot
{
}
