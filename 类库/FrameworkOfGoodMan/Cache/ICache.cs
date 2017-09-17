using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace FrameworkOfGoodMan.Tools.Cache
{
    /// <summary>
    /// 缓存接口
    /// </summary>
    public interface ICache
    {
        /// <summary>
        /// 获取值
        /// </summary>
        /// <param name="key">键</param>
        /// <returns>值</returns>
        object Get(string key);

        /// <summary>
        /// 获取值
        /// </summary>
        /// <param name="key">键</param>
        ///<returns>值</returns>
        T Get<T>(string key);

        /// <summary>
        /// 添加指定Key的对象
        /// </summary>
        /// <param name="key">键</param>
        /// <param name="obj">值</param>
        bool Add(string key, object obj);

        /// <summary>
        /// 添加指定Key的对象
        /// </summary>
        /// <param name="key">键</param>
        /// <param name="obj">值</param>
        /// <param name="TimeOut">到期时间</param>
        bool Add(string key, object obj, DateTime TimeOut);

        /// <summary>
        /// 更新指定Key的对象
        /// </summary>
        /// <param name="key"></param>
        /// <param name="obj"></param>
        /// <returns></returns>
        bool Set(string key, object obj);

        /// <summary>
        /// 更新指定Key的对象
        /// </summary>
        /// <param name="key"></param>
        /// <param name="obj"></param>
        /// <param name="TimeOut">到期时间</param>
        /// <returns></returns>
        bool Set(string key, object obj, DateTime TimeOut);

        /// <summary>
        /// 移除指定key的对象
        /// </summary>
        /// <param name="key">键</param>
        bool Delete(string key);
    }
}
