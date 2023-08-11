using System;
using System.Collections.Generic;
using System.Runtime.Caching;

namespace FileCabinetAppOOP.Caching
{
    public class MemoryCacheManager : ICacheManager
    {
        private readonly MemoryCache cache;

        public MemoryCacheManager()
        {
            cache = MemoryCache.Default;
        }

        public void Add<T>(string key, T value, TimeSpan expirationTime)
        {
            cache.Add(key, value, DateTimeOffset.Now.Add(expirationTime));
        }

        public List<T>? Get<T>(string key) where T : class
        {
            return cache.Get(key) as List<T>;
        }

        public List<T> GetAll<T>() where T : class
        {
            var allItems = new List<T>();
            foreach (var cacheItem in cache)
            {
                if (cacheItem.Value is List<T> items && items.Count > 0)
                {
                    allItems.AddRange(items);
                }
            }
            return allItems;
        }

        public void Remove(string key)
        {
            cache.Remove(key);
        }
    }
}
