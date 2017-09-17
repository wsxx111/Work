using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;

namespace FrameworkOfGoodMan.Tools.Helper
{
    /// <summary>
    /// String操作
    /// </summary>
    public class StringHelper
    {
        //空格、回车、换行符、制表符正则表达式
        private static Regex _tbbrRegex = new Regex(@"\s*|\t|\r|\n", RegexOptions.IgnoreCase);

        /// <summary>
        /// 获得字符串中指定字符的个数
        /// </summary>
        /// <param name="s">字符串</param>
        /// <param name="c">字符</param>
        /// <param name="IgnoreCase">是否忽略大小写</param>
        /// <returns></returns>
        public static int GetCharInStrCount(string s, char c, bool IgnoreCase = false)
        {
            if (s == null || s.Length == 0)
                return 0;
            int count = 0;
            if (IgnoreCase)
            {
                c = Char.ToLower(c);
                s = s.ToLower();
            }
            foreach (char a in s)
            {
                if (a == c)
                    count++;
            }
            return count;
        }


        /// <summary>  
        /// 计算字符串中子串出现的次数  
        /// </summary>  
        /// <param name="str">字符串</param>  
        /// <param name="substring">子串</param>  
        /// <param name="IgnoreCase">是否忽略大小写</param>
        /// <returns>出现的次数</returns>  
        public static int GetSubstrInStrCount(string str, string substring, bool IgnoreCase = false)
        {
            if (String.IsNullOrEmpty(substring) || String.IsNullOrEmpty(str))
            {
                return str.Length;
            }
            if (IgnoreCase)
            {
                str = str.ToLower();
                substring = substring.ToLower();
            }
            if (str.Contains(substring))
            {
                string strReplaced = str.Replace(substring, "");
                return (str.Length - strReplaced.Length) / substring.Length;
            }
            return 0;
        }


        /// <summary>
        /// 分割字符串
        /// </summary>
        /// <param name="sourceStr">源字符串</param>
        /// <param name="splitStr">分隔字符串</param>
        ///  <param name="IgnoreCase">是否忽略大小写</param>
        /// <returns></returns>
        public static string[] SplitString(string sourceStr, string splitStr, bool IgnoreCase = false)
        {
            if (string.IsNullOrEmpty(sourceStr) || string.IsNullOrEmpty(splitStr))
                return new string[0] { };
            bool isexist = sourceStr.IndexOf(splitStr) == -1;
            if (IgnoreCase ? sourceStr.ToLower().IndexOf(splitStr.ToLower()) == -1 : isexist)
                return new string[] { sourceStr };

            if (splitStr.Length == 1)
            {
                return IgnoreCase && isexist ? sourceStr.Split(Char.IsUpper(splitStr[0]) ? Char.ToLower(splitStr[0]) : Char.ToUpper(splitStr[0])) : sourceStr.Split(splitStr[0]);
            }
            else
            {
                return IgnoreCase ? Regex.Split(sourceStr, Regex.Escape(splitStr), RegexOptions.IgnoreCase) : Regex.Split(sourceStr, Regex.Escape(splitStr));
            }

        }


        /// <summary>
        /// 移除前导字符串
        /// </summary>
        /// <param name="sourceStr">源字符串</param>
        /// <param name="trimStr">移除字符串</param>
        /// <param name="ignoreCase">是否忽略大小写</param>
        /// <returns></returns>
        public static string StrTrimStart(string sourceStr, string trimStr, bool ignoreCase=false)
        {
            if (string.IsNullOrEmpty(sourceStr))
                return string.Empty;

            if (string.IsNullOrEmpty(trimStr) || !sourceStr.StartsWith(trimStr, ignoreCase, CultureInfo.CurrentCulture))
                return sourceStr;

            return sourceStr.Remove(0, trimStr.Length);
        }


        /// <summary>
        /// 移除后导字符串
        /// </summary>
        /// <param name="sourceStr">源字符串</param>
        /// <param name="trimStr">移除字符串</param>
        /// <param name="ignoreCase">是否忽略大小写</param>
        /// <returns></returns>
        public static string StrTrimEnd(string sourceStr, string trimStr, bool ignoreCase=false)
        {
            if (string.IsNullOrEmpty(sourceStr))
                return string.Empty;

            if (string.IsNullOrEmpty(trimStr) || !sourceStr.EndsWith(trimStr, ignoreCase, CultureInfo.CurrentCulture))
                return sourceStr;

            return sourceStr.Substring(0, sourceStr.Length - trimStr.Length);
        }


        /// <summary>
        /// 移除前导和后导字符串
        /// </summary>
        /// <param name="sourceStr">源字符串</param>
        /// <param name="trimStr">移除字符串</param>
        /// <param name="ignoreCase">是否忽略大小写</param>
        /// <returns></returns>
        public static string StrTrim(string sourceStr, string trimStr, bool ignoreCase=false)
        {
            if (string.IsNullOrEmpty(sourceStr))
                return string.Empty;

            if (string.IsNullOrEmpty(trimStr))
                return sourceStr;

            if (sourceStr.StartsWith(trimStr, ignoreCase, CultureInfo.CurrentCulture))
                sourceStr = sourceStr.Remove(0, trimStr.Length);

            if (sourceStr.EndsWith(trimStr, ignoreCase, CultureInfo.CurrentCulture))
                sourceStr = sourceStr.Substring(0, sourceStr.Length - trimStr.Length);

            return sourceStr;
        }

        /// <summary>
        /// 去除字符串中的空格、回车、换行符、制表符
        /// </summary>
        public static string ClearTBBR(string str)
        {
            if (!string.IsNullOrEmpty(str))
                return _tbbrRegex.Replace(str, "");

            return string.Empty;
        }

        /// <summary>
        /// 去除字符串首尾处的空格、回车、换行符、制表符
        /// </summary>
        public static string TBBRTrim(string str)
        {
            if (!string.IsNullOrEmpty(str))
                return str.Trim().Trim('\r').Trim('\n').Trim('\t');
            return string.Empty;
        }

    }
}
