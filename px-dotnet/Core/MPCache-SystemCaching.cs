#if NETSTANDARD2_0

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Web;

namespace MercadoPago
{
    /// <summary>
    /// Class for managing cached resources.
    /// </summary>
    internal class MPCache
    {
        /// <summary>
        /// Adds a response to the cache structure.
        /// </summary>
        /// <param name="key">Key representing the URL.</param>
        /// <param name="response">Response representing the response of the given URL parameter.</param>
        public static void AddToCache(string key, MPAPIResponse response) 
        {
            try
            {
                System.Runtime.Caching.MemoryCache.Default.Add(key, response, DateTime.MaxValue);
            }
            catch (Exception ex)
            {
                throw new MPException("An error has occured in the cache structure (ADD): " + ex.Message);
            }
        }

        /// <summary>
        /// Retrieves a cached response from cache structure.
        /// </summary>
        /// <param name="key">Key that will return its associated value.</param>
        /// <returns>Cached response.</returns>
        public static MPAPIResponse GetFromCache(string key)
        {
            try
            {
                return System.Runtime.Caching.MemoryCache.Default.Get(key) as MPAPIResponse;
            }
            catch (Exception ex)
            {
                throw new MPException("An error has occured in the cache structure (GET): " + ex.Message);
            }            
        }

        /// <summary>
        /// Remove a specified item from cache.
        /// </summary>
        /// <param name="key">Key of the element to remove from cache.</param>
        public static void RemoveFromCache(string key)
        {
            try
            {
                System.Runtime.Caching.MemoryCache.Default.Remove(key);
            }
            catch (Exception ex)
            {
                throw new MPException("An error has occured in the cache structure (REMOVE): " + ex.Message);
            }            
        }
    }
}

#endif
