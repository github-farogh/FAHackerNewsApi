using FA_Hacker_News_API.Interface;
using System.Runtime.Caching;

namespace FA_Hacker_News_API.Implementation
{
    public class CacheService : ICacheService
    {
        ObjectCache _memoryCache = MemoryCache.Default;

        /// <summary>
        /// Get Cache Data
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="key"></param>
        /// <returns></returns>
        public T GetCacheData<T>(string key)
        {
            try
            {
                T item = (T)_memoryCache.Get(key);
                return item;
            }
            catch (Exception ex)
            {
                throw;
            }
        }

        /// <summary>
        /// Set Cache Data
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="key"></param>
        /// <param name="value"></param>
        /// <param name="expirationTime"></param>
        /// <returns></returns>
        public bool SetCacheData<T>(string key, T value, DateTimeOffset expirationTime)
        {
            bool res = true;
            try
            {
                if (!string.IsNullOrEmpty(key))
                {
                    _memoryCache.Set(key, value, expirationTime);
                }
            }
            catch (Exception ex)
            {
                throw;
            }
            return res;
        }
    }
}
