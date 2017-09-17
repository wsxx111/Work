using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Configuration;
using System.IO;
using System.Linq;
using System.Runtime.Serialization;
using System.Runtime.Serialization.Formatters.Binary;
using System.Runtime.Serialization.Formatters.Soap;
using System.Text;
using System.Web;
using System.Xml.Serialization;

namespace FrameworkOfGoodMan.Tools.Helper
{
    /// <summary>
    /// 文件类型（枚举）
    /// </summary>
    public enum FileType
    {
        /// <summary>
        /// txt后缀
        /// </summary>
        [Description(".txt")]
        Txt = 1,

        /// <summary>
        /// config后缀
        /// </summary>
        [Description(".config")]
        Config = 2,

        /// <summary>
        /// xml后缀
        /// </summary>
        [Description(".xml")]
        Xml = 3,

        /// <summary>
        /// log后缀
        /// </summary>
        [Description(".log")]
        Log = 4,

        /// <summary>
        /// bat后缀
        /// </summary>
        [Description(".bat")]
        Bat = 5
    }

    /// <summary>
    /// 输入输出
    /// </summary>
    public abstract class IOHelper
    {
        private static object _locker = new object();//锁对象


        /// <summary>
        /// 获得文件物理路径
        /// </summary>
        /// <param name="pathName">要获取的路径</param>
        /// <param name="isWebRequest">是否是Web应用</param>
        /// <returns></returns>
        public static string GetMapPath(string pathName, bool isWebRequest = true)
        {
            try
            {
                if (pathName == null || pathName.Trim() == "")
                {
                    return null;
                }
                if (!pathName.Trim().EndsWith("/"))
                {
                    pathName = pathName.Trim() + "/";
                }
                if (!isWebRequest)
                {
                    return Directory.GetCurrentDirectory() + "\\" + pathName + "\\";
                }

                if (HttpContext.Current != null)
                {
                    return HttpContext.Current.Server.MapPath(pathName);
                }
                else
                {
                    return System.Web.Hosting.HostingEnvironment.MapPath(pathName);
                }
            }
            catch
            {
                return "";
            }
        }



        #region 记录日志
        /// <summary>
        /// 记录异常日志信息，需要在web.config里设置logPath
        /// </summary>
        /// <param name="ex">异常对象</param>     
        /// <param name="ftype">文件类型(枚举)</param>
        /// <param name="logPathName">记录路径</param>
        /// <param name="isWebRequest">是否是Web应用</param>
        public static bool WriteExceptionLog(Exception ex, FileType ftype, string logPathName = "errorLogPath", bool isWebRequest = true)
        {
            return WriteErrorLog(string.Format("方法:{0},异常信息:{1}", ex.TargetSite, ex.Message), ftype, logPathName, isWebRequest);
        }


        /// <summary>
        /// 写入错误日志文件,需要在web.config里设置logPath
        /// </summary>      
        /// <param name="input">写入的信息</param>
        /// <param name="ftype">文件类型(枚举)</param>
        /// <param name="logPathName">web.config下的logpathName节点或非web应用下的文件名</param>
        /// <param name="isWebRequest">是否是Web应用</param>
        /// <returns></returns>
        public static bool WriteErrorLog(string input, FileType ftype, string logPathName = "errorLogPath", bool isWebRequest = true)
        {
            lock (_locker)
            {
                FileStream fs = null;
                StreamWriter sw = null;
                try
                {
                    var getPath = GetMapPath(logPathName, isWebRequest);
                    if (string.IsNullOrEmpty(getPath))
                    {
                        return false;
                    }
                    string fileName = getPath + DateTime.Now.ToString("yyyy年MM月dd日HH时") + EnumHelper.GetDescription(ftype);

                    FileInfo fileInfo = new FileInfo(fileName);
                    if (!fileInfo.Directory.Exists)
                    {
                        fileInfo.Directory.Create();
                    }
                    if (!fileInfo.Exists)
                    {
                        fileInfo.Create().Close();
                    }
                    else if (fileInfo.Length > 2048 * 1000)
                    {
                        fileInfo.Delete();
                    }

                    fs = fileInfo.OpenWrite();
                    sw = new StreamWriter(fs);
                    sw.BaseStream.Seek(0, SeekOrigin.End);
                    sw.Write("Log Entry : ");
                    sw.Write("{0}", DateTime.Now.ToString("yyyy年MM月dd日 HH:mm:ss"));
                    sw.Write(Environment.NewLine);
                    sw.Write(input);
                    sw.Write(Environment.NewLine);
                    sw.Write("------------------------------------");
                    sw.Write(Environment.NewLine);
                }
                catch (Exception ex)
                {
                    throw ex;
                }
                finally
                {
                    if (sw != null)
                    {
                        sw.Flush();
                        sw.Close();
                    }
                    if (fs != null)
                    {
                        fs.Close();
                    }
                }
                return true;
            }
        }


