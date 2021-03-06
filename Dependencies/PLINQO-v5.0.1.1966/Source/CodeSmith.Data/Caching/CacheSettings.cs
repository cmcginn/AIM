﻿using System;
using System.Linq;
using System.Text.RegularExpressions;
using System.Web.Caching;
using System.Collections.Generic;
using CodeSmith.Data.Linq;
using System.Data.Linq;

namespace CodeSmith.Data.Caching
{
    /// <summary>
    /// The cache expiration mode.
    /// </summary>
    public enum CacheExpirationMode
    {
        /// <summary>
        /// The cache item will not expire.
        /// </summary>
        None,
        /// <summary>
        /// The cache item will expire using the Duration property to calculate
        /// the absolute expiration from DateTime.UtcNow.
        /// </summary>
        Duration,
        /// <summary>
        /// The cache item will expire using the Duration property as the
        /// sliding expiration.
        /// </summary>
        Sliding,
        /// <summary>
        /// The cache item will expire on the AbsoluteExpiration DateTime.
        /// </summary>
        Absolute
    }

    /// <summary>
    /// Settings Object for QueryResultCache.FromCache Methods
    /// </summary>
    public class CacheSettings : ICloneable
    {
        #region Constructors

        /// <summary>
        /// Initializes a new instance of the <see cref="CacheSettings"/> class.
        /// </summary>
        public CacheSettings()
        {
            CacheEmptyResult = true;
            Priority = CacheItemPriority.Normal;
            Mode = CacheExpirationMode.None;
            Group = CacheManager.DefaultGroup;
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="CacheSettings"/> class with the specified duration.
        /// </summary>
        /// <param name="duration">The amount of time, in seconds, that a cache entry is to remain in the output cache.</param>
        public CacheSettings(int duration)
            : this()
        {
            Duration = TimeSpan.FromSeconds(duration);
            Mode = CacheExpirationMode.Duration;
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="CacheSettings"/> class with the specified absolute expiration.
        /// </summary>
        /// <param name="absoluteExpiration">The absolute DateTime the cache will expire.</param>
        public CacheSettings(DateTime absoluteExpiration)
            : this()
        {
            AbsoluteExpiration = absoluteExpiration;
            Mode = CacheExpirationMode.Absolute;
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="CacheSettings"/> class with the specified sliding expiration.
        /// </summary>
        /// <param name="slidingExpiration">The sliding expiration.</param>
        public CacheSettings(TimeSpan slidingExpiration)
            : this()
        {
            Duration = slidingExpiration;
            Mode = CacheExpirationMode.Sliding;
        }

        #endregion

        /// <summary>
        /// Gets or sets the cache expiration mode.
        /// </summary>
        /// <value>The cache expiration mode.</value>
        public CacheExpirationMode Mode { get; set; }

        /// <summary>
        /// Gets or sets the cache duration.
        /// </summary>
        /// <value>The cache duration.</value>
        /// <remarks>
        /// <para>
        /// When Mode is Sliding, Duration is the interval between the time the
        /// inserted object was last accessed and the time at which that object expires.
        /// </para>
        /// <para>
        /// When Mode is Duration, Duration is used to calculate the absolute expiration
        /// from DateTime.UtcNow.
        /// </para>
        /// </remarks>
        public TimeSpan Duration { get; set; }

        /// <summary>
        /// Gets or sets the absolute expiration.
        /// </summary>
        /// <value>The absolute expiration.</value>
        /// <remarks>
        /// The time at which the inserted object expires and is removed from the cache. To
        /// avoid possible issues with local time such as changes from standard time to
        /// daylight saving time, use System.DateTime.UtcNow rather than System.DateTime.Now
        /// for this parameter value.
        /// </remarks>
        public DateTime AbsoluteExpiration { get; set; }

        /// <summary>
        /// The cost of the object relative to other items stored in the cache, as
        /// expressed by the System.Web.Caching.CacheItemPriority enumeration. This value is
        /// used by the cache when it evicts objects; objects with a lower cost are removed
        /// from the cache before objects with a higher cost.
        /// </summary>
        public CacheItemPriority Priority { get; set; }

        /// <summary>
        /// Used to determine if an empty result should be cached.
        /// </summary>
        public bool CacheEmptyResult { get; set; }

        /// <summary>
        /// The file or cache key dependencies for the item. When any dependency changes, the
        /// object becomes invalid and is removed from the cache. If there are no
        /// dependencies, this parameter contains null.
        /// </summary>
        public CacheDependency CacheDependency { get; set; }

        /// <summary>
        /// A delegate that, if provided, will be called when an object is removed from the
        /// cache. You can use this to notify applications when their objects are deleted from
        /// the cache.
        /// </summary>
        public CacheItemRemovedCallback CacheItemRemovedCallback { get; set; }

        /// <summary>
        /// Gets or sets the cache provider name.
        /// </summary>
        /// <value>The cache provider name.</value>
        public string Provider { get; set; }

        /// <summary>
        /// Gets or sets the cache group name.
        /// </summary>
        /// <value>The cache group name.</value>
        public string Group { get; set; }

        /// <summary>
        /// Creates a new object that is a copy of the current instance.
        /// </summary>
        /// <returns>
        /// A new object that is a copy of this instance.
        /// </returns>
        public CacheSettings Clone()
        {
            var clone = new CacheSettings
            {
                Mode = Mode,
                Duration = Duration,
                AbsoluteExpiration = AbsoluteExpiration,
                Priority = Priority,
                CacheEmptyResult = CacheEmptyResult,
                CacheDependency = CacheDependency,
                CacheItemRemovedCallback = CacheItemRemovedCallback,
                Provider = Provider,
                Group = Group
            };

            if (String.IsNullOrEmpty(Group))
                clone.Group = CacheManager.DefaultGroup;

            return clone;
        }

        /// <summary>
        /// Creates a new object that is a copy of the current instance.
        /// </summary>
        /// <returns>
        /// A new object that is a copy of this instance.
        /// </returns>
        object ICloneable.Clone()
        {
            return Clone();
        }

        /// <summary>
        /// Creates a new CacheSettings object using the duration specified.
        /// </summary>
        /// <param name="duration">The duration to store the data in the cache.</param>
        /// <returns>A new CacheSettings object with the specified duration.</returns>
        public static CacheSettings FromDuration(int duration)
        {
            return new CacheSettings(duration);
        }

        /// <summary>
        /// Creates a new CacheSettings object using the duration specified.
        /// </summary>
        /// <param name="expiration">The date to expire the data in the cache.</param>
        /// <returns>A new CacheSettings object with the specified duration.</returns>
        public static CacheSettings FromAbsolute(DateTime expiration)
        {
            return new CacheSettings(expiration);
        }

        /// <summary>
        /// Creates a new CacheSettings object using the named profile.
        /// </summary>
        /// <param name="profile">The cache profile name.</param>
        /// <returns>A new CacheSettings object with settings from the named profile.</returns>
        public static CacheSettings FromProfile(string profile)
        {
            return CacheManager.GetProfile(profile);
        }
    }

    public static class CacheSettingsExtensions
    {
        public static CacheSettings WithDuration(this CacheSettings settings, int duration)
        {
            settings.Duration = TimeSpan.FromSeconds(duration);
            settings.Mode = CacheExpirationMode.Duration;
            return settings;
        }

        public static CacheSettings WithDuration(this CacheSettings settings, TimeSpan duration)
        {
            settings.Duration = duration;
            settings.Mode = CacheExpirationMode.Duration;
            return settings;
        }

        public static CacheSettings WithAbsoluteExpiration(this CacheSettings settings, DateTime absoluteExpiration)
        {
            settings.AbsoluteExpiration = absoluteExpiration;
            settings.Mode = CacheExpirationMode.Absolute;
            return settings;
        }

        public static CacheSettings WithPriority(this CacheSettings settings, CacheItemPriority priority)
        {
            settings.Priority = priority;
            return settings;
        }

        public static CacheSettings WithCacheEmptyResult(this CacheSettings settings, bool cacheEmptyResult)
        {
            settings.CacheEmptyResult = cacheEmptyResult;
            return settings;
        }

        public static CacheSettings WithCacheDependency(this CacheSettings settings, CacheDependency cacheDependency)
        {
            settings.CacheDependency = cacheDependency;
            return settings;
        }

        public static CacheSettings AddCacheDependency(this CacheSettings settings, CacheDependency cacheDependency)
        {
            if (settings.CacheDependency == null)
                settings.CacheDependency = cacheDependency;
            else if (settings.CacheDependency is AggregateCacheDependency)
                (settings.CacheDependency as AggregateCacheDependency).Add(cacheDependency);
            else
            {
                var dependencies = new AggregateCacheDependency();
                dependencies.Add(settings.CacheDependency, cacheDependency);
                settings.CacheDependency = dependencies;
            }
            return settings;
        }

        public static CacheSettings AddCacheDependency(this CacheSettings settings, params CacheDependency[] cacheDependencies)
        {
            return AddCacheDependency(settings, (IEnumerable<CacheDependency>)cacheDependencies);
        }

        public static CacheSettings AddCacheDependency(this CacheSettings settings, IEnumerable<CacheDependency> cacheDependencies)
        {
            if (cacheDependencies != null)
            {
                if (settings.CacheDependency is AggregateCacheDependency)
                {
                    var agregateDependency = settings.CacheDependency as AggregateCacheDependency;
                    foreach (var dependency in cacheDependencies)
                        agregateDependency.Add(dependency);
                }
                else
                {
                    var agregateDependency = new AggregateCacheDependency();
                    if (settings.CacheDependency != null)
                        agregateDependency.Add(settings.CacheDependency);
                    
                    foreach (var dependency in cacheDependencies)
                        agregateDependency.Add(dependency);
                    
                    settings.CacheDependency = agregateDependency;
                }
            }
            return settings;
        }

        public static CacheSettings AddCacheDependency(this CacheSettings settings, params SqlCacheDependency[] cacheDependencies)
        {
            return AddCacheDependency(settings, cacheDependencies.Cast<CacheDependency>());
        }

        public static CacheSettings AddCacheDependency(this CacheSettings settings, string databaseName, params string[] sqlCacheDependencyTableNames)
        {
            if (sqlCacheDependencyTableNames == null)
                return settings;
            
            var cacheDependencies = sqlCacheDependencyTableNames.Select(t => new SqlCacheDependency(databaseName, t));
            return AddCacheDependency(settings, cacheDependencies.Cast<CacheDependency>());
        }

        public static CacheSettings AddCacheDependency<T>(this CacheSettings settings, IQueryable<T> queryable, params string[] sqlCacheDependencyTableNames)
        {
            return AddCacheDependency(settings, queryable.GetDataContext().Connection.Database, sqlCacheDependencyTableNames);
        }

        public static CacheSettings AddCacheDependency(this CacheSettings settings, string databaseName, params ITable[] sqlCacheDependencyTables)
        {
            if (sqlCacheDependencyTables == null)
                return settings;
            
            var cacheDependencies = sqlCacheDependencyTables.Select(t => new SqlCacheDependency(databaseName, t.TableName()));
            return AddCacheDependency(settings, cacheDependencies.Cast<CacheDependency>());
        }

        public static CacheSettings AddCacheDependency<T>(this CacheSettings settings, IQueryable<T> queryable, params ITable[] sqlCacheDependencyTables)
        {
            return AddCacheDependency(settings, queryable.GetDataContext().Connection.Database, sqlCacheDependencyTables);
        }

        public static CacheSettings WithCacheItemRemovedCallback(this CacheSettings settings, CacheItemRemovedCallback cacheItemRemovedCallback)
        {
            settings.CacheItemRemovedCallback = cacheItemRemovedCallback;
            return settings;
        }

        public static CacheSettings WithProvider(this CacheSettings settings, string provider)
        {
            settings.Provider = provider;
            return settings;
        }

        public static CacheSettings WithGroup(this CacheSettings settings, string group)
        {
            settings.Group = group;
            return settings;
        }
    }
}
