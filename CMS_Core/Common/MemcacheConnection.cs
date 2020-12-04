using log4net;
using Memcached.ClientLibrary;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CMS_Core.Common
{

    
    public class MemcacheConnection
    {
        readonly ILog logError = log4net.LogManager.GetLogger("CMSLISLogError");
        public static MemcachedClient mc;

        public object getMemcacheByKey(string key)
        {
            object result = null;

            try
            {
                string[] servers = ConfigurationSettings.AppSettings["Memcached"].ToString().Split(';');
                SockIOPool instance = SockIOPool.GetInstance();
                instance.SetServers(servers);
                instance.InitConnections = 10;
                instance.MinConnections = 5;
                instance.MaxConnections = 100;
                instance.SocketConnectTimeout = 2000;
                instance.SocketTimeout = 2000;
                instance.MaintenanceSleep = 30L;
                instance.Failover = true;
                instance.Nagle = false;
                instance.Initialize();
                mc = Common.getMemcacheInstance();
                mc.EnableCompression = false;
                if (mc.KeyExists(key))
                    result = mc.Get(key);
            }
            catch (Exception ex)
            {
                logError.Info("getMemcacheByKey: " + ex.ToString());
            }

            return result;
        }

        public bool setMemcacheSecondsByKey(string key, object value)
        {
            try
            {
                string[] servers = ConfigurationSettings.AppSettings["Memcached"].ToString().Split(';');
                SockIOPool instance = SockIOPool.GetInstance();
                instance.SetServers(servers);
                instance.InitConnections = 10;
                instance.MinConnections = 5;
                instance.MaxConnections = 100;
                instance.SocketConnectTimeout = 2000;
                instance.SocketTimeout = 2000;
                instance.MaintenanceSleep = 30L;
                instance.Failover = true;
                instance.Nagle = false;
                instance.Initialize();
                mc = Common.getMemcacheInstance();
                mc.EnableCompression = false;
                return mc.Set(key, value, DateTime.Now.AddSeconds(Convert.ToDouble(ConfigurationSettings.AppSettings["Seconds"].ToString())));
            }
            catch (Exception ex)
            {
                logError.Info("setMemcacheSecondsByKey: " + ex.ToString());
                return false;
            }
        }
        

        public bool setMemcacheMinutesByKey(string key, object value)
        {
            try
            {
                string[] servers = ConfigurationSettings.AppSettings["Memcached"].ToString().Split(';');
                SockIOPool instance = SockIOPool.GetInstance();
                instance.SetServers(servers);
                instance.InitConnections = 10;
                instance.MinConnections = 5;
                instance.MaxConnections = 100;
                instance.SocketConnectTimeout = 2000;
                instance.SocketTimeout = 2000;
                instance.MaintenanceSleep = 30L;
                instance.Failover = true;
                instance.Nagle = false;
                instance.Initialize();                 
                mc = Common.getMemcacheInstance();
                mc.EnableCompression = false;

                string abc = ConfigurationSettings.AppSettings["Minutes"].ToString();
                if (mc.KeyExists(key))
                    return mc.Replace(key, value, DateTime.Now.AddMinutes(Convert.ToDouble(ConfigurationSettings.AppSettings["Minutes"].ToString())));
                else
                    return mc.Set(key, value, DateTime.Now.AddMinutes(Convert.ToDouble(ConfigurationSettings.AppSettings["Minutes"].ToString())));
            }
            catch (Exception ex)
            {
                logError.Info("setMemcacheMinutesByKey: " + ex.ToString());
                return false;
            }
        }

        public bool setMemcacheForeverByKey(string key, object value)
        {
            try
            {
                string[] servers = ConfigurationSettings.AppSettings["Memcached"].ToString().Split(';');
                SockIOPool instance = SockIOPool.GetInstance();
                instance.SetServers(servers);
                instance.InitConnections = 10;
                instance.MinConnections = 5;
                instance.MaxConnections = 100;
                instance.SocketConnectTimeout = 2000;
                instance.SocketTimeout = 2000;
                instance.MaintenanceSleep = 30L;
                instance.Failover = true;
                instance.Nagle = false;
                instance.Initialize();
                mc = Common.getMemcacheInstance();
                mc.EnableCompression = false;                
                return mc.Set(key, value);
            }
            catch (Exception ex)
            {
                logError.Info("setMemcacheSecondsByKey: " + ex.ToString());
                return false;
            }
        }

        public bool ReplaceMemcacheForeverByKey(string key, object value)
        {
            try
            {
                string[] servers = ConfigurationSettings.AppSettings["Memcached"].ToString().Split(';');
                SockIOPool instance = SockIOPool.GetInstance();
                instance.SetServers(servers);
                instance.InitConnections = 10;
                instance.MinConnections = 5;
                instance.MaxConnections = 100;
                instance.SocketConnectTimeout = 2000;
                instance.SocketTimeout = 2000;
                instance.MaintenanceSleep = 30L;
                instance.Failover = true;
                instance.Nagle = false;
                instance.Initialize();
                mc = Common.getMemcacheInstance();
                mc.EnableCompression = false;
                if (mc.KeyExists(key))
                    return mc.Replace(key, value);
                else
                    return false;
            }
            catch (Exception ex)
            {
                logError.Info("ReplaceMemcacheForeverByKey: " + ex.ToString());
                return false;
            }
        }

        public bool ReplaceMemcacheMinutesByKey(string key, object value)
        {
            try
            {
                string[] servers = ConfigurationSettings.AppSettings["Memcached"].ToString().Split(';');
                SockIOPool instance = SockIOPool.GetInstance();
                instance.SetServers(servers);
                instance.InitConnections = 10;
                instance.MinConnections = 5;
                instance.MaxConnections = 100;
                instance.SocketConnectTimeout = 2000;
                instance.SocketTimeout = 2000;
                instance.MaintenanceSleep = 30L;
                instance.Failover = true;
                instance.Nagle = false;
                instance.Initialize();
                mc = Common.getMemcacheInstance();
                mc.EnableCompression = false;
                if (mc.KeyExists(key))
                    return mc.Replace(key, value, DateTime.Now.AddMinutes(Convert.ToDouble(ConfigurationSettings.AppSettings["Minutes"].ToString())));
                else
                    return false;
            }
            catch (Exception ex)
            {
                logError.Info("ReplaceMemcacheMinutesByKey: " + ex.ToString());
                return false;
            }
        }

        public bool ReplaceMemcacheSecondsByKey(string key, object value)
        {
            try
            {
                string[] servers = ConfigurationSettings.AppSettings["Memcached"].ToString().Split(';');
                SockIOPool instance = SockIOPool.GetInstance();
                instance.SetServers(servers);
                instance.InitConnections = 10;
                instance.MinConnections = 5;
                instance.MaxConnections = 100;
                instance.SocketConnectTimeout = 2000;
                instance.SocketTimeout = 2000;
                instance.MaintenanceSleep = 30L;
                instance.Failover = true;
                instance.Nagle = false;
                instance.Initialize();
                mc = Common.getMemcacheInstance();
                mc.EnableCompression = false;
                if (mc.KeyExists(key))
                    return mc.Replace(key, value, DateTime.Now.AddSeconds(Convert.ToDouble(ConfigurationSettings.AppSettings["Seconds"].ToString())));
                else
                    return false;
            }
            catch (Exception ex)
            {
                logError.Info("ReplaceMemcacheSecondsByKey: " + ex.ToString());
                return false;
            }
        }


    }
}
