using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Text;

namespace WK.Code.MemCache
{
    public class MemcachedTool
    {
        /// <summary>
        /// 初始化
        /// </summary>
        /// <returns></returns>
        public static SlMemCached InitMemcachedClient()
        {
            SlMemcachedClient memcachedClient = new SlMemcachedClient("HDHB", ConfigurationManager.AppSettings["HDHBMemcachedServers"].Split(','));
            return new SlMemCached(memcachedClient);
        }

        /// <summary>
        /// 设置
        /// </summary>
        /// <param name="strKey"></param>
        /// <param name="objSource"></param>
        /// <param name="seconds"></param>
        public static void SetMemcached(string strKey, object objSource, double seconds = 43200)
        {
            SlMemCached memCached = MemcachedTool.InitMemcachedClient();
            memCached.Set(strKey, objSource, DateTime.Now.AddSeconds(seconds));
        }

        /// <summary>
        /// 获取
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="strKey"></param>
        /// <returns></returns>
        public static T GetMemcached<T>(string strKey)
        {
            SlMemCached memCached = MemcachedTool.InitMemcachedClient();
            if (memCached.KeyExists(strKey))
            {
                return memCached.Get<T>(strKey);
            }
            return default(T);
        }

        /// <summary>
        /// 清除
        /// </summary>
        /// <param name="strKey"></param>
        public static void RemoveMemcached(string strKey)
        {
            SlMemCached memCached = MemcachedTool.InitMemcachedClient();
            if (memCached.KeyExists(strKey))
            {
                memCached.Delete(strKey);
            }
        }

        public static void RemoveAllMemcached(List<string> lstKey)
        {
            SlMemCached memCached = MemcachedTool.InitMemcachedClient();
            for (int i = 0, iLength = lstKey.Count; i < iLength; i++)
            {
                if (memCached.KeyExists(lstKey[i]))
                {
                    memCached.Delete(lstKey[i]);
                }
            }
        }
    }
}