        /// <summary>
        /// 写日志。需要在web.config里设置logPath，设置日志目录
        /// </summary>
        /// <param name="message">写入的信息</param>
        /// <param name="ftype">文件类型(枚举)</param>        
        /// <param name="logPathName">web.config下的logpathName节点或非web应用下的文件名</param>
        /// <param name="isWebRequest">是否是Web应用</param>
        /// <returns></returns>
        public static bool WriteLog(string message, FileType ftype, string logPathName = "LogPath", bool isWebRequest = true)
        {
            lock (_locker)
            {
                FileStream fs = null;
                StreamWriter sw = null;
                try
                {

                    var getPath = GetMapPath(logPathName, isWebRequest);
                    if (string.IsNullOrEmpty(getPath))
                    {
                        return false;
                    }
                    string fileName = getPath + DateTime.Now.ToString("yyyy年MM月dd日HH时") + EnumHelper.GetDescription(ftype);

                    FileInfo fileInfo = new FileInfo(fileName);
                    if (!fileInfo.Directory.Exists)
                    {
                        fileInfo.Directory.Create();
                    }
                    if (!fileInfo.Exists)
                    {
                        fileInfo.Create().Close();
                    }
                    else if (fileInfo.Length > 2048 * 1000)
                    {
                        fileInfo.Delete();
                    }

                    fs = fileInfo.OpenWrite();
                    sw = new StreamWriter(fs);
                    sw.BaseStream.Seek(0, SeekOrigin.End);
                    sw.WriteLine("Log 开始 : ");
                    sw.WriteLine("时间：" + DateTime.Now.ToString().Trim());
                    sw.WriteLine("记录：" + message);
                    sw.WriteLine("------------------------------------");
                }
                catch (Exception ex)
                {
                    throw ex;
                }
                finally
                {
                    if (sw != null)
                    {
                        sw.Flush();
                        sw.Close();
                    }
                    if (fs != null)
                    {
                        fs.Close();
                    }
                }
                return true;
            }
        }
        #endregion


        #region  XML序列化

        /// <summary>
        /// XML序列化
        /// </summary>
        /// <param name="obj">序列对象</param>      
        /// <param name="ftype">文件类型(枚举)</param>
        /// <param name="filePath">相对文件路径</param>
        /// <param name="fileName">文件名称</param>
        /// <param name="isWebRequest">是否是Web应用</param>
        /// <returns>是否成功</returns>
        public static bool SerializeToXml(object obj, FileType ftype, string filePath, string fileName, bool isWebRequest = true)
        {
            lock (_locker)
            {
                bool result = false;
                StreamWriter sw = null;
                try
                {
                    string DictoryPath = GetMapPath(filePath, isWebRequest);
                    if (string.IsNullOrEmpty(DictoryPath))
                    {
                        return false;
                    }
                    string fName = DictoryPath + fileName + EnumHelper.GetDescription(ftype);
                    if (!Directory.Exists(DictoryPath))
                    {
                        Directory.CreateDirectory(DictoryPath);
                    }
                    XmlSerializer serializer = new XmlSerializer(obj.GetType());
                    sw = new StreamWriter(fName);
                    serializer.Serialize(sw, obj);
                    result = true;
                }
                catch (Exception ex)
                {
                    throw ex;
                }
                finally
                {
                    if (sw != null)
                        sw.Close();
                }
                return result;
            }
        }

