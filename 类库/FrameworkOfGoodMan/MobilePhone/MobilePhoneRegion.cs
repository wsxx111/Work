using System;
using System.Collections.Generic;
using System.IO;
using System.IO.Compression;
using System.Linq;
using System.Text;

namespace FrameworkOfGoodMan.Tools.MobilePhone
{   
        /// <summary>
        /// 通过手机号取归属地信息
        /// </summary>
        public class MobilePhoneRegion
        {
            /// <summary>
            /// 所有
            /// </summary>
            public static readonly Dictionary<string, MobilePhoneRegion> All = new Dictionary<string, MobilePhoneRegion>();

            /// <summary>
            /// 静态构造函数
            /// </summary>
            static MobilePhoneRegion()
            {
                using (MemoryStream memoryStream = new MemoryStream(ResourceRead.Resource.MobilePhone))
                {
                    using (GZipStream gzipStream = new GZipStream(memoryStream, CompressionMode.Decompress))
                    {
                        using (StreamReader streamReader = new StreamReader(gzipStream))
                        {
                            while (!streamReader.EndOfStream)
                            {
                                var line = streamReader.ReadLine();
                                var fileds = line.Split('^');
                                var mobilePhoneRegion = new MobilePhoneRegion()
                                {
                                    ID = int.Parse(fileds[0]),
                                    MobileNumber = fileds[1],
                                    Country = fileds[2],
                                    Province = fileds[3],
                                    City = fileds[4],
                                    MobileType = fileds[5],
                                    AreaCode = fileds[6],
                                    PostCode = fileds[7]
                                };
                                All.Add(mobilePhoneRegion.MobileNumber, mobilePhoneRegion);
                            }
                        }
                    }
                }
            }

            /// <summary>
            /// 编号
            /// </summary>
            public int ID { get; set; }

            /// <summary>
            /// 手机号前缀
            /// </summary>
            public string MobileNumber { get; set; }

            /// <summary>
            /// 国家
            /// </summary>
            public string Country { get; set; }

            /// <summary>
            /// 省份
            /// </summary>
            public string Province { get; set; }

            /// <summary>
            /// 城市
            /// </summary>
            public string City { get; set; }

            /// <summary>
            /// 运营商
            /// </summary>
            public string MobileType { get; set; }

            /// <summary>
            /// 区号
            /// </summary>
            public string AreaCode { get; set; }

            /// <summary>
            /// 邮政编码
            /// </summary>
            public string PostCode { get; set; }



            /// <summary>
            /// 通过手机号取归属地信息
            /// </summary>
            /// <param name="mobilePhone">手机号</param>
            /// <returns>结果</returns>
            public static MobilePhoneRegion Find(string mobilePhone)
            {
                try
                {
                    string mobileNumber = mobilePhone.Substring(0, 7);
                    return All[mobileNumber];
                }
                catch { }
                return null;
            }        
    }
}
