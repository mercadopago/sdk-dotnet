using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace MercadoPago
{
    public class MPCache
    {
        public static System.Web.Caching.Cache cache = null;

        public static System.Web.Caching.Cache GetCache()
        {
            if (cache == null)
            {
                cache = new System.Web.Caching.Cache();
            }

            return cache;
        }


        /// <summary>
        /// Adds a response to the cache structure.
        /// </summary>
        /// <param name="key">Key representing the URL.</param>
        /// <param name="response">Response representing the response of the given URL parameter.</param>
        public static void AddToCache(string key, MPAPIResponse response) 
        {
            try
            {
                System.Web.HttpRuntime.Cache.Add(key, response, null, DateTime.MaxValue, new TimeSpan(0, 60, 0), System.Web.Caching.CacheItemPriority.Default, null);                                
            }
            catch (Exception ex)
            {
                Console.Write(ex.Message);
            }
        }

        /// <summary>
        /// Retrieves a cached response from cache structure.
        /// </summary>
        /// <param name="key">Key that will return its associated value.</param>
        /// <returns>Cached response.</returns>
        public static MPAPIResponse GetFromCache(string key)
        {
            
            return (MPAPIResponse)System.Web.HttpRuntime.Cache.Get(key);            
        }

        /// <summary>
        /// Remove a specified item from cache.
        /// </summary>
        /// <param name="key">Key of the element to remove from cache.</param>
        public static void RemoveFromCache(string key)
        {
            System.Web.Caching.Cache mapCache = GetCache();
            mapCache.Remove(key);
        }
    }
}
