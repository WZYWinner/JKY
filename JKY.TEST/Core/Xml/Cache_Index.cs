using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Yaohuasoft.Framework.Web
{
    public sealed class Cache_Index : CacheBase<Channel>
    {
        /// <summary>
        /// 关键字
        /// </summary>
        private const string _key = "index";
        /// <summary>
        /// 药品首页配置文件缓存构造函数
        /// </summary>
        static Cache_Index()
        {
            SetCacheDate = 20 * 60;//设置缓存时间
        }
        /// <summary>
        /// 获取数据
        /// </summary>
        internal override Channel[] Data
        {
            get
            {
                return Tool.Get_Types_Xml(Tool.Url_Index).List.ToArray();
            }
        }
        /// <summary>
        /// 列表
        /// </summary>
        public override Channel[] List
        {
            get
            {
                Key = _key;
                return base.List;
            }
        }
        /// <summary>
        /// 通过名称获取数据
        /// </summary>
        /// <typeparam name="T">实体</typeparam>
        /// <param name="name">名称</param>
        /// <returns></returns>
        public T[] Item<T>(string name)
        {
            Channel channel = List.FirstOrDefault((m) => { return m.Name == name; });
            if (channel == null) return null;
            return (T[])JsonConvert.DeserializeObject(channel.Data.Trim('\n').Trim(), typeof(T[]));
        }

    }
}