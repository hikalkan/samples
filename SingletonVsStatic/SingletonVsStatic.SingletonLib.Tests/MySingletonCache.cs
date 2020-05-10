using System;

namespace SingletonVsStatic.SingletonLib.Tests
{
    public class MySingletonCache : SingletonCache
    {
        public static void Replace()
        {
            SingletonCache.Instance = new MySingletonCache();
        }

        public override void Add(string key, object value)
        {
            if (value == null)
            {
                throw new ArgumentNullException(nameof(value));
            }

            base.Add(key, value);
        }
    }
}
