using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace FrameworkOfGoodMan.Tools.Cache
{    
    /// <summary>
    /// 对System.Web.HttpContext.Current.Cache的操作
    /// </summary>
   public  class HttpCache:ICache
    {
       private static object syncObject = new object();

       /// <summary>
        /// 构造方法
        /// </summary>
       private HttpCache() { }

       private static HttpCache instance;


       /// <summary>
       /// 获取当前HttpCache唯一实例
       /// </summary>
       public static HttpCache Current
       {
           get
           {
               if (instance == null)
               {

                   lock (syncObject)
                   {
                       if (instance == null)
                       {
                           instance = new HttpCache();
                       }
                   }
               }
               return instance;
           }
       }


       /// <summary>
       /// 获取缓存
       /// </summary>
       /// <param name="key"></param>
       /// <returns></returns>
       public object Get(string key)
       {
           return System.Web.HttpContext.Current.Cache[key];
       }


       /// <summary>
       /// 获取缓存（泛型）
       /// </summary>
       /// <typeparam name="T"></typeparam>
       /// <param name="key"></param>
       /// <returns></returns>
       public T Get<T>(string key)
       {
           return (T)System.Web.HttpContext.Current.Cache[key];
       }


       /// <summary>
       /// 加入缓存
       /// </summary>
       /// <param name="key"></param>
       /// <param name="obj"></param>
       /// <returns></returns>
       public bool Add(string key, object obj)
       {
           System.Web.HttpContext.Current.Cache[key] = obj;
           return true;
       }


       /// <summary>
       /// 加入缓存并设置时间
       /// </summary>
       /// <param name="key"></param>
       /// <param name="obj"></param>
       /// <param name="timeOut"></param>
       /// <returns></returns>
       public bool Add(string key, object obj, DateTime timeOut)
       {
           System.Web.HttpContext.Current.Cache.Insert(key, obj, null, timeOut, System.Web.Caching.Cache.NoSlidingExpiration);
           return true;
       }


       /// <summary>
       /// 重新添加缓存（清除缓存）
       /// </summary>
       /// <param name="key"></param>
       /// <param name="obj"></param>
       /// <param name="timeOut"></param>
       /// <returns></returns>
       public bool Set(string key, object obj, DateTime timeOut)
       {
           Delete(key);
           System.Web.HttpContext.Current.Cache.Insert(key, obj, null, timeOut, System.Web.Caching.Cache.NoSlidingExpiration);
           return true;
       }


       /// <summary>
       /// 重新添加缓存（清除缓存）
       /// </summary>
       /// <param name="key"></param>
       /// <param name="obj"></param>
       /// <returns></returns>
       public bool Set(string key, object obj)
       {
           Delete(key);
           System.Web.HttpContext.Current.Cache[key] = obj;
           return true;
       }


       /// <summary>
       /// 删除缓存
       /// </summary>
       /// <param name="key"></param>
       /// <returns></returns>
       public bool Delete(string key)
       {
           System.Web.HttpContext.Current.Cache.Remove(key);
           return true;
       }


    }


}
