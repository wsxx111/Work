using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;

namespace WK.Code.Security
{
   public  class SafeFilter
    {
        //验证Base64字符串的正则表达式
        private static Regex _base64regex = new Regex(@"[A-Za-z0-9\=\/\+]");
        //防SQL注入正则表达式1
        private static Regex _sqlkeywordregex1 = new Regex(@"(select|insert|delete|from|count\(|drop|table|update|truncate|asc\(|mid\(|char\(|xp_cmdshell|exec|master|net|local|group|administrators|user|or|and|-|;|,|\(|\)|\[|\]|\{|\}|%|\*|!|\')", RegexOptions.IgnoreCase);
        //防SQL注入正则表达式2
        private static Regex _sqlkeywordregex2 = new Regex(@"(select|insert|delete|from|count\(|drop|table|update|truncate|asc\(|mid\(|char\(|xp_cmdshell|exec|master|net|local|group|administrators|user|or|and|-|;|,|\(|\)|\[|\]|\{|\}|%|@|\*|!|\')", RegexOptions.IgnoreCase);

        /// <summary>
        /// 判断是否是Base64字符串
        /// </summary>
        /// <returns></returns>
        public static bool IsBase64String(string str)
        {
            if (str != null)
                return _base64regex.IsMatch(str);
            return true;
        }

        /// <summary>
        /// 判断当前字符串是否存在SQL注入
        /// </summary>
        /// <returns></returns>
        public static bool IsSafeSqlString(string s)
        {
            return IsSafeSqlString(s, true);
        }

        /// <summary>
        /// 判断当前字符串是否存在SQL注入
        /// </summary>
        /// <returns></returns>
        public static bool IsSafeSqlString(string s, bool isStrict)
        {
            if (s != null)
            {
                if (isStrict)
                    return !_sqlkeywordregex2.IsMatch(s);
                else
                    return !_sqlkeywordregex1.IsMatch(s);
            }
            return true;
        }

        #region 格式化文本（防止SQL注入）
        /// <summary>
        /// 格式化文本（防止SQL注入）
        /// </summary>
        /// <param name="str"></param>
        /// <returns></returns>
        public static string Formatstr(string html)
        {
            System.Text.RegularExpressions.Regex regex1 = new System.Text.RegularExpressions.Regex(@"<script[\s\S]+</script *>", System.Text.RegularExpressions.RegexOptions.IgnoreCase);
            System.Text.RegularExpressions.Regex regex2 = new System.Text.RegularExpressions.Regex(@" href *= *[\s\S]*script *:", System.Text.RegularExpressions.RegexOptions.IgnoreCase);
            System.Text.RegularExpressions.Regex regex3 = new System.Text.RegularExpressions.Regex(@" on[\s\S]*=", System.Text.RegularExpressions.RegexOptions.IgnoreCase);
            System.Text.RegularExpressions.Regex regex4 = new System.Text.RegularExpressions.Regex(@"<iframe[\s\S]+</iframe *>", System.Text.RegularExpressions.RegexOptions.IgnoreCase);
            System.Text.RegularExpressions.Regex regex5 = new System.Text.RegularExpressions.Regex(@"<frameset[\s\S]+</frameset *>", System.Text.RegularExpressions.RegexOptions.IgnoreCase);
            System.Text.RegularExpressions.Regex regex10 = new System.Text.RegularExpressions.Regex(@"select", System.Text.RegularExpressions.RegexOptions.IgnoreCase);
            System.Text.RegularExpressions.Regex regex11 = new System.Text.RegularExpressions.Regex(@"update", System.Text.RegularExpressions.RegexOptions.IgnoreCase);
            System.Text.RegularExpressions.Regex regex12 = new System.Text.RegularExpressions.Regex(@"delete", System.Text.RegularExpressions.RegexOptions.IgnoreCase);
            html = regex1.Replace(html, ""); //过滤<script></script>标记
            html = regex2.Replace(html, ""); //过滤href=javascript: (<A>) 属性
            html = regex3.Replace(html, " _disibledevent="); //过滤其它控件的on...事件
            html = regex4.Replace(html, ""); //过滤iframe
            html = regex10.Replace(html, "s_elect");
            html = regex11.Replace(html, "u_pudate");
            html = regex12.Replace(html, "d_elete");
            html = html.Replace("'", "’");
            html = html.Replace("&nbsp;", " ");
            return html;
        }
        #endregion

        /// <summary>
        /// 安全过滤
        /// </summary>
        /// <param name="sqlStr">SQL语句</param>
        /// <returns>安全过滤后的SQL语句</returns>
        public static string Transform(string sqlStr)
        {
            if (String.IsNullOrEmpty(sqlStr)) return string.Empty;
            //进行安全过滤
            sqlStr = sqlStr.Replace("'", "''");
            sqlStr = sqlStr.Replace("%", "％");
            sqlStr = sqlStr.Replace(";", "；");
            sqlStr = sqlStr.Replace("/*", "");
            sqlStr = sqlStr.Replace("--", "——");
            sqlStr = sqlStr.Replace("&nbsp；", "&nbsp;");
            return SafeSql(sqlStr);
        }

        public static string SafeSql(string sql)
        {
            if (String.IsNullOrEmpty(sql)) return string.Empty;

            string restr = Regex.Replace(sql, "exec", "ｅｘｅｃ", RegexOptions.Singleline | RegexOptions.IgnoreCase);
            restr = Regex.Replace(restr, "declare", "ｄｅｃｌａｒｅ", RegexOptions.Singleline | RegexOptions.IgnoreCase);
            restr = Regex.Replace(restr, "update", "ｕｐｄａｔｅ", RegexOptions.Singleline | RegexOptions.IgnoreCase);
            restr = Regex.Replace(restr, "delete", "ｄｅｌｅｔｅ", RegexOptions.Singleline | RegexOptions.IgnoreCase);
            restr = Regex.Replace(restr, "select", "ｓｅｌｅｃｔ", RegexOptions.Singleline | RegexOptions.IgnoreCase);
            restr = Regex.Replace(restr, "\\%00", "", RegexOptions.Singleline | RegexOptions.IgnoreCase | RegexOptions.Compiled);
            restr = Regex.Replace(restr, "0x", "0ｘ", RegexOptions.Singleline | RegexOptions.IgnoreCase | RegexOptions.Compiled);
            restr = restr.Replace("--", "").Replace("/*", "").Replace("*/", "").Replace(";", "；").Replace("\"", "“").Trim();
            return restr;
        }
    }
}
