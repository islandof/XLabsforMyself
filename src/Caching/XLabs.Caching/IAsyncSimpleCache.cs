﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace XLabs.Caching
{
    public interface IAsyncSimpleCache : IDisposable
    {
        /// <summary>
        /// Removes the specified item from the cache.
        /// </summary>
        /// <param name="key">The identifier for the item to delete.</param>
        /// <returns>
        /// True if the item was successfully removed from the cache; false otherwise.
        /// </returns>
        Task<bool> RemoveAsync(string key);

        /// <summary>
        /// Removes the cache for all the keys provided.
        /// </summary>
        /// <param name="keys">The keys to remove.</param>
        Task RemoveAllAsync(IEnumerable<string> keys);

        /// <summary>
        /// Retrieves the specified item from the cache.
        /// </summary>
        /// <typeparam name="T">Type of item.</typeparam>
        /// <param name="key">The identifier for the item to retrieve.</param>
        /// <returns>
        /// The retrieved item, or <value>null</value> if the key was not found.
        /// </returns>
        Task<T> GetAsync<T>(string key);

        /// <summary>
        /// Adds a new item into the cache at the specified cache key only if the cache is empty.
        /// </summary>
        /// <typeparam name="T">Type of item.</typeparam>
        /// <param name="key">The key used to reference the item.</param>
        /// <param name="value">The object to be inserted into the cache.</param>
        /// <returns>True if item was added, otherwise false.</returns>
        /// <remarks>The item does not expire unless it is removed due memory pressure.</remarks>
        Task<bool> AddAsync<T>(string key, T value);

        /// <summary>
        /// Sets an item into the cache at the cache key specified regardless if it already exists or not.
        /// </summary>
        /// <typeparam name="T">Type of item.</typeparam>
        /// <param name="key">Key for the item.</param>
        /// <param name="value">Item to set.</param>
        /// <returns>True if item was added, otherwise false.</returns>
        Task<bool> SetAsync<T>(string key, T value);

        /// <summary>
        /// Replaces the item at the cache.
        /// </summary>
        /// <typeparam name="T">Type of item.</typeparam>
        /// <param name="key">Key for the item to replace.</param>
        /// <param name="value">Item to replace with.</param>
        /// <returns>True if the item exists, otherwise false.</returns>
        Task<bool> ReplaceAsync<T>(string key, T value);

        /// <summary>
        /// Invalidates all data on the cache.
        /// </summary>
        Task FlushAllAsync();

        /// <summary>
        /// Retrieves multiple items from the cache. 
        /// The default value of T is set for all keys that do not exist.
        /// </summary>
        /// <typeparam name="T">Type of values to get.</typeparam>
        /// <param name="keys">The list of identifiers for the items to retrieve.</param>
        /// <returns>
        /// a Dictionary holding all items indexed by their key.
        /// </returns>
        Task<IDictionary<string, T>> GetAllAsync<T>(IEnumerable<string> keys);

        /// <summary>
        /// Sets multiple items to the cache. 
        /// </summary>
        /// <typeparam name="T">Type of values to set.</typeparam>
        /// <param name="values">The values.</param>
        Task SetAllAsync<T>(IDictionary<string, T> values);
    }
}
