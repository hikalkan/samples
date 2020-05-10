using System;

namespace SingletonVsStatic.SingletonLib.Tests
{
    public static class MySingletonCacheExtensions
    {
        public static object GetOrThrowException(this SingletonCache singletonCache, string key)
        {
            var value = singletonCache.GetOrNull(key);

            if (value == null)
            {
                throw new ApplicationException("Given key was not present in the cache: " + key);
            }

            return value;
        }
    }
}
