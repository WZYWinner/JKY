using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Yaohuasoft.Framework.DAL;
using Yaohuasoft.Framework.BLL;
using Yaohuasoft.Framework.Library;
using System.Configuration;
using System.Net;
using System.Text;
using System.IO;
using System.Text.RegularExpressions;
using System.Security.Cryptography;

namespace Yaohuasoft.Framework.DAL
{
    public static class CommonMethod
    {
        public static string ApiPost(string Url, string Body, string ContentType = "application/x-www-form-urlencoded", string encoding_name = "utf-8")
        {
            return ApiPost(Url, Body, null, ContentType, "utf-8");
        }

        public static string ApiPost(string Url, string Body, Dictionary<string, string> dic, string ContentType = "application/x-www-form-urlencoded", string encoding_name = "utf-8")
        {
            return ApiPost(Url, Body, dic, (Request) =>
            {
                WebResponse Response = (HttpWebResponse)Request.GetResponse();

                var DateStream = Response.GetResponseStream();
                StreamReader Sr = new StreamReader(DateStream, System.Text.Encoding.GetEncoding(encoding_name));
                var ReturnStr = Sr.ReadToEnd();
                Sr.Close();
                DateStream.Close();
                Response.Close();
                return ReturnStr;
            },ContentType,encoding_name);
        }

        public static string ApiPost(string Url, string Body, Dictionary<string, string> dic, Func<WebRequest, string> fun, string ContentType = "application/x-www-form-urlencoded", string encoding_name = "utf-8")
        {
            ////记录调用日志
            YaohuaMonitor.RecordLog("CommonMethod.ApiPost:" + Url + "★★★★★" + Body, YaohuaLogType.Monitor, "给客户回调ApiPost");
            string ReturnStr = "";
            try
            {
                WebRequest Request = WebRequest.Create(Url);
                byte[] ByteBody = Encoding.UTF8.GetBytes(Body);
                Request.Method = "Post";
                if (dic != null && dic.Count > 0)
                {
                    foreach (var Key in dic.Keys)
                    {
                        Request.Headers.Add(Key, dic[Key]);
                    }
                }
                Request.ContentType = ContentType;
                Request.ContentLength = ByteBody.Length;
                Stream DateStream = Request.GetRequestStream();
                DateStream.Write(ByteBody, 0, ByteBody.Length);
                DateStream.Close();
                var Response = (HttpWebResponse)Request.GetResponse();
                if (fun!=null)
                {
                    ReturnStr = fun(Request);
                }
            }
            catch (Exception ex)
            {
                ex.RecordException(Url + "★" + Body);
            }
            return ReturnStr;
        }

        public static string ApiPost2(string Url, string Body, Dictionary<string, string> dic, Func<WebRequest, string> fun, string ContentType = "application/x-www-form-urlencoded", string encoding_name = "utf-8")
        {
            ////记录调用日志
            YaohuaMonitor.RecordLog("CommonMethod.ApiPost2:" + Url + "★★★★★" + Body, YaohuaLogType.Monitor, "给客户回调ApiPost2");
            string ReturnStr = "";
            try
            {
                WebRequest Request = WebRequest.Create(Url);
                byte[] ByteBody = Encoding.UTF8.GetBytes(Body);
                Request.Method = "Post";
                if (dic != null && dic.Count > 0)
                {
                    foreach (var Key in dic.Keys)
                    {
                        Request.Headers.Add(Key, dic[Key]);
                    }
                }
                Request.ContentType = ContentType;
                Request.ContentLength = ByteBody.Length;
                Stream DateStream = Request.GetRequestStream();
                DateStream.Write(ByteBody, 0, ByteBody.Length);
                DateStream.Close();
                var Response = (HttpWebResponse)Request.GetResponse();
                if (fun != null)
                {
                    ReturnStr = fun(Request);
                }
            }
            catch (Exception ex)
            {
                ex.RecordException(Url + "★" + Body);
                ReturnStr = ex.Message;
            }
            return ReturnStr;
        }

        public static string ApiGet(string Url, string Body)
        {
            return ApiGet(Url, Body, null, "text/html;charset=UTF-8", "utf-8");
        }
        public static string ApiGet(string Url, string Body, string ContentType = "text/html;charset=UTF-8")
        {
            return ApiGet(Url, Body, null, ContentType, "utf-8");
        }
        public static string ApiGet(string Url, string Body, string ContentType = "text/html;charset=UTF-8", string encoding_name = "utf-8")
        {
            return ApiGet(Url, Body, null, ContentType, encoding_name);
        }
        public static string ApiGet(string Url, string Body, Dictionary<string, string> dic, string ContentType = "text/html;charset=UTF-8", string encoding_name = "utf-8")
        {
            ////记录调用日志
            YaohuaMonitor.RecordLog("CommonMethod.ApiGet:" + Url + "★★★★★" + Body, YaohuaLogType.Monitor, "ApiGet-回调");
            string ReturnStr = "";
            try
            {
                WebRequest Request = WebRequest.Create(Url + (Body == "" ? "" : "?") + Body);
                Request.Method = "GET";
                if (dic != null && dic.Count > 0)
                {
                    foreach (var Key in dic.Keys)
                    {
                        Request.Headers.Add(Key, dic[Key]);
                    }
                }
                Request.ContentType = ContentType;
                HttpWebResponse Response = (HttpWebResponse)Request.GetResponse();
                Stream myResponseStream = Response.GetResponseStream();
                StreamReader Sr = new StreamReader(myResponseStream, Encoding.GetEncoding(encoding_name));
                ReturnStr = Sr.ReadToEnd();
                Sr.Close();
                myResponseStream.Close();
            }
            catch (Exception ex)
            {
                ex.RecordException(Url + "★" + Body);
            }
            return ReturnStr;
        }
    }

}