        /// <summary>
        /// XML反序列化
        /// </summary>
        /// <param name="type">目标类型(Type类型)</param>
        /// <param name="ftype">文件类型(枚举)</param>
        /// <param name="filePath">相对文件路径</param>
        /// <param name="fileName">文件名称</param>
        /// <param name="isWebRequest">是否是Web应用</param>
        /// <returns>序列对象</returns>
        public static object DeserializeFromXML(Type type, FileType ftype, string filePath, string fileName, bool isWebRequest = true)
        {
            lock (_locker)
            {
                FileStream fs = null;
                try
                {
                    string DictoryPath = GetMapPath(filePath, isWebRequest);
                    if (string.IsNullOrEmpty(DictoryPath))
                    {
                        return null;
                    }
                    string fName = DictoryPath + fileName + EnumHelper.GetDescription(ftype);
                    if (Directory.Exists(DictoryPath))
                    {
                        if (File.Exists(fName))
                        {
                            fs = new FileStream(fName, FileMode.Open, FileAccess.Read, FileShare.ReadWrite);
                            XmlSerializer serializer = new XmlSerializer(type);
                            return serializer.Deserialize(fs);
                        }
                        else
                        {
                            return null;
                        }
                    }
                    else
                    {
                        return null;
                    }
                }
                catch (Exception ex)
                {
                    throw ex;
                }
                finally
                {
                    if (fs != null)
                        fs.Close();
                }
            }
        }


        #endregion


        #region  二进制序列化
        /// <summary>
        /// 序列化 对象到字符串
        /// </summary>
        /// <param name="obj">泛型对象</param>
        /// <returns>序列化后的字符串</returns>
        public static bool BinarySerialize<T>(T obj, FileType ftype, string filePath, string fileName, bool isWebRequest = true)
        {
            Stream fs = null;          
            try
            {
                string DictoryPath = GetMapPath(filePath, isWebRequest);
                if (string.IsNullOrEmpty(DictoryPath))
                {
                    return false;
                }
                string fName = DictoryPath + fileName + EnumHelper.GetDescription(ftype);
                if (!Directory.Exists(DictoryPath))
                {
                    Directory.CreateDirectory(DictoryPath);
                }
                IFormatter formatter = new BinaryFormatter();

                #region 存放在内存流中
                //MemoryStream stream = new MemoryStream();
                //stream.Position = 0;
                //byte[] buffer = new byte[stream.Length];
                //stream.Read(buffer, 0, buffer.Length);
                //stream.Flush();
                //stream.Close();
                //return Convert.ToBase64String(buffer);
                #endregion

                fs = new FileStream(fName, FileMode.Create, FileAccess.ReadWrite, FileShare.ReadWrite);
                fs.Position = 0;//重置流位置      
                formatter.Serialize(fs, obj);
                return true;
            }
            catch (Exception ex)
            {
                throw new Exception("序列化失败,原因:" + ex.Message);
            }
            finally
            {
                if (fs != null)
                    fs.Close();
            }
        }

        /// <summary>
        /// 反序列化 字符串到对象
        /// </summary>
        /// <param name="obj">泛型对象</param>
        /// <param name="str">要转换为对象的字符串</param>
        /// <returns>反序列化出来的对象</returns>
        public static object BinaryDesrialize<T>(T obj, FileType ftype, string filePath, string fileName, bool isWebRequest = true)
        {
            Stream fs = null;
            try
            {
                obj = default(T);
                IFormatter formatter = new BinaryFormatter();
                #region 存放在内存流中
                //byte[] buffer = Convert.FromBase64String(str);
                //MemoryStream stream = new MemoryStream(buffer);
                //obj = (T)formatter.Deserialize(stream);
                //stream.Flush();
                //stream.Close();
                #endregion

                string DictoryPath = GetMapPath(filePath, isWebRequest);
                if (string.IsNullOrEmpty(DictoryPath))
                {
                    return null;
                }
                string fName = DictoryPath + fileName + EnumHelper.GetDescription(ftype);
                if (Directory.Exists(DictoryPath))
                {
                    if (File.Exists(fName))
                    {
                        fs = new FileStream(fName, FileMode.Open, FileAccess.Read, FileShare.ReadWrite);
                        fs.Position = 0;//重置流位置
                        obj = (T)formatter.Deserialize(fs);//反序列化对象                        
                    }
                    else
                    {
                        return null;
                    }
                }
                else
                {
                    return null;
                }
            }
            catch (Exception ex)
            {
                throw new Exception("反序列化失败,原因:" + ex.Message);
            }
            finally
            {
                if (fs != null)
                    fs.Close();
            }
            return obj;
        }

