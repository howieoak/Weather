using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Spring.Caching;

namespace Weather.Infrastructure.Caching
{
    public class ExpiringCache : AbstractCache, ICache
    {
        private static object obj = new object();

        private Dictionary<object, ExpireCacheItem> cache = new Dictionary<object, ExpireCacheItem>();

        #region ICache Members

        public override void Clear()
        {
            lock (obj)
            {
                if (cache != null)
                    cache.Clear();
            }
        }

        public override int Count
        {
            get
            {
                return (cache != null) ? cache.Count() : 0;
            }
        }

        public override object Get(object key)
        {
            object o = null;

            lock (obj)
            {
                try
                {
                    if (cache == null)
                        o = null;

                    ExpireCacheItem exi = cache[key];

                    o = (exi != null) ? exi.Data : null;
                }
                catch
                {
                    o = null;
                }
            }

            return o;
        }

        public override void Insert(object key, object value, TimeSpan timeToLive)
        {
            lock (obj)
            {
                if (cache.ContainsKey(key))
                {
                    cache.Remove(key);
                }

                cache.Add(key, new ExpireCacheItem(value, timeToLive));
            }
        }

        public override void Insert(object key, object value)
        {
            lock (obj)
            {
                if (cache.ContainsKey(key))
                {
                    cache.Remove(key);
                }

                cache.Add(key, new ExpireCacheItem(value));
            }
        }

        public override System.Collections.ICollection Keys
        {
            get { return cache.Keys; }
        }

        public override void Remove(object key)
        {
            lock (obj)
            {
                if (cache == null)
                    return;

                cache.Remove(key);
            }
        }

        public override void RemoveAll(System.Collections.ICollection keys)
        {
            lock (obj)
            {
                foreach (object key in keys)
                    cache.Remove(key);
            }
        }

        #endregion

        protected override void DoInsert(object key, object value, TimeSpan timeToLive)
        {
            Insert(key, value, timeToLive);
        }


    }
}
