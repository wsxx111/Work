using ServiceStack.Redis;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace WK.Code.Redis
{
    public class RedisHelper
    {
        private static RedisNOSQLConfigInfo redisConfigInfo = null;
        private static PooledRedisClientManager prcm = null;

        static RedisHelper()
        {
            redisConfigInfo = (RedisNOSQLConfigInfo)SerializeHelper.DeserializeFromXML(typeof(RedisNOSQLConfigInfo), FileType.Config, "/Configs/", "redisnosql");
        }


        private static string[] SplitString(string strSource, string split)
        {
            return strSource.Split(split.ToArray());
        }

        /// <summary>
        /// 创建链接池管理对象
        /// </summary>
        private static void CreateManager()
        {
            try
            {
                prcm = new PooledRedisClientManager(redisConfigInfo.User.ReadWriteHostList, redisConfigInfo.User.ReadWriteHostList,
                                            new RedisClientManagerConfig
                                            {
                                                MaxWritePoolSize = redisConfigInfo.User.MaxWritePoolSize,
                                                MaxReadPoolSize = redisConfigInfo.User.MaxReadPoolSize,
                                                AutoStart = redisConfigInfo.User.Enabled == 0 ? false : true,
                                            });
            }
            catch (Exception e)
            {
                throw e;
            }
        }

        /// <summary>
        /// 客户端缓存操作对象
        /// </summary>
        public static IRedisClient GetClient()
        {
            try
            {
                if (prcm == null)
                {
                    CreateManager();
                }
                return prcm.GetClient();
            }
            catch (Exception)
            {
                return null;
            }
        }
    }
}
