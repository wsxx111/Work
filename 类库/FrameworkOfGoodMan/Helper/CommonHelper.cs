using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;

namespace FrameworkOfGoodMan.Tools.Helper
{
    /// <summary>
    /// 普通帮助类
    /// </summary>
    public class CommonHelper
    {
        /// <summary>
        ///获得邮箱提供者
        /// </summary>
        /// <param name="email">邮箱</param>
        /// <returns></returns>
        public static string GetEmailProvider(string email)
        {
            int index = email.LastIndexOf('@');
            if (index > 0)
                return email.Substring(index + 1);
            return string.Empty;
        }

        /// <summary>
        /// 将ip地址转换成long类型
        /// </summary>
        /// <param name="ip">ip</param>
        /// <returns></returns>
        public static long ConvertIPToLong(string ip)
        {
            string[] ips = ip.Split('.');
            long number = 16777216L * long.Parse(ips[0]) + 65536L * long.Parse(ips[1]) + 256 * long.Parse(ips[2]) + long.Parse(ips[3]);
            return number;
        }

        /// <summary>
        /// 数字转换为IP
        /// </summary>
        /// <param name="ipValue">ipValue</param>
        /// <returns>结果</returns>
        public static string ToIP(Int64 ipValue)
        {
            try
            {
                string ip = String.Empty;

                for (int i = 4; i > 0; i--)
                {
                    ip = (ipValue % 256).ToString() + "." + ip;
                    ipValue = ipValue / 256;
                }

                return ip.TrimEnd('.');
            }
            catch
            {
                return "";
            }
        }

        /// <summary>
        /// 隐藏邮箱
        /// </summary>
        public static string HideEmail(string email)
        {
            int index = email.LastIndexOf('@');

            if (index == 1)
                return "*" + email.Substring(index);
            if (index == 2)
                return email[0] + "*" + email.Substring(index);

            StringBuilder sb = new StringBuilder();
            sb.Append(email.Substring(0, 2));
            int count = index - 2;
            while (count > 0)
            {
                sb.Append("*");
                count--;
            }
            sb.Append(email.Substring(index));
            return sb.ToString();
        }

        /// <summary>
        /// 隐藏手机
        /// </summary>
        public static string HideMobile(string mobile)
        {
            return mobile.Substring(0, 3) + "*****" + mobile.Substring(8);
        }
      
    }
}
