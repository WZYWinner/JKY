using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Configuration;
using System.Text.RegularExpressions;
using System.Text;

namespace Yaohuasoft.Framework.Web
{
    /// <summary>
    /// 工具类
    /// </summary>
    public sealed class Tool
    {
        /// <summary>
        /// 网址
        /// </summary>
        public static string Website_Url
        {
            get
            {
                string web_url=ConfigurationManager.AppSettings["website_url"];
                HttpRequest request=HttpContext.Current.Request;
                return string.IsNullOrEmpty(web_url) ? "http://" + request.Url.Host + (request.Url.Port == 80 ? "" : ":" + request.Url.Port) : web_url;
            }
        }
        /// <summary>
        /// Cookie域
        /// </summary>
        public static string Domain
        {
            get
            {
                return ConfigurationManager.AppSettings["domain"];
            }
        }

        public static string ak 
        {
            get 
            {
                return "STP5M6b5qXTlTTdMz2KWKR2Xm1mucRnt";
            }
        }
        /// <summary>
        /// 验证信息
        /// </summary>
        /// <param name="ouput">输出对象</param>
        /// <param name="isTrue">判断条件</param>
        /// <param name="msg">错误信息</param>
        /// <returns></returns>
        public static bool Validate(ref string ouput, bool isTrue, string msg)
        {
            if (isTrue) ouput = msg;
            return isTrue;
        }
        public static string Url_Index
        {
            get
            {
                return HttpContext.Current.Server.MapPath("~/_Common/Xml/Index.xml");
            }
        }
        /// <summary>
        /// 获取设置值
        /// </summary>
        /// <param name="key">appSettings关键字</param>
        /// <param name="url">所对应的配置文件路径</param>
        /// <returns>获取值</returns>
        public static string Get_Types(string key, string url)
        {
            //打开指定配置文件
            ExeConfigurationFileMap file = new ExeConfigurationFileMap() { ExeConfigFilename = url };
            Configuration config = ConfigurationManager.OpenMappedExeConfiguration(file, ConfigurationUserLevel.None);
            return config.AppSettings.Settings[key].Value;
        }
        /// <summary>
        /// 获取配置xml文本
        /// </summary>
        /// <param name="name">节点名称</param>
        /// <param name="url">所对应的配置文件路径</param>
        /// <returns></returns>
        public static string Get_Types_Xml(string name, string url)
        {
            ChannelList channelList = Get_Types_Xml(url);
            Channel channel = channelList.List.Find((item) => { return item.Name == name; });
            return channel == null ? "" : Regex.Replace(channel.Data, @"[\r\n]+", "");
        }

        /// <summary>
        /// 获取配置xml
        /// </summary>
        /// <param name="url">所对应的配置文件路径</param>
        /// <returns></returns>
        public static ChannelList Get_Types_Xml(string url)
        {
            ChannelList channelList = XmlHelper.XmlDeserializeFromFile<ChannelList>(url, Encoding.UTF8);
            return channelList;
        }

        /// <summary>
        /// 获取配置xml文本
        /// </summary>
        /// <param name="name">节点名称</param>
        /// <param name="url">数据</param>
        /// <returns></returns>
        public static string Get_Types_Xml(string name, ChannelList channelList)
        {
            Channel channel = channelList.List.Find((item) => { return item.Name == name; });
            return channel == null ? "" : Regex.Replace(channel.Data, @"[\r\n]+", "");
        }
    }
}