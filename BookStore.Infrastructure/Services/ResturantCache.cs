using BookStore.Core.Entities;
using BookStore.Core.Interfaces;
using Microsoft.Extensions.Caching.Memory;

namespace BookStore.Infrastructure.Services
{
    public class ResturantCache : IResturantCache
    {
        private MemoryCache _cache { get; set; }

        private string GetCacheKey(int id) => $"Resturant-{id}";

        public ResturantCache()
        {
            _cache = new MemoryCache(new MemoryCacheOptions
            {
                SizeLimit = 100
            });
        }

        public Resturant Get(int id)
        {
            _cache.TryGetValue(GetCacheKey(id), out Resturant resturant);
            return resturant;
        }

        public void Remove(int id)
        {
            _cache.Remove(GetCacheKey(id));
        }

        public void Set(Resturant resturant)
        {
            var cacheEntryOptions = new MemoryCacheEntryOptions().SetSize(1);
            _cache.Set(GetCacheKey(resturant.Id), resturant, cacheEntryOptions);
        }
    }
}