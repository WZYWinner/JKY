using System;
using System.Text;
using System.Text.RegularExpressions;
using System.Security.Cryptography;

namespace Yaohuasoft.Framework.Web
{
    /// <summary>
    ///扩张方法类
    /// </summary>
    public static class ExtendClass
    {
        /// <summary>
        /// 处理json字符串
        /// </summary>
        /// <param name="json"></param>
        /// <returns></returns>
        public static string JsonExtend(this string json)
        {
            return Regex.Replace(json, @"(\,\""\w+\"":(null|undefined|\{\}|""{2}|\""\\\/date[^\/]+\/\"")|\""\w+\"":(null|undefined|\{\}|""{2}|\""\\\/date[^\/]+\/\"")\,)", "", RegexOptions.IgnoreCase);
        }

        /// <summary>
        /// 移动电话验证
        /// </summary>
        public static bool ValidMobile(this string s)
        {
            return Regex.IsMatch(s, @"^1[3458]\d{9}$");
        }

        /// <summary>
        /// Email验证
        /// </summary>
        public static bool ValidEmail(this string s)
        {
            return Regex.IsMatch(s, @"^\w+([-+.]\w+)*@\w+([-.]\w+)*\.\w+([-.]\w+)*$");
        }

        /// <summary>
        /// 传真验证
        /// </summary>
        public static bool ValidFax(this string s)
        {
            return Regex.IsMatch(s, @"^(86\-)?(\d{2,4}-)?([2-9]\d{6,7})+(-\d{1,4})?$");
        }

        /// <summary>
        /// 固定电话验证
        /// </summary>
        public static bool ValidTel(this string s)
        {
            return Regex.IsMatch(s, @"^(0\d{2,3}-)?\d{7,8}(-\d{1,4})?$");
        }

        /// <summary>
        /// 手机或者固定电话
        /// </summary>
        public static bool ValidMobileOrTel(this string s)
        {
            return Regex.IsMatch(s, @"^(1[3458]\d{9}|(0\d{2,3}-)?\d{7,8}(-\d{1,4})?)$");
        }

        /// <summary>
        /// 替换特殊符号
        /// </summary>
        /// <param name="s">内容</param>
        /// <returns></returns>
        public static string ReplaceSymbol(this string s) {
            return s.Replace("&lt;", "<").Replace("&gt;", ">").Replace("“", "\"").Replace(@"\r", "<br />");
        }
        /// <summary>
        /// Url地址
        /// </summary>
        /// <returns></returns>
        public static bool ValidWebUrl(this string s)
        {
            return Regex.IsMatch(s, @"^(http|https|ftp):\/\/([\w-]+\.)+[\w-]+([\/\:][\w- .\/?%&=\;#\*]*)?$");
        }
        /// <summary>
        /// 验证邮政编码
        /// </summary>
        /// <param name="s"></param>
        /// <returns></returns>
        public static bool ValidZip(this string s)
        {
            return Regex.IsMatch(s, @"^\d{6}$");
        }
        /// <summary>
        /// 是否只由汉字、字母、数字组成下划线
        /// </summary>
        /// <param name="s"></param>
        /// <returns></returns>
        public static bool ValidChinaOrNumbOrLett(this string s)
        {
            return Regex.IsMatch(s, @"^[0-9a-zA-Z_\-\u4e00-\u9fa5]+$");
        }
        /// <summary>
        /// 是否只由英文字母和数字组成
        /// </summary>
        /// <param name="s"></param>
        /// <returns></returns>
        public static bool ValidNumberOrLetter(this string s)
        {
            return Regex.IsMatch(s, @"^[0-9a-zA-Z]+$");
        }
        /// <summary>
        /// 是否只由英文字母和数字和下划线组成
        /// </summary>
        /// <param name="s"></param>
        /// <returns></returns>
        public static bool ValidNumberOr_Letter(this string s)
        {
            return Regex.IsMatch(s, @"^[0-9a-zA-Z\_]+$");
        }

        /// <summary>
        /// 判断是否为正整数
        /// </summary>
        /// <param name="str"></param>
        /// <param name="num">返回值为true时则把字符串转换为整数存储在num,返回值为false地则不改变num的值</param>
        /// <returns>是：返回true.否：返回false</returns>
        public static bool isPositiveInteger(this string str,ref int num)
        {
            if (System.Text.RegularExpressions.Regex.IsMatch(str, @"^\d+$"))
            {
                num = int.Parse(str);
                return true;
            }
            return false;
        }

        /// <summary>
        /// 判断字符串是否为空
        /// </summary>
        /// <param name="str"></param>
        /// <returns></returns>
        public static string DefaultText(this string str)
        {
            return DefaultText(str, "");
        }
        /// <summary>
        /// 判断字符串是否为空
        /// </summary>
        /// <param name="str"></param>
        /// <param name="default_txt"></param>
        /// <returns></returns>
        public static string DefaultText(this string str, string default_txt)
        {
            return SetDefault<string>(string.IsNullOrEmpty(str), default_txt, str);
        }
        /// <summary>
        /// 设置默认值的方法
        /// </summary>
        /// <typeparam name="T">返回的类型</typeparam>
        /// <param name="where">条件</param>
        /// <param name="input_str">输入值</param>
        /// <param name="default_str">默认值</param>
        /// <returns></returns>
        public static T SetDefault<T>(bool where, T default_str, T input_str)
        {
            return where ? default_str : input_str;
        }
    }
}