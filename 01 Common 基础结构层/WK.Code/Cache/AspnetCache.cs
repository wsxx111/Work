using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Web;

namespace WK.Code.Cache
{
    public class AspnetCache:ICache
    {
        static object lockObj = new object();
        private static System.Web.Caching.Cache cache = HttpRuntime.Cache;
        private static AspnetCache instance = null;

        public static AspnetCache Instance
        {
            get
            {
                if (instance == null)
                {
                    lock (lockObj)
                    {
                        if (instance == null)
                        {
                            instance = new AspnetCache();
                        }
                    }
                }
                return instance;
            }
        }

        private AspnetCache()
        {
        }

        //获取cache
        public T GetCache<T>(string cacheKey) where T : class
        {
            if (cache[cacheKey] != null)
            {
                return (T)cache[cacheKey];
            }
            return default(T);
        }

        //添加cache , 默认10分钟
        public void WriteCache<T>(T value, string cacheKey) where T : class
        {
            cache.Insert(cacheKey, value, null, DateTime.Now.AddMinutes(10), System.Web.Caching.Cache.NoSlidingExpiration);
        }

        //添加指定时间cache
        public void WriteCache<T>(T value, string cacheKey, DateTime expireTime) where T : class
        {
            cache.Insert(cacheKey, value, null, expireTime, System.Web.Caching.Cache.NoSlidingExpiration);
        }

        //移除某个cache
        public void RemoveCache(string cacheKey)
        {
            cache.Remove(cacheKey);
        }

        //移除所有cache
        public void RemoveCache()
        {
            IDictionaryEnumerator CacheEnum = cache.GetEnumerator();
            while (CacheEnum.MoveNext())
            {
                cache.Remove(CacheEnum.Key.ToString());
            }
        }
    }
}
