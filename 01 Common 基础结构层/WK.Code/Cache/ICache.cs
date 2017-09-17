using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace WK.Code
{
    /// <summary>
    /// 接口 ICache
    /// </summary>
    public interface ICache
    {
        /// <summary>
        /// 获取Cache
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="cacheKey"></param>
        /// <returns></returns>
        T GetCache<T>(string cacheKey) where T : class;


        /// <summary>
        /// 添加Cache
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="value"></param>
        /// <param name="cacheKey"></param>
        void WriteCache<T>(T value, string cacheKey) where T : class;


        /// <summary>
        /// 添加Cache(设定缓存时间)
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="value"></param>
        /// <param name="cacheKey"></param>
        /// <param name="expireTime"></param>
        void WriteCache<T>(T value, string cacheKey, DateTime expireTime) where T : class;


        /// <summary>
        /// 移除某个Cache
        /// </summary>
        /// <param name="cacheKey"></param>
        void RemoveCache(string cacheKey);


        /// <summary>
        /// 移除所有Cache
        /// </summary>
        void RemoveCache();

    }
}
