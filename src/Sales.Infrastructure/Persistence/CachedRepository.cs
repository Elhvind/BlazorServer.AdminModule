﻿using Ardalis.Specification;
using Microsoft.Extensions.Caching.Memory;
using Microsoft.Extensions.Logging;
using Sales.Core.Interfaces;
using Sales.Infrastructure.Persistence;
using SharedKernel.Interfaces;

namespace FrontDesk.Infrastructure.Data;

public class CachedRepository<T> : ISalesReadRepository<T> where T : class, IAggregateRoot
{
    private readonly IMemoryCache _cache;
    private readonly ILogger<CachedRepository<T>> _logger;
    private readonly EfRepository<T> _sourceRepository;
    private MemoryCacheEntryOptions _cacheOptions;

    public CachedRepository(IMemoryCache cache,
        ILogger<CachedRepository<T>> logger,
        EfRepository<T> sourceRepository)
    {
        _cache = cache;
        _logger = logger;
        _sourceRepository = sourceRepository;

        _cacheOptions = new MemoryCacheEntryOptions()
            .SetAbsoluteExpiration(relative: TimeSpan.FromSeconds(10));
    }

    public Task<bool> AnyAsync(ISpecification<T> specification, CancellationToken cancellationToken = default)
    {
        throw new NotImplementedException();
    }

    public Task<bool> AnyAsync(CancellationToken cancellationToken = default)
    {
        throw new NotImplementedException();
    }

    public Task<int> CountAsync(ISpecification<T> specification, CancellationToken cancellationToken = default)
    {
        return _sourceRepository.CountAsync(specification, cancellationToken);
    }

    public Task<int> CountAsync(CancellationToken cancellationToken = default)
    {
        return _sourceRepository.CountAsync(cancellationToken);
    }

    public Task<T?> FirstOrDefaultAsync(ISpecification<T> specification, CancellationToken cancellationToken = default)
    {
        throw new NotImplementedException();
    }

    public Task<TResult?> FirstOrDefaultAsync<TResult>(ISpecification<T, TResult> specification, CancellationToken cancellationToken = default)
    {
        throw new NotImplementedException();
    }

    public Task<T?> GetByIdAsync<TId>(TId id, CancellationToken cancellationToken = default) where TId : notnull
    {
        string key = $"{typeof(T).Name}-{id}";
        _logger.LogInformation("Checking cache for {key}", key);
        return _cache.GetOrCreate(key, entry =>
        {
            entry.SetOptions(_cacheOptions);
            _logger.LogWarning("Fetching source data for {key}", key);
            return _sourceRepository.GetByIdAsync(id, cancellationToken);
        });
    }

    public Task<T?> GetBySpecAsync(ISpecification<T> specification, CancellationToken cancellationToken = default)
    {
        if (specification.CacheEnabled)
        {
            string key = $"{specification.CacheKey}-GetBySpecAsync";
            _logger.LogInformation("Checking cache for {key}", key);
            return _cache.GetOrCreate(key, entry =>
            {
                entry.SetOptions(_cacheOptions);
                _logger.LogWarning("Fetching source data for {key}", key);
                return _sourceRepository.GetBySpecAsync(specification, cancellationToken);
            });
        }
        return _sourceRepository.GetBySpecAsync(specification);
    }

    public Task<TResult?> GetBySpecAsync<TResult>(ISpecification<T, TResult> specification, CancellationToken cancellationToken = default)
    {
        if (specification.CacheEnabled)
        {
            string key = $"{specification.CacheKey}-GetBySpecAsync";
            _logger.LogInformation("Checking cache for " + key);
            return _cache.GetOrCreate(key, entry =>
            {
                entry.SetOptions(_cacheOptions);
                _logger.LogWarning("Fetching source data for " + key);
                return _sourceRepository.GetBySpecAsync(specification, cancellationToken);
            });
        }
        return _sourceRepository.GetBySpecAsync(specification, cancellationToken);
    }

    public Task<List<T>> ListAsync(CancellationToken cancellationToken = default)
    {
        string key = $"{typeof(T).Name}-List";
        _logger.LogInformation($"Checking cache for {key}");
        return _cache.GetOrCreate(key, entry =>
        {
            entry.SetOptions(_cacheOptions);
            _logger.LogWarning($"Fetching source data for {key}");
            return _sourceRepository.ListAsync(cancellationToken);
        });
    }

    public Task<List<T>> ListAsync(ISpecification<T> specification, CancellationToken cancellationToken = default)
    {
        if (specification.CacheEnabled)
        {
            string key = $"{specification.CacheKey}-ListAsync";
            _logger.LogInformation($"Checking cache for {key}");
            return _cache.GetOrCreate(key, entry =>
            {
                entry.SetOptions(_cacheOptions);
                _logger.LogWarning($"Fetching source data for {key}");
                return _sourceRepository.ListAsync(specification, cancellationToken);
            });
        }
        return _sourceRepository.ListAsync(specification, cancellationToken);
    }

    public Task<List<TResult>> ListAsync<TResult>(ISpecification<T, TResult> specification, CancellationToken cancellationToken = default)
    {
        if (specification.CacheEnabled)
        {
            string key = $"{specification.CacheKey}-ListAsync";
            _logger.LogInformation("Checking cache for {key}", key);
            return _cache.GetOrCreate(key, entry =>
            {
                entry.SetOptions(_cacheOptions);
                _logger.LogWarning("Fetching source data for {key}", key);
                return _sourceRepository.ListAsync(specification, cancellationToken);
            });
        }
        return _sourceRepository.ListAsync(specification, cancellationToken);
    }

    public Task<T?> SingleOrDefaultAsync(ISingleResultSpecification<T> specification, CancellationToken cancellationToken = default)
    {
        throw new NotImplementedException();
    }

    public Task<TResult?> SingleOrDefaultAsync<TResult>(ISingleResultSpecification<T, TResult> specification, CancellationToken cancellationToken = default)
    {
        throw new NotImplementedException();
    }
}