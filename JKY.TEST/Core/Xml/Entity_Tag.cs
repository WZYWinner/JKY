using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Newtonsoft.Json;

namespace Yaohuasoft.Framework.Web
{
    public class Entity_Tag
    {
        /// <summary>
        /// 标签名称
        /// </summary>
        [JsonProperty(PropertyName = "name")]
        public string Name { get; set; }

        /// <summary>
        /// 子标签列表
        /// </summary>
        [JsonProperty(PropertyName = "list")]
        public Entity_Tag[] List { get; set; }

        /// <summary>
        /// 关键字
        /// </summary>
        [JsonProperty(PropertyName="key")]
        public string Key { get; set; }
        /// <summary>
        /// 值
        /// </summary>
        [JsonProperty(PropertyName="value")]
        public string Value { get; set; }
        /// <summary>
        /// 数字
        /// </summary>
        [JsonProperty(PropertyName="num")]
        public string Num { get; set; }
    }
}
