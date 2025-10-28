using Microsoft.Extensions.Caching.Memory;
using Sum_Cubits_Application.Application.Interfaces;

namespace Sum_Cubits_Application.Infrastructure.Services
{
    public class CacheService : ICacheService
    {
        private readonly IMemoryCache _memoryCache;

        public CacheService(
            IMemoryCache memoryCache)
        {
            _memoryCache = memoryCache;
        }

        public bool Exists(object key)
        {
            return _memoryCache.Get(key) != null;
        }

        public TEntity? Get<TEntity>(object key)
        {
            return _memoryCache.Get<TEntity>(key);
        }

        public void Set(object key, object? value)
        {
            var expiration = TimeSpan.FromMinutes(30);
            _memoryCache.Set(key, value, expiration);
        }

        public void Remove(object key)
        {
            _memoryCache.Remove(key);
        }
    }
