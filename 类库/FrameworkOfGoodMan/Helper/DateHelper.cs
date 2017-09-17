using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace FrameworkOfGoodMan.Tools.Helper
{
    public class DateHelper
    {
        //星期数组
        private static string[] _weekdays = { "星期日", "星期一", "星期二", "星期三", "星期四", "星期五", "星期六" };

        /// <summary>
        /// 获得当前星期(数字)
        /// </summary>
        public static string GetDayOfWeek()
        {
            return ((int)DateTime.Now.DayOfWeek).ToString();
        }

        /// <summary>
        /// 获得当前星期(汉字)
        /// </summary>
        public static string GetWeek()
        {
            return _weekdays[(int)DateTime.Now.DayOfWeek];
        }

        /// <summary>
        /// 获得当前时间的""yyyy-MM-dd HH:mm:ss:fffffff""格式字符串
        /// </summary>
        public static string GetDateTimeMS()
        {
            return DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss:fffffff");
        }

        /// <summary>
        /// 获得当前时间的""yyyy-MM-dd HH:mm:ss""格式字符串
        /// </summary>
        public static string GetCommonDateTime()
        {
            return DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss");
        }

        /// <summary>
        /// 获得中文当前日期yyyy年MM月dd日 HH时mm分ss秒
        /// </summary>
        public static string GetChineseDateTime()
        {
            return DateTime.Now.ToString("yyyy年MM月dd日 HH时mm分ss秒");
        }

    }
}
