using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace WK.Code.MemCache
{
    /// <summary>
    /// MemCache缓存策略
    /// </summary>
    public class SlMemCached
    {
        /// <summary>
        /// 缓存客户端对象
        /// </summary>
        public SlMemcachedClient memcachedClient;
        /// <summary>
        /// 构造方法
        /// </summary>
        /// <param name="client"></param>
        public SlMemCached(SlMemcachedClient client)
        {
            memcachedClient = client;
        }
        /// <summary>
        /// 判断主键是否存在
        /// </summary>
        /// <param name="key"></param>
        /// <returns></returns>
        public bool KeyExists(string key)
        {
            return memcachedClient.CacheClient.KeyExists(key);
        }
        /// <summary>
        /// 获取memcached缓存
        /// </summary>
        /// <param name="key"></param>
        /// <returns></returns>
        public object Get(string key)
        {
            return memcachedClient.CacheClient.Get(key);
        }
        /// <summary>
        /// 获取memcached缓存
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="key"></param>
        /// <returns></returns>
        public T Get<T>(string key)
        {
            return (T)memcachedClient.CacheClient.Get(key);
        }
        /// <summary>
        /// 添加memcached缓存
        /// </summary>
        /// <param name="key"></param>
        /// <param name="obj"></param>
        /// <returns></returns>
        public bool Add(string key, object obj)
        {
            Delete(key);
            return memcachedClient.CacheClient.Set(key, obj);
        }
        /// <summary>
        /// 添加memcached缓存并设置超时时间
        /// </summary>
        /// <param name="key"></param>
        /// <param name="obj"></param>
        /// <param name="timeOut"></param>
        /// <returns></returns>
        public bool Add(string key, object obj, DateTime timeOut)
        {
            Delete(key);
            return memcachedClient.CacheClient.Set(key, obj, timeOut);
        }
        /// <summary>
        /// 添加memcached缓存
        /// </summary>
        /// <param name="key"></param>
        /// <param name="obj"></param>
        /// <returns></returns>
        public bool Set(string key, object obj)
        {
            return memcachedClient.CacheClient.Set(key, obj, DateTime.Now.AddHours(1));
        }
        /// <summary>
        /// 添加memcached缓存
        /// </summary>
        /// <param name="key"></param>
        /// <param name="obj"></param>
        /// <param name="validateTime"></param>
        /// <returns></returns>
        public bool Set(string key, object obj, DateTime validateTime)
        {
            return memcachedClient.CacheClient.Set(key, obj, validateTime);
        }
        /// <summary>
        /// 添加memcached缓存
        /// </summary>
        /// <param name="key"></param>
        /// <param name="obj"></param>
        /// <param name="hours"></param>
        /// <returns></returns>
        public bool Set(string key, object obj, int hours)
        {
            return memcachedClient.CacheClient.Set(key, obj, DateTime.Now.AddHours(hours));
        }
        /// <summary>
        /// 获取多个memcached缓存
        /// </summary>
        /// <param name="keys"></param>
        /// <returns>Hashtable</returns>
        public Hashtable GetMultiple(string[] keys)
        {
            return memcachedClient.CacheClient.GetMultiple(keys);
        }
        /// <summary>
        /// 删除memcached缓存
        /// </summary>
        /// <param name="key"></param>
        /// <returns></returns>
        public bool Delete(string key)
        {
            return memcachedClient.CacheClient.Delete(key);
        }

        #region 状态查询
        /// <summary>
        /// memcached状态查询
        /// </summary>
        /// <returns></returns>
        public IDictionary GetStats()
        {
            return (IDictionary)memcachedClient.CacheClient.Stats();
        }
        #endregion
    }
}