        #endregion


        #region  SOAP序列化
        /// <summary>
        /// SOAP序列化
        /// </summary>
        /// <param name="obj">序列对象</param>      
        /// <param name="ftype">文件类型(枚举)</param>
        /// <param name="filePath">相对文件路径</param>
        /// <param name="fileName">文件名称</param>
        /// <param name="isWebRequest">是否是Web应用</param>
        /// <returns>是否成功</returns>
        public static bool SoapSerialize<T>(T obj, FileType ftype, string filePath, string fileName, bool isWebRequest = true)
        {
            Stream fs = null;
            try
            {
                string DictoryPath = GetMapPath(filePath, isWebRequest);
                if (string.IsNullOrEmpty(DictoryPath))
                {
                    return false;
                }
                string fName = DictoryPath + fileName + EnumHelper.GetDescription(ftype);
                if (!Directory.Exists(DictoryPath))
                {
                    Directory.CreateDirectory(DictoryPath);
                }
                fs = new FileStream(fName, FileMode.Create, FileAccess.ReadWrite, FileShare.ReadWrite);
                SoapFormatter soapFormat = new SoapFormatter();//创建SOAP序列化器
                soapFormat.Serialize(fs, obj);//SOAP不能序列化泛型对象

                return true;
            }
            catch (Exception ex)
            {
                return false;
                throw new Exception("序列化失败,原因:" + ex.Message);
            }
            finally
            {
                if (fs != null)
                    fs.Close();
            }
        }

        /// <summary>
        ///SOAP反序列化
        /// </summary>
        /// <param name="obj">序列对象</param>      
        /// <param name="ftype">文件类型(枚举)</param>
        /// <param name="filePath">相对文件路径</param>
        /// <param name="fileName">文件名称</param>
        /// <param name="isWebRequest">是否是Web应用</param>
        /// <returns>是否成功</returns>
        public static object SoapDesrialize<T>(T obj, FileType ftype, string filePath, string fileName, bool isWebRequest = true)
        {
            Stream fs = null;
            try
            {
                obj = default(T);
                SoapFormatter soapFormat = new SoapFormatter(); //创建SOAP序列化器
                #region 存放在内存流中
                //byte[] buffer = Convert.FromBase64String(str);
                //MemoryStream stream = new MemoryStream(buffer);
                //obj = (T)formatter.Deserialize(stream);
                //stream.Flush();
                //stream.Close();
                #endregion

                string DictoryPath = GetMapPath(filePath, isWebRequest);
                if (string.IsNullOrEmpty(DictoryPath))
                {
                    return null;
                }
                string fName = DictoryPath + fileName + EnumHelper.GetDescription(ftype);
                if (Directory.Exists(DictoryPath))
                {
                    if (File.Exists(fName))
                    {
                        fs = new FileStream(fName, FileMode.Open, FileAccess.Read, FileShare.ReadWrite);
                        fs.Position = 0;                      //重置流位置
                        obj = (T)soapFormat.Deserialize(fs);   //反序列化对象                        
                    }
                    else
                    {
                        return null;
                    }
                }
                else
                {
                    return null;
                }
            }
            catch (Exception ex)
            {
                return null;
                throw new Exception("反序列化失败,原因:" + ex.Message);
            }
            finally
            {
                if (fs != null)
                    fs.Close();
            }
            return obj;
        }

        #endregion

