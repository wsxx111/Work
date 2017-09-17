using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;

namespace WK.Code
{
    public static partial class Ext
    {
        //空格、回车、换行符、制表符正则表达式
        private static Regex _tbbrRegex = new Regex(@"\s*|\t|\r|\n", RegexOptions.IgnoreCase);		

        /// <summary>
        /// 获得字符串在字符串数组中的位置
        /// </summary>
        public static int GetIndexInArray(string s, string[] array, bool ignoreCase)
        {
            if (string.IsNullOrEmpty(s) || array == null || array.Length == 0)
                return -1;

            int index = 0;
            string temp = null;

            if (ignoreCase)
                s = s.ToLower();

            foreach (string item in array)
            {
                if (ignoreCase)
                    temp = item.ToLower();
                else
                    temp = item;

                if (s == temp)
                    return index;
                else
                    index++;
            }

            return -1;
        }

        /// <summary>
        /// 获得字符串在字符串数组中的位置
        /// </summary>
        public static int GetIndexInArray(string s, string[] array)
        {
            return GetIndexInArray(s, array, false);
        }

        /// <summary>
        /// 判断字符串是否在字符串数组中
        /// </summary>
        public static bool IsInArray(string s, string[] array, bool ignoreCase)
        {
            return GetIndexInArray(s, array, ignoreCase) > -1;
        }

        /// <summary>
        /// 判断字符串是否在字符串数组中
        /// </summary>
        public static bool IsInArray(string s, string[] array)
        {
            return IsInArray(s, array, false);
        }

        /// <summary>
        /// 判断字符串是否在字符串中
        /// </summary>
        public static bool IsInArray(string s, string array, string splitStr, bool ignoreCase)
        {
            return IsInArray(s, Ext.SplitString(array, splitStr), ignoreCase);
        }

        /// <summary>
        /// 判断字符串是否在字符串中
        /// </summary>
        public static bool IsInArray(string s, string array, string splitStr)
        {
            return IsInArray(s, Ext.SplitString(array, splitStr), false);
        }

        /// <summary>
        /// 判断字符串是否在字符串中
        /// </summary>
        public static bool IsInArray(string s, string array)
        {
            return IsInArray(s, Ext.SplitString(array, ","), false);
        }



        /// <summary>
        /// 将对象数组拼接成字符串
        /// </summary>
        public static string ObjectArrayToString(object[] array, string splitStr)
        {
            if (array == null || array.Length == 0)
                return "";

            StringBuilder result = new StringBuilder();
            for (int i = 0; i < array.Length; i++)
                result.AppendFormat("{0}{1}", array[i], splitStr);

            return result.Remove(result.Length - splitStr.Length, splitStr.Length).ToString();
        }

        /// <summary>
        /// 将对象数组拼接成字符串
        /// </summary>
        public static string ObjectArrayToString(object[] array)
        {
            return ObjectArrayToString(array, ",");
        }

        /// <summary>
        /// 将字符串数组拼接成字符串
        /// </summary>
        public static string StringArrayToString(string[] array, string splitStr)
        {
            return ObjectArrayToString(array, splitStr);
        }

        /// <summary>
        /// 将字符串数组拼接成字符串
        /// </summary>
        public static string StringArrayToString(string[] array)
        {
            return StringArrayToString(array, ",");
        }

        /// <summary>
        /// 将整数数组拼接成字符串
        /// </summary>
        public static string IntArrayToString(int[] array, string splitStr)
        {
            if (array == null || array.Length == 0)
                return "";

            StringBuilder result = new StringBuilder();
            for (int i = 0; i < array.Length; i++)
                result.AppendFormat("{0}{1}", array[i], splitStr);

            return result.Remove(result.Length - splitStr.Length, splitStr.Length).ToString();
        }

        /// <summary>
        /// 将整数数组拼接成字符串
        /// </summary>
        public static string IntArrayToString(int[] array)
        {
            return IntArrayToString(array, ",");
        }



        /// <summary>
        /// 移除数组中的指定项
        /// </summary>
        /// <param name="array">源数组</param>
        /// <param name="removeItem">要移除的项</param>
        /// <param name="removeBackspace">是否移除空格</param>
        /// <param name="ignoreCase">是否忽略大小写</param>
        /// <returns></returns>
        public static string[] RemoveArrayItem(string[] array, string removeItem, bool removeBackspace, bool ignoreCase)
        {
            if (array != null && array.Length > 0)
            {
                StringBuilder arrayStr = new StringBuilder();
                if (ignoreCase)
                    removeItem = removeItem.ToLower();
                string temp = "";
                foreach (string item in array)
                {
                    if (ignoreCase)
                        temp = item.ToLower();
                    else
                        temp = item;

                    if (temp != removeItem)
                        arrayStr.AppendFormat("{0}_", removeBackspace ? item.Trim() : item);
                }

                return Ext.SplitString(arrayStr.Remove(arrayStr.Length - 1, 1).ToString(), "_");
            }

            return array;
        }

        /// <summary>
        /// 移除数组中的指定项
        /// </summary>
        /// <param name="array">源数组</param>
        /// <returns></returns>
        public static string[] RemoveArrayItem(string[] array)
        {
            return RemoveArrayItem(array, "", true, false);
        }

        /// <summary>
        /// 移除字符串中的指定项
        /// </summary>
        /// <param name="s">源字符串</param>
        /// <param name="splitStr">分割字符串</param>
        /// <returns></returns>
        public static string[] RemoveStringItem(string s, string splitStr)
        {
            return RemoveArrayItem(Ext.SplitString(s, splitStr), "", true, false);
        }

        /// <summary>
        /// 移除字符串中的指定项
        /// </summary>
        /// <param name="s">源字符串</param>
        /// <returns></returns>
        public static string[] RemoveStringItem(string s)
        {
            return RemoveArrayItem(Ext.SplitString(s), "", true, false);
        }



        /// <summary>
        /// 移除数组中的重复项
        /// </summary>
        /// <returns></returns>
        public static int[] RemoveRepeaterItem(int[] array)
        {
            if (array == null || array.Length < 2)
                return array;

            Array.Sort(array);

            int length = 1;
            for (int i = 1; i < array.Length; i++)
            {
                if (array[i] != array[i - 1])
                    length++;
            }

            int[] uniqueArray = new int[length];
            uniqueArray[0] = array[0];
            int j = 1;
            for (int i = 1; i < array.Length; i++)
                if (array[i] != array[i - 1])
                    uniqueArray[j++] = array[i];

            return uniqueArray;
        }

        /// <summary>
        /// 移除数组中的重复项
        /// </summary>
        /// <returns></returns>
        public static string[] RemoveRepeaterItem(string[] array)
        {
            if (array == null || array.Length < 2)
                return array;

            Array.Sort(array);

            int length = 1;
            for (int i = 1; i < array.Length; i++)
            {
                if (array[i] != array[i - 1])
                    length++;
            }

            string[] uniqueArray = new string[length];
            uniqueArray[0] = array[0];
            int j = 1;
            for (int i = 1; i < array.Length; i++)
                if (array[i] != array[i - 1])
                    uniqueArray[j++] = array[i];

            return uniqueArray;
        }
         
    }
}
