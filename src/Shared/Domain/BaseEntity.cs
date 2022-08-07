using System.ComponentModel.DataAnnotations.Schema;

namespace Shared.Domain;

public abstract class BaseEntity
{
    public int Id { get; set; }

    private readonly List<BaseDomainEvent> _domainEvents = new();

    [NotMapped]
    public IReadOnlyCollection<BaseDomainEvent> DomainEvents => _domainEvents.AsReadOnly();

    public void AddDomainEvent(BaseDomainEvent domainEvent)
    {
        _domainEvents.Add(domainEvent);
    }

    public void RemoveDomainEvent(BaseDomainEvent domainEvent)
    {
        _domainEvents.Remove(domainEvent);
    }

    public void ClearDomainEvents()
    {
        _domainEvents.Clear();
    }
}
