using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Timers;

namespace Weather.Infrastructure.Caching
{
    public class BaseCacheItem
    {
        protected object _data;
    }

    public class ExpireCacheItem : BaseCacheItem, IDisposable
    {
        private Timer _timer;

        public object Data { get { return _data; } }

        public ExpireCacheItem(object data)
        {
            _data = data;
        }

        public ExpireCacheItem(object data, TimeSpan ts)
            : this(data)
        {
            _timer = new Timer(ts.TotalMilliseconds);
            _timer.Elapsed += new ElapsedEventHandler(_timer_Elapsed);
            _timer.Start();
        }

        void _timer_Elapsed(object sender, ElapsedEventArgs e)
        {
            _data = null;
        }

        #region IDisposable Members

        public void Dispose()
        {
            if (_timer != null)
            {
                _timer.Dispose();
                _timer = null;
            }
        }

        #endregion
    }
}
