﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace XLabs.Caching
{
    public interface IAsyncCacheProvider : IAsyncSimpleCache
    {
        /// <summary>
        /// Adds a new item into the cache at the specified cache key only if the cache is empty.
        /// </summary>
        /// <typeparam name="T">Type of item.</typeparam>
        /// <param name="key">Key for the item.</param>
        /// <param name="value">Item to add.</param>
        /// <param name="expiresAt">Expiration time.</param>
        /// <returns>True if item was added, otherwise false.</returns>
        Task<bool> AddAsync<T>(string key, T value, DateTime expiresAt);

        /// <summary>
        /// Sets an item into the cache at the cache key specified regardless if it already exists or not.
        /// </summary>
        /// <typeparam name="T">Type of item.</typeparam>
        /// <param name="key">Key for the item.</param>
        /// <param name="value">Item to set.</param>
        /// <param name="expiresAt">Expiration time.</param>
        /// <returns>True if item was set, otherwise false.</returns>
        Task<bool> Set<T>(string key, T value, DateTime expiresAt);

        /// <summary>
        /// Replaces the item at the cache.
        /// </summary>
        /// <typeparam name="T">Type of item.</typeparam>
        /// <param name="key">Key for the item to replace.</param>
        /// <param name="value">Item to replace with.</param>
        /// <param name="expiresAt">Expiration time.</param>
        /// <returns>True if the item exists, otherwise false.</returns>
        Task<bool> Replace<T>(string key, T value, DateTime expiresAt);

        /// <summary>
        /// Adds a new item into the cache at the specified cache key only if the cache is empty.
        /// </summary>
        /// <typeparam name="T">Type of item.</typeparam>
        /// <param name="key">Key for the item.</param>
        /// <param name="value">Item to add.</param>
        /// <param name="expiresIn">Expiration timespan.</param>
        /// <returns>True if item was added, otherwise false.</returns>
        Task<bool> Add<T>(string key, T value, TimeSpan expiresIn);

        /// <summary>
        /// Sets an item into the cache at the cache key specified regardless if it already exists or not.
        /// </summary>
        /// <typeparam name="T">Type of item.</typeparam>
        /// <param name="key">Key for the item.</param>
        /// <param name="value">Item to set.</param>
        /// <param name="expiresIn">Expiration timespan.</param>
        /// <returns>True if item was set, otherwise false.</returns>
        Task<bool> Set<T>(string key, T value, TimeSpan expiresIn);

        /// <summary>
        /// Replaces an item in the cache.
        /// </summary>
        /// <typeparam name="T">Type of item.</typeparam>
        /// <param name="key">Key for the item to replace.</param>
        /// <param name="value">Item to replace with.</param>
        /// <param name="expiresIn">Expiration timespan.</param>
        /// <returns>True if item was replaced, otherwise false.</returns>
        Task<bool> Replace<T>(string key, T value, TimeSpan expiresIn);
    }
}