        /// <summary>
        /// 压缩方法
        /// </summary>
        /// <param name="data"></param>
        /// <returns></returns>
        public byte[] ComPress(byte[] data)
        {
            try
            {
                MemoryStream ms = new MemoryStream();
                Stream zipStream = null;
                zipStream = new System.IO.Compression.GZipStream(ms, System.IO.Compression.CompressionMode.Compress, true);
                zipStream.Write(data, 0, data.Length);
                zipStream.Close();
                ms.Position = 0;
                byte[] compressed_data = new byte[ms.Length];
                ms.Read(compressed_data, 0, int.Parse(ms.Length.ToString()));
                return compressed_data;
            }
            catch
            {
                return null;
            }
        }


       
        /// <summary>
        /// 解压缩方法
        /// </summary>
        /// <param name="data"></param>
        /// <returns></returns>
        public byte[] DecomPress(byte[] data)
        {
            try
            {
                MemoryStream ms = new MemoryStream();
                Stream zipStream = null;
                zipStream = new System.IO.Compression.GZipStream(ms, System.IO.Compression.CompressionMode.Decompress, true);
                zipStream.Write(data, 0, data.Length);
                zipStream.Close();
                ms.Position = 0;
                byte[] compressed_data = new byte[ms.Length];
                ms.Read(compressed_data, 0, int.Parse(ms.Length.ToString()));
                return compressed_data;
            }
            catch
            {
                return null;
            }
        }


    }
}


/*
  XML序列化，.NET Framework中提供两种串行方法，一种是二进制法，一种是XML串行化。
序列化是将对象状态转换为可保持或传输的格式的过程，xml序列化是将对象的公共字段和属性序列化为XML流。
由于xml是一个开放式标准，因此对于通过web共享数据而言，是一个很好的选择。

将对象序列化，可以将对象状态永久保存在存储媒体上，以便以后可以在创建更精确的副本；
同时，通过值可以将对象一个应用程序域发送到另一个应用程序域。

 * XML序列化中最主要的类是XmlSerializer,其中最要的方法有：Serializer、Deserializer。
 使用XmlSerializer可以将以下几项序列化：公共类的公共读/写属性、字段、；实现ICollection或者IEnumerable的类；
 XmlElement对象;XmlNode读写;DataSet对象。
 * 
 * 
  .Net程序执行时，对象会驻留在内存中；内存中的对象如果需要传递给其他系统使用，
 或者在关机时需要保存下来以便下次再次启动程序使用就需要序列化和反序列化。
 * 
 * 为了提高性能，XML序列化基础结构将动态生成程序集，以序列化和反序列化指定类型。此基础结构将查找并重复使用这些程序集。此行为仅在使用以下构造函数时发生：Xmlserializer(Type)
XmlSerializer(Type,String)

如果使用其他任何构造函数，则会生成同一个程序集的多个版本，且不会被卸载，这将导致内存泄露和性能降低。
简单的解决方案就是使用以上提到的两个构造函数(Xmlserializer(Type),XmlSerializer(Type,String))中的其中一个即可。否则必须在HashTable中缓存程序集。
 
使用XML序列化或反序列化时，需要对XML序列化器指定需要序列化对象的类型和其关联的类型。

XML序列化只能序列化对象的公有属性，并且要求对象有一个无参的构造方法，否者无法反序列化。

[Serializable]和[NonSerialized]特性对XML序列化无效！所以使用XML序列化时不需要对对象增加[Serializable]特性。
 
 */

/*

使用二进制序列化，必须为每一个要序列化的的类和其关联的类加上[Serializable]特性，对类中不需要序列化的成员可以使用[NonSerialized]特性。

二进制序列化对象时，能序列化类的所有成员(包括私有的)，且不需要类有无参数的构造方法。

使用二进制格式序列化时，它不仅是将对象的字段数据进行持久化，也持久化每个类型的完全限定名称和定义程序集的完整名称（包括包称、版本、公钥标记、区域性），这些数据使得在进行二进制格式反序列化时亦会进行类型检查。所以反序列化时的运行环境要与序列化时的运行环境要相同，否者可能会无法反序列化成功。
 
  */


/*
SOAP序列化与二进制序列化的区别是：SOAP序列化不能序列化泛型类型。与二进制序列化一样在序列化时不需要向序列化器指定序列化对象的类型。而XML序列化需要向XML序列化器指定序列化对象的类型。
  */
