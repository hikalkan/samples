using System;
using System.Collections.Generic;

namespace SingletonVsStatic.StaticLib
{
    public static class StaticCache
    {
        private static readonly IDictionary<string, object> _cacheDictionary;

        static StaticCache()
        {
            _cacheDictionary = new Dictionary<string, object>();
        }

        public static void Add(string key, object value)
        {
            lock (_cacheDictionary)
            {
                _cacheDictionary[key] = value;
            }
        }

        public static object GetOrNull(string key)
        {
            lock (_cacheDictionary)
            {
                if (_cacheDictionary.TryGetValue(key, out object value))
                {
                    return value;
                }

                return null;
            }
        }

        public static object GetOrAdd(string key, Func<object> factory)
        {
            lock (_cacheDictionary)
            {
                var value = GetOrNull(key);
                if (value != null)
                {
                    return value;
                }

                value = factory();
                Add(key, value);

                return value;
            }
        }

        public static void Clear()
        {
            lock (_cacheDictionary)
            {
                _cacheDictionary.Clear();
            }
        }

        public static bool Remove(string key)
        {
            lock (_cacheDictionary)
            {
                return _cacheDictionary.Remove(key);
            }
        }

        public static int GetCount()
        {
            lock (_cacheDictionary)
            {
                return _cacheDictionary.Count;
            }
        }
    }
}
