using FA_Hacker_News_API.Models;
using Microsoft.AspNetCore.Mvc;

namespace FA_Hacker_News_API.Interface
{
    public interface ICacheService
    {
        /// <summary>
        /// Get cache data using key
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="key"></param>
        /// <returns></returns>
        T GetCacheData<T>(string key);

        /// <summary>
        /// Set cache data with Expiration Time of Key
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="key"></param>
        /// <param name="value"></param>
        /// <param name="expirationTime"></param>
        /// <returns></returns>
        bool SetCacheData<T>(string key, T value, DateTimeOffset expirationTime);
    }
}
