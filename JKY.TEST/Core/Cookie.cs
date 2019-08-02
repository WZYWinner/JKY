using System;
using System.Text;
using System.Web;
using System.Collections;

namespace Yaohuasoft.Framework.Web
{
    /// <summary>
    /// cookie类
    /// </summary>
    public sealed class Cookie {
        /// <summary>
        /// 历史纪录写入cookie
        /// </summary>
        public static void Cookie_Set(string name, string value)
        {
            HttpCookie myCookie = HttpContext.Current.Request.Cookies[name];
            if (myCookie == null)
                myCookie = new HttpCookie(name);
            else if (myCookie.Values.Count > 10)
                myCookie.Values.Remove(myCookie.Values.Keys[0]);
            int count = myCookie.Values.Count;
            for (int j = 0; j < count; j++)
            {
                if (HttpUtility.UrlDecode(myCookie.Values[j]) == value)
                {
                    myCookie.Values.Remove(myCookie.Values.Keys[j]); break;
                }
            }

            myCookie.Values.Add(DateTime.Now.ToString("yyMMddHHmmss") + new Random().Next(100).ToString(), value);
            myCookie.Domain = Tool.Domain;
            myCookie.Expires = DateTime.Now.AddHours(1);
            HttpContext.Current.Response.AppendCookie(myCookie);
        }

        /// <summary>
        /// 设置单个cookie
        /// </summary>
        /// <param name="name"></param>
        /// <param name="value"></param>
        public static void Cookie_Set_One(string name, string value)
        {
            HttpCookie myCookie = HttpContext.Current.Request.Cookies[name];
            if (myCookie == null) myCookie = new HttpCookie(name);
            myCookie.Value = HttpUtility.UrlEncode(value);
            myCookie.Domain = Tool.Domain;
            myCookie.Expires = DateTime.Now.AddHours(1);
            HttpContext.Current.Response.AppendCookie(myCookie);
        }

        /// <summary>
        /// 读取cookie值
        /// </summary>
        public static ArrayList Cookie_Get(string name)
        {
            HttpCookie cookie = HttpContext.Current.Request.Cookies[name];
            if (cookie == null) return null;
            ArrayList list = new ArrayList();
            for (int i = cookie.Values.Count - 1; i > -1; i--)
            {
                list.Add(cookie.Values[i]);
            }
            return list;
        }

        /// <summary>
        /// 获取单个cookie
        /// </summary>
        /// <param name="name"></param>
        /// <returns></returns>
        public static string Cookie_Get_One(string name)
        {
            HttpCookie cookie = HttpContext.Current.Request.Cookies[name];
            return cookie == null ? "" : HttpUtility.UrlDecode(cookie.Value);
        }

        /// <summary>
        /// 获取cookie某个值
        /// </summary>
        /// <param name="name">cookie名</param>
        /// <param name="key">关键字</param>
        /// <returns></returns>
        public static string Cookie_Get_One(string name, string key) {
            HttpCookie cookie = HttpContext.Current.Request.Cookies[name];
            return cookie == null ? "" : HttpUtility.UrlDecode(cookie[key]);
        }

        

        /// <summary>
        /// 清除cookie
        /// </summary>
        /// <param name="name">cookie名</param>
        public static void Cookie_Clear(string name) {
            HttpCookie cookie = HttpContext.Current.Request.Cookies[name];
            if (cookie != null) {
                while(cookie.Values.Count>0){
                    cookie.Values.Remove(cookie.Values.Keys[0]);
                }
                cookie.Domain = Tool.Domain;
                cookie.Expires = DateTime.Now.AddHours(-1);
                HttpContext.Current.Response.Cookies.Add(cookie);
            }
        }
    }
}