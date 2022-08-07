namespace SharedKernel.Interfaces;

/// <inheritdoc cref="DateTime" />
public interface IDateTime
{
    /// <inheritdoc cref="DateTime.Now" />
    DateTime Now { get; }

    /// <inheritdoc cref="DateTime.UtcNow" />
    DateTime UtcNow { get; }
}
