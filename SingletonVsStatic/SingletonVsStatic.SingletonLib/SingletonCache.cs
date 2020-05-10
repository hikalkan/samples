using System;
using System.Collections.Generic;

namespace SingletonVsStatic.SingletonLib
{
    public class SingletonCache
    {
        public static SingletonCache Instance { get; protected set; } = new SingletonCache();

        private readonly IDictionary<string, object> _cacheDictionary;
        
        protected internal SingletonCache()
        {
            _cacheDictionary = new Dictionary<string, object>();
        }

        public virtual void Add(string key, object value)
        {
            lock (_cacheDictionary)
            {
                _cacheDictionary[key] = value;
            }
        }

        public virtual object GetOrNull(string key)
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

        public virtual object GetOrAdd(string key, Func<object> factory)
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

        public virtual void Clear()
        {
            lock (_cacheDictionary)
            {
                _cacheDictionary.Clear();
            }
        }

        public virtual bool Remove(string key)
        {
            lock (_cacheDictionary)
            {
                return _cacheDictionary.Remove(key);
            }
        }

        public virtual int GetCount()
        {
            lock (_cacheDictionary)
            {
                return _cacheDictionary.Count;
            }
        }
    }
}
