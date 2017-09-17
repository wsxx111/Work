using Memcached.ClientLibrary;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace WK.Code.MemCache
{
    /// <summary>
    /// Memcached操作
    /// </summary>
    public class SlMemcachedClient
    {
        private SockIOPool sockIOPool = null;
        private MemcachedClient memcachedClient = null;
        private string[] serverlist = null;

        /// <summary>
        /// 客户端缓存操作对象
        /// </summary>
        public MemcachedClient CacheClient
        {
            get
            {
                return memcachedClient;
            }
        }

        /// <summary>
        /// Memcached初期化
        /// </summary>
        /// <param name="pName">池名称</param>
        /// <param name="memServer">IP、端口号</param>
        /// <param name="InitConnections"></param>
        /// <param name="MinConnections"></param>
        /// <param name="MaxConnections"></param>
        /// <param name="SocketConnectTimeout"></param>
        /// <param name="SocketTimeout"></param>
        public SlMemcachedClient(string pName, string[] memServer, int InitConnections = 5, int MinConnections = 3, int MaxConnections = 50, int SocketConnectTimeout = 1000, int SocketTimeout = 3000)
        {
            if (pName.Trim() == "") return;
            if (memServer == null || memServer.Length == 0)
            {
                return;
            }
            else
            {
                serverlist = memServer;
            }
            if (sockIOPool == null)
            {
                sockIOPool = SockIOPool.GetInstance(pName);
                sockIOPool.SetServers(serverlist);

                sockIOPool.InitConnections = InitConnections;
                sockIOPool.MinConnections = MinConnections;
                sockIOPool.MaxConnections = MaxConnections;

                sockIOPool.SocketConnectTimeout = SocketConnectTimeout;
                sockIOPool.SocketTimeout = SocketTimeout;

                sockIOPool.MaintenanceSleep = 30;
                sockIOPool.Failover = true;

                sockIOPool.Nagle = false;
                sockIOPool.Initialize();

                memcachedClient = new MemcachedClient();
                memcachedClient.PoolName = pName;
                memcachedClient.EnableCompression = false;
            }
        }
    }
}